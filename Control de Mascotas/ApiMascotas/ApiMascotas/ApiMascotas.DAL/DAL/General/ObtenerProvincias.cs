using ApiMascotas.Entidades;
using ApiMascotas.Entidades.BD;
using System.Collections.Generic;

namespace ApiMascotas.DAL
{
    public class ObtenerProvincias
    {
        public List<Provincia> Ejecute()
        {
            string procedimiento = "cfg.ObtenerProvincias";

            // Se definen los parámetros.
            List<Parametro> parametros = new List<Parametro>(){};

            // Se obtienen los clientes del SP.
            List<Dictionary<string, object>> datosResultado = BD.EjecutarSP(procedimiento, parametros);
            List<Provincia> provincias = new List<Provincia>();

            // Recorre todos los datos y los convierte al objeto provincia.
            foreach(Dictionary<string, object> dato in datosResultado)
            {
                Provincia provincia = new Provincia()
                {
                    IdProvincia = long.Parse(dato["IDPROVINCIA"].ToString()),
                    Codigo = dato["CODIGO"].ToString(),
                    Nombre = dato["NOMBRE"].ToString()
                };

                provincias.Add(provincia);
            }

            return provincias;
        }
    }
}
