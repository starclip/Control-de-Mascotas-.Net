using ApiMascotas.Entidades;
using System.Collections.Generic;

namespace ApiMascotas.BL
{
    public class ObtenerDistritos
    {
        public RespuestaServidor<dynamic> Ejecute(Canton canton)
        {
            List<Distrito> distritos = new DAL.ObtenerDistritos().Ejecute(canton);
            RespuestaServidor<dynamic> respuestaServidor = new Comunes.Respuesta().RespuestaServidor<List<Distrito>>(Comunes.EnumRespuesta.Correcto, distritos, TextoRespuesta.ListaObtenida);
            return respuestaServidor;
        }
    }
}