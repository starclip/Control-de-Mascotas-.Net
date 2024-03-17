using ApiMascotas.Entidades;
using ApiMascotas.Entidades.BD;
using System.Collections.Generic;

namespace ApiMascotas.DAL
{
    public class ObtenerClientesTotal
    {
        public int Ejecute(DatosFiltroCliente datosFiltro)
        {
            string procedimiento = "per.ObtenerClientesTotal";
            int total = 0;

            // Se definen los parámetros.
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("Nombre", datosFiltro.Nombre)
            };

            // Se obtiene la cantidad de clientes del SP.
            List<Dictionary<string, object>> datosResultado = BD.EjecutarSP(procedimiento, parametros);

            // Recorro todos los registros obtenidos de BD.
            foreach(Dictionary<string, object> dato in datosResultado)
            {
                // Recorro todas las llaves del diccionario.
                foreach(string llave in dato.Keys)
                {
                    if (llave == "Total")
                        total = int.Parse(dato[llave].ToString());
                }
            }

            return total;
        }
    }
}
