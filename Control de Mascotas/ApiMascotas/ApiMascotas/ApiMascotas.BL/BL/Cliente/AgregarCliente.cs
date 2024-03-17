using ApiMascotas.Entidades;
using System.Collections.Generic;

namespace ApiMascotas.BL
{
    public class AgregarCliente
    {
        public RespuestaServidor<dynamic> Ejecute(Cliente cliente)
        {
            long nuevoCliente = new DAL.AgregarCliente().Ejecute(cliente);
            Comunes.EnumRespuesta respuesta;

            if (nuevoCliente == -1)
                respuesta = Comunes.EnumRespuesta.Fallido;
            else
                respuesta = Comunes.EnumRespuesta.Correcto;

            RespuestaServidor<dynamic> respuestaServidor = new Comunes.Respuesta().RespuestaServidor<long>(respuesta, nuevoCliente, TextoRespuesta.InsercionRegistro);
            return respuestaServidor;
        }
    }
}