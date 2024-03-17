using MascotasWeb.Entidades;
using Newtonsoft.Json;

namespace MascotasWeb.Servicios
{
    public class ObtenerCliente
    {
        public Cliente Ejecute(long IdCliente)
        {
            string contenido = "?IdCliente=" + IdCliente;
            string resultado = ConsumirApiRest.Ejecute(Rutas.ObtenerCliente, TipoMetodo.Get, contenido);
            RespuestaCliente respuesta = JsonConvert.DeserializeObject<RespuestaCliente>(resultado);
            return respuesta.Datos[0];
        }
    }
}
