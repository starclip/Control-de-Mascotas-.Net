using MascotasWeb.Entidades;
using Newtonsoft.Json;

namespace MascotasWeb.Servicios
{
    public class ValidarCedula
    {
        public bool Ejecute(string Cedula)
        {
            string parametro = "?Cedula=" + Cedula;
            string resultado = ConsumirApiRest.Ejecute(Rutas.ValidarCedula, TipoMetodo.Get, parametro);
            RespuestaEstado respuesta = JsonConvert.DeserializeObject<RespuestaEstado>(resultado);
            return respuesta.Datos;
        }
    }
}
