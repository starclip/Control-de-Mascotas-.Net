using MascotasWeb.Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MascotasWeb.Servicios
{
    public class ObtenerSexos
    {
        public List<Sexo> Ejecute()
        {
            string resultado = ConsumirApiRest.Ejecute(Rutas.ObtenerSexos, TipoMetodo.Get, string.Empty);
            RespuestaSexo respuesta = JsonConvert.DeserializeObject<RespuestaSexo>(resultado);
            return respuesta.Datos;
        }
    }
}
