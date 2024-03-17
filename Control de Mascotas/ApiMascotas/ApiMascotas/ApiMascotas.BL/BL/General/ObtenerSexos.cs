using ApiMascotas.Entidades;
using System.Collections.Generic;

namespace ApiMascotas.BL
{
    public class ObtenerSexos
    {
        public RespuestaServidor<dynamic> Ejecute()
        {
            List<Sexo> sexos = new DAL.ObtenerSexos().Ejecute();
            RespuestaServidor<dynamic> respuestaServidor = new Comunes.Respuesta().RespuestaServidor<List<Sexo>>(Comunes.EnumRespuesta.Correcto, sexos, TextoRespuesta.ListaObtenida);
            return respuestaServidor;
        }
    }
}