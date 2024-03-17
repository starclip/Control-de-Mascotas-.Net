using MascotasWeb.Entidades;

namespace MascotasWeb.BL
{
    public class ObtenerCliente
    {
        public Cliente Ejecute(long IdCliente)
        {
            return new Servicios.ObtenerCliente().Ejecute(IdCliente);
        }
    }
}
