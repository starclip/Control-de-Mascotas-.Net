using System.Collections.Generic;

namespace MascotasWeb.Entidades
{
    public class RespuestaCanton
    {
        public List<Canton> Datos { get; set; }
        public bool Resultado { get; set; }
        public string Error { get; set; }
    }
}
