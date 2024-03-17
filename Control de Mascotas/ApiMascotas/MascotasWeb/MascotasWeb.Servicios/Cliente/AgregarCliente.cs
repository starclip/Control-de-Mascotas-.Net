using MascotasWeb.Entidades;
using Newtonsoft.Json;

namespace MascotasWeb.Servicios
{
    public class AgregarCliente
    {
        public long Ejecute(Cliente cliente)
        {
            string contenido = JsonConvert.SerializeObject(cliente);
            string resultado = ConsumirApiRest.Ejecute(Rutas.AgregarCliente, TipoMetodo.Post, contenido);
            RespuestaNuevo respuesta = JsonConvert.DeserializeObject<RespuestaNuevo>(resultado);
            return respuesta.Datos;
        }
    }
}
