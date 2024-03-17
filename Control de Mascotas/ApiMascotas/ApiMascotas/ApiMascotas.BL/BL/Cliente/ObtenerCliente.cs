using ApiMascotas.Entidades;
using System.Collections.Generic;

namespace ApiMascotas.BL
{
    public class ObtenerCliente
    {
        public RespuestaServidor<dynamic> Ejecute(long IdCliente)
        {
            List<Cliente> clientes = new DAL.ObtenerCliente().Ejecute(IdCliente);
            RespuestaServidor<dynamic> respuestaServidor = new Comunes.Respuesta().RespuestaServidor<List<Cliente>>(Comunes.EnumRespuesta.Correcto, clientes, TextoRespuesta.ObtenerRegistro);
            return respuestaServidor;
        }
    }
}