using ApiMascotas.Entidades;

namespace ApiMascotas.BL.Comunes
{
    public class Respuesta
    {
        public RespuestaServidor<dynamic> RespuestaServidor<T>(EnumRespuesta code, T datos, string textoRespuesta)
        {
            RespuestaServidor<dynamic> respuesta = new RespuestaServidor<dynamic>
            {
                CodigoRespuesta = (int)code,
                Respuesta = textoRespuesta,
                Datos = datos
            };

            return respuesta;
        }
    }
}
