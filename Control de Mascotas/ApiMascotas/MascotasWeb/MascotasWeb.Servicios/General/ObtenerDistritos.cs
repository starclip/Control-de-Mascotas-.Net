using MascotasWeb.Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MascotasWeb.Servicios
{
    public class ObtenerDistritos
    {
        public List<Distrito> Ejecute(long IdCanton)
        {
            string parametro = "?IdCanton=" + IdCanton.ToString();
            string resultado = ConsumirApiRest.Ejecute(Rutas.ObtenerDistritos, TipoMetodo.Get, parametro);
            RespuestaDistrito respuesta = JsonConvert.DeserializeObject<RespuestaDistrito>(resultado);
            return respuesta.Datos;
        }
    }
}
