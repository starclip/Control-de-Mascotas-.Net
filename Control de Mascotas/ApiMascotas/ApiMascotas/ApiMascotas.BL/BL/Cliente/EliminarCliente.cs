using ApiMascotas.Entidades;

namespace ApiMascotas.BL
{
    public class EliminarCliente
    {
        public RespuestaServidor<dynamic> Ejecute(Cliente cliente)
        {
            bool estado = new DAL.EliminarCliente().Ejecute(cliente);
            RespuestaServidor<dynamic> respuestaServidor = new Comunes.Respuesta().RespuestaServidor<bool>(Comunes.EnumRespuesta.Correcto, estado, TextoRespuesta.EliminarRegistro);
            return respuestaServidor;
        }
    }
}