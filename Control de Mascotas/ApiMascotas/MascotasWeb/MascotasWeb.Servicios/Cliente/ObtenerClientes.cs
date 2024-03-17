using MascotasWeb.Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MascotasWeb.Servicios
{
    public class ObtenerClientes
    {
        public List<Cliente> Ejecute(DatosFiltroCliente datosFiltro)
        {
            string contenido = JsonConvert.SerializeObject(datosFiltro);
            string resultado = ConsumirApiRest.Ejecute(Rutas.ObtenerClientes, TipoMetodo.Post, contenido);
            RespuestaCliente respuesta = JsonConvert.DeserializeObject<RespuestaCliente>(resultado);
            return respuesta.Datos;
        }
    }
}
