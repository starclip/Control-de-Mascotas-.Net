using MascotasWeb.Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MascotasWeb.Servicios
{
    public class ObtenerCantones
    {
        public List<Canton> Ejecute(long IdProvincia)
        {
            string parametro = "?IdProvincia=" + IdProvincia.ToString();
            string resultado = ConsumirApiRest.Ejecute(Rutas.ObtenerCantones, TipoMetodo.Get, parametro);
            RespuestaCanton respuesta = JsonConvert.DeserializeObject<RespuestaCanton>(resultado);
            return respuesta.Datos;
        }
    }
}
