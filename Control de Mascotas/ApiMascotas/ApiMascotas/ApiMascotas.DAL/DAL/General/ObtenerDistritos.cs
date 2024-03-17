using ApiMascotas.Entidades;
using ApiMascotas.Entidades.BD;
using System.Collections.Generic;

namespace ApiMascotas.DAL
{
    public class ObtenerDistritos
    {
        public List<Distrito> Ejecute(Canton canton)
        {
            string procedimiento = "cfg.ObtenerDistritos";

            // Se definen los parámetros.
            List<Parametro> parametros = new List<Parametro>(){
                new Parametro("IDCANTON", canton.IdCanton)
            };

            // Se obtienen los clientes del SP.
            List<Dictionary<string, object>> datosResultado = BD.EjecutarSP(procedimiento, parametros);
            List<Distrito> distritos = new List<Distrito>();

            // Recorre todos los datos y los convierte al objeto distrito.
            foreach(Dictionary<string, object> dato in datosResultado)
            {
                Distrito distrito = new Distrito()
                {
                    IdDistrito = long.Parse(dato["IDDISTRITO"].ToString()),
                    IdCanton = long.Parse(dato["IDCANTON"].ToString()),
                    Codigo = dato["CODIGO"].ToString(),
                    Nombre = dato["NOMBRE"].ToString()
                };

                distritos.Add(distrito);
            }

            return distritos;
        }
    }
}
