using MascotasWeb.Entidades;
using System.Collections.Generic;

namespace MascotasWeb.BL
{
    public class ObtenerDistritos
    {
        public List<Distrito> Ejecute(long IdCanton)
        {
            return new Servicios.ObtenerDistritos().Ejecute(IdCanton);
        }
    }
}
