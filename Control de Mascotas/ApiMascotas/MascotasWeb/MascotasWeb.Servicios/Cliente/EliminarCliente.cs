using MascotasWeb.Entidades;
using Newtonsoft.Json;

namespace MascotasWeb.Servicios
{
    public class EliminarCliente
    {
        public bool Ejecute(Cliente cliente)
        {
            string contenido = JsonConvert.SerializeObject(cliente);
            string resultado = ConsumirApiRest.Ejecute(Rutas.EliminarCliente, TipoMetodo.Post, contenido);
            RespuestaEstado respuesta = JsonConvert.DeserializeObject<RespuestaEstado>(resultado);
            return respuesta.Datos;
        }
    }
}
