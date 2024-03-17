using ApiMascotas.BL;
using System.Web.Http;

namespace ApiMascotas.Controllers
{
    public class AccesoController : ApiController
    {
        [HttpGet]
        [Route("api/Acceso/ObtenerDatos")]
        public IHttpActionResult ObtenerDatos()
        {
            return Ok("Texto procesado");
        }

        [HttpPost]
        [Route("api/Acceso/Prueba")]
        public IHttpActionResult Prueba(string parametro1, int parametro2, bool parametro3, long parametro4)
        {
            return Ok(new Prueba().Ejecute(parametro1, parametro2, parametro3, parametro4));
        }
    }
}