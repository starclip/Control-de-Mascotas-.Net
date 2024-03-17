using System.Collections.Generic;

namespace MascotasWeb.Entidades
{
    public class RespuestaProvincia
    {
        public List<Provincia> Datos { get; set; }
        public bool Resultado { get; set; }
        public string Error { get; set; }
    }
}
