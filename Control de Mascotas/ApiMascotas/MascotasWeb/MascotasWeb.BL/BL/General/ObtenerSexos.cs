using MascotasWeb.Entidades;
using System.Collections.Generic;

namespace MascotasWeb.BL
{
    public class ObtenerSexos
    {
        public List<Sexo> Ejecute()
        {
            return new Servicios.ObtenerSexos().Ejecute();
        }
    }
}
