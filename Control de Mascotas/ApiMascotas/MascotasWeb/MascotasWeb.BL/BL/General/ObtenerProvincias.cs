using MascotasWeb.Entidades;
using System.Collections.Generic;

namespace MascotasWeb.BL
{
    public class ObtenerProvincias
    {
        public List<Provincia> Ejecute()
        {
            return new Servicios.ObtenerProvincias().Ejecute();
        }
    }
}
