using ApiMascotas.Entidades;

namespace ApiMascotas.BL
{
    public class ValidarCedula
    {
        public RespuestaServidor<dynamic> Ejecute(Persona persona)
        {
            bool estado = new DAL.ValidarCedula().Ejecute(persona);
            RespuestaServidor<dynamic> respuestaServidor = new Comunes.Respuesta().RespuestaServidor<bool>(Comunes.EnumRespuesta.Correcto, estado, TextoRespuesta.EstadoObtenido);
            return respuestaServidor;
        }
    }
}