using ApiMascotas.Entidades;
using System.Collections.Generic;

namespace ApiMascotas.BL
{
    public class ObtenerProvincias
    {
        public RespuestaServidor<dynamic> Ejecute()
        {
            List<Provincia> provincias = new DAL.ObtenerProvincias().Ejecute();
            RespuestaServidor<dynamic> respuestaServidor = new Comunes.Respuesta().RespuestaServidor<List<Provincia>>(Comunes.EnumRespuesta.Correcto, provincias, TextoRespuesta.ListaObtenida);
            return respuestaServidor;
        }
    }
}