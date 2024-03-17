using MascotasWeb.Entidades;
using System.Collections.Generic;

namespace MascotasWeb.BL
{
    public class ObtenerCantones
    {
        public List<Canton> Ejecute(long IdProvincia)
        {
            return new Servicios.ObtenerCantones().Ejecute(IdProvincia);
        }
    }
}
