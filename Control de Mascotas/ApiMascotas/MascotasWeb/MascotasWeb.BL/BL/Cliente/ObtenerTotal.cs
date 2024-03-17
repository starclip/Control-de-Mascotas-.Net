using MascotasWeb.Entidades;

namespace MascotasWeb.BL
{
    public class ObtenerTotal
    {
        public int Ejecute(DatosFiltroCliente datosFiltro)
        {
            return new Servicios.ObtenerClientesTotal().Ejecute(datosFiltro);
        }
    }
}
