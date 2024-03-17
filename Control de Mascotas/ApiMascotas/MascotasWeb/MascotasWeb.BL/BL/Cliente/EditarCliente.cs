using MascotasWeb.Entidades;

namespace MascotasWeb.BL
{
    public class EditarCliente
    {
        public bool Ejecute(Cliente cliente)
        {
            return new Servicios.EditarCliente().Ejecute(cliente);
        }
    }
}
