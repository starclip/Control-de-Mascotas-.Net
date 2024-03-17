using ApiMascotas.Entidades;
using System.Collections.Generic;

namespace ApiMascotas.BL
{
    public class ObtenerCantones
    {
        public RespuestaServidor<dynamic> Ejecute(Provincia provincia)
        {
            List<Canton> cantones = new DAL.ObtenerCantones().Ejecute(provincia);
            RespuestaServidor<dynamic> respuestaServidor = new Comunes.Respuesta().RespuestaServidor<List<Canton>>(Comunes.EnumRespuesta.Correcto, cantones, TextoRespuesta.ListaObtenida);
            return respuestaServidor;
        }
    }
}