using MascotasWeb.Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MascotasWeb.Servicios
{
    public class ObtenerProvincias
    {
        public List<Provincia> Ejecute()
        {
            string resultado = ConsumirApiRest.Ejecute(Rutas.ObtenerProvincias, TipoMetodo.Get, string.Empty);
            RespuestaProvincia respuesta = JsonConvert.DeserializeObject<RespuestaProvincia>(resultado);
            return respuesta.Datos;
        }
    }
}
