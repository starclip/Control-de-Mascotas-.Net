using System.Collections.Generic;

namespace MascotasWeb.Entidades
{
    public class RespuestaDistrito
    {
        public List<Distrito> Datos { get; set; }
        public bool Resultado { get; set; }
        public string Error { get; set; }
    }
}
