using MascotasWeb.Entidades;
using Newtonsoft.Json;

namespace MascotasWeb.Servicios
{
    public class ObtenerClientesTotal
    {
        public int Ejecute(DatosFiltroCliente datosFiltro)
        {
            string contenido = JsonConvert.SerializeObject(datosFiltro);
            string resultado = ConsumirApiRest.Ejecute(Rutas.ObtenerClientesTotales, TipoMetodo.Post, contenido);
            RespuestaTotales respuesta = JsonConvert.DeserializeObject<RespuestaTotales>(resultado);
            return respuesta.Datos;
        }
    }
}
