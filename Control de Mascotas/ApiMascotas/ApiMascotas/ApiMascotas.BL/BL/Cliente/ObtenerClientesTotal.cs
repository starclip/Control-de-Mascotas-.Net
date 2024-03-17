using ApiMascotas.Entidades;

namespace ApiMascotas.BL
{
    public class ObtenerClientesTotal
    {
        public RespuestaServidor<dynamic> Ejecute(DatosFiltroCliente datosFiltro)
        {
            int total = new DAL.ObtenerClientesTotal().Ejecute(datosFiltro);
            RespuestaServidor<dynamic> respuestaServidor = new Comunes.Respuesta().RespuestaServidor<int>(Comunes.EnumRespuesta.Correcto, total, TextoRespuesta.TotalRegistros);
            return respuestaServidor;
        }
    }
}