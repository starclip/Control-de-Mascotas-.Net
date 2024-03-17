using ApiMascotas.Entidades;

namespace ApiMascotas.BL
{
    public class EditarCliente
    {
        public RespuestaServidor<dynamic> Ejecute(Cliente cliente)
        {
            bool actualizado = new DAL.EditarCliente().Ejecute(cliente);
            Comunes.EnumRespuesta respuesta;

            if (!actualizado)
                respuesta = Comunes.EnumRespuesta.Fallido;
            else
                respuesta = Comunes.EnumRespuesta.Correcto;

            RespuestaServidor<dynamic> respuestaServidor = new Comunes.Respuesta().RespuestaServidor<bool>(respuesta, actualizado, TextoRespuesta.ActualizacionRegistro);
            return respuestaServidor;
        }
    }
}