using MascotasWeb.Entidades;

namespace MascotasWeb.BL
{
    public class EliminarCliente
    {
        public bool Ejecute(Cliente cliente)
        {
            return new Servicios.EliminarCliente().Ejecute(cliente);
        }
    }
}
