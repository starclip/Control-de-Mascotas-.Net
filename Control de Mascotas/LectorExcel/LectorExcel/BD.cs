using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LectorExcel
{
    public class BD
    {
        private readonly string HileraConexion;
        private const int tiempoEspera = 120;
        public BD(string HileraConexion)
        {
            this.HileraConexion = HileraConexion;
        }

        // Ejecuta un SP con parametros.
        public List<Dictionary<string, object>> EjecutarSP(string nombreSP, List<Parametro> parametros)
        {
            try
            {
                List<Dictionary<string, object>> datos = new List<Dictionary<string, object>>();

                // Creo la conexión con SQL server.
                using (SqlConnection sql = new SqlConnection(HileraConexion))
                {
                    // Creo el comando encargado de ejecutar el SP.
                    using (SqlCommand comando = new SqlCommand(nombreSP, sql))
                    {
                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        comando.CommandTimeout = tiempoEspera;

                        // Defino los parámetros del SP dinámicamente.
                        foreach (Parametro parametro in parametros)
                        {
                            comando.Parameters.Add(parametro.ObtenerParametro());
                        }

                        // Abro la conexión a SQL Server.
                        sql.Open();

                        // Ejecuto el SP.
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (!lector.IsClosed)
                            {
                                // Leo los valores devueltos por parte del SP.
                                while (lector.Read())
                                {
                                    Dictionary<string, object> datosRecuperados = new Dictionary<string, object>();
                                    for (int i = 0; i < lector.FieldCount; i++)
                                    {
                                        datosRecuperados.Add(lector.GetName(i), (lector[i] == DBNull.Value ? null : lector[i]));
                                    }
                                    datos.Add(datosRecuperados);
                                }
                                if (!lector.NextResult())
                                {
                                    lector.Close();
                                }
                            }
                        }

                        // Cierro la conexión.
                        sql.Close();

                        return datos;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private DataTable ConvertirDataTable(List<Provincia> provincias)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("CODIGO", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("NOMBRE", typeof(string)));

            foreach(Provincia provincia in provincias)
            {
                DataRow dr = tbl.NewRow();
                dr["CODIGO"] = provincia.Codigo;
                dr["NOMBRE"] = provincia.Nombre;
                tbl.Rows.Add(dr);
            }

            return tbl;
        }

        private DataTable ConvertirDataTable(List<Canton> cantones)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("CODIGO", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("PROVINCIA", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("NOMBRE", typeof(string)));

            foreach (Canton canton in cantones)
            {
                DataRow dr = tbl.NewRow();
                dr["CODIGO"] = canton.Codigo;
                dr["PROVINCIA"] = canton.Provincia;
                dr["NOMBRE"] = canton.Nombre;
                tbl.Rows.Add(dr);
            }

            return tbl;
        }

        private DataTable ConvertirDataTable(List<Distrito> distritos)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("CODIGO", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("CANTON", typeof(Int32)));
            tbl.Columns.Add(new DataColumn("NOMBRE", typeof(string)));

            foreach (Distrito distrito in distritos)
            {
                DataRow dr = tbl.NewRow();
                dr["CODIGO"] = distrito.Codigo;
                dr["CANTON"] = distrito.Canton;
                dr["NOMBRE"] = distrito.Nombre;
                tbl.Rows.Add(dr);
            }

            return tbl;
        }

        // Carga las provincias.
        public void CargarProvincias(List<Provincia> provincias)
        {
            // Creo la conexión con SQL server.
            using (SqlConnection sql = new SqlConnection(HileraConexion))
            {
                SqlBulkCopy sqlBulk = new SqlBulkCopy(sql);
                sqlBulk.DestinationTableName = "tmp.PROVINCIA";
                sqlBulk.ColumnMappings.Add("CODIGO", "CODIGO");
                sqlBulk.ColumnMappings.Add("NOMBRE", "NOMBRE");

                sql.Open();
                sqlBulk.WriteToServer(ConvertirDataTable(provincias));
            }
        }

        // Cargo los cantones.
        public void CargarCantones(List<Canton> cantones)
        {
            // Creo la conexión con SQL server.
            using (SqlConnection sql = new SqlConnection(HileraConexion))
            {
                SqlBulkCopy sqlBulk = new SqlBulkCopy(sql);
                sqlBulk.DestinationTableName = "tmp.CANTON";
                sqlBulk.ColumnMappings.Add("CODIGO", "CODIGO");
                sqlBulk.ColumnMappings.Add("PROVINCIA", "PROVINCIA");
                sqlBulk.ColumnMappings.Add("NOMBRE", "NOMBRE");

                sql.Open();
                sqlBulk.WriteToServer(ConvertirDataTable(cantones));
            }
        }

        // Cargo los distritos.
        public void CargarDistritos(List<Distrito> distritos)
        {
            // Creo la conexión con SQL server.
            using (SqlConnection sql = new SqlConnection(HileraConexion))
            {
                SqlBulkCopy sqlBulk = new SqlBulkCopy(sql);
                sqlBulk.DestinationTableName = "tmp.DISTRITO";
                sqlBulk.ColumnMappings.Add("CODIGO", "CODIGO");
                sqlBulk.ColumnMappings.Add("CANTON", "CANTON");
                sqlBulk.ColumnMappings.Add("NOMBRE", "NOMBRE");

                sql.Open();
                sqlBulk.WriteToServer(ConvertirDataTable(distritos));
            }
        }
    }
}
