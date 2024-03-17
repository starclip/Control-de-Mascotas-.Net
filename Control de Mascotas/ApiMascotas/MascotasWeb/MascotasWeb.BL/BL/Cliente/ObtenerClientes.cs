using MascotasWeb.Entidades;
using System.Collections.Generic;

namespace MascotasWeb.BL
{
    public class ObtenerClientes
    {
        public List<Cliente> Ejecute(DatosFiltroCliente datosFiltro)
        {
            return new Servicios.ObtenerClientes().Ejecute(datosFiltro);
        }
    }
}
