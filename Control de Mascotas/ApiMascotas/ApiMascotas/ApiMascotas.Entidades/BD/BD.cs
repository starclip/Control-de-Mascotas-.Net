using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMascotas.Entidades.BD
{
    public static class BD
    {
        // Defino las variables de conexión a la base de datos.
        private static string conexion = ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        private static string tiempoEspera = ConfigurationManager.AppSettings["TiempoEspera"];

        // Defino el método de Ejecutar SP.
        public static List<Dictionary<string, object>> EjecutarSP(string nombreSP, List<Parametro> parametros)
        {
            try
            {
                List<Dictionary<string, object>> datos = new List<Dictionary<string, object>>();

                // Creo la conexión con SQL server.
                using (SqlConnection sql = new SqlConnection(conexion))
                {
                    // Creo el comando encargado de ejecutar el SP.
                    using (SqlCommand comando = new SqlCommand(nombreSP, sql))
                    {
                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        comando.CommandTimeout = Int32.Parse(tiempoEspera);

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
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }    
    }
}
