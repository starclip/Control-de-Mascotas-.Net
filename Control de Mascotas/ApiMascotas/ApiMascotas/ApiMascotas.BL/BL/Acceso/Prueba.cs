using ApiMascotas.Entidades;

namespace ApiMascotas.BL
{
    public class Prueba
    {
        public RespuestaServidor<dynamic> Ejecute(string parametro1, int parametro2, bool parametro3, long parametro4)
        {
            RespuestaPrueba respuesta = new ApiMascotas.DAL.Prueba.Prueba().Ejecute(parametro1, parametro2, parametro3, parametro4);
            RespuestaServidor<dynamic> respuestaServidor = new Comunes.Respuesta().RespuestaServidor<RespuestaPrueba>(Comunes.EnumRespuesta.Correcto, respuesta, "Exitoso");
            return respuestaServidor;
        }
    }
}