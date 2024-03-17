using ApiMascotas.Entidades;
using System.Collections.Generic;

namespace ApiMascotas.BL
{
    public class ObtenerClientes
    {
        public RespuestaServidor<dynamic> Ejecute(DatosFiltroCliente datosFiltro)
        {
            List<Cliente> clientes = new DAL.ObtenerClientes().Ejecute(datosFiltro);
            RespuestaServidor<dynamic> respuestaServidor = new Comunes.Respuesta().RespuestaServidor<List<Cliente>>(Comunes.EnumRespuesta.Correcto, clientes, TextoRespuesta.ListaObtenida);
            return respuestaServidor;
        }
    }
}