using MascotasWeb.Entidades;

namespace MascotasWeb.BL
{
    public class AgregarCliente
    {
        public long Ejecute(Cliente cliente)
        {
            return new Servicios.AgregarCliente().Ejecute(cliente);
        }
    }
}
