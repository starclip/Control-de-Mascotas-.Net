using ApiMascotas.Entidades;
using ApiMascotas.Entidades.BD;
using System.Collections.Generic;

namespace ApiMascotas.DAL
{
    public class ObtenerCantones
    {
        public List<Canton> Ejecute(Provincia provincia)
        {
            string procedimiento = "cfg.ObtenerCantones";

            // Se definen los parámetros.
            List<Parametro> parametros = new List<Parametro>(){
                new Parametro("IDPROVINCIA", provincia.IdProvincia)
            };

            // Se obtienen los clientes del SP.
            List<Dictionary<string, object>> datosResultado = BD.EjecutarSP(procedimiento, parametros);
            List<Canton> cantones = new List<Canton>();

            // Recorre todos los datos y los convierte al objeto cantón.
            foreach(Dictionary<string, object> dato in datosResultado)
            {
                Canton canton = new Canton()
                {
                    IdCanton = long.Parse(dato["IDCANTON"].ToString()),
                    IdProvincia = long.Parse(dato["IDPROVINCIA"].ToString()),
                    Codigo = dato["CODIGO"].ToString(),
                    Nombre = dato["NOMBRE"].ToString()
                };

                cantones.Add(canton);
            }

            return cantones;
        }
    }
}
