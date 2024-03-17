using System.Collections.Generic;

namespace MascotasWeb.Entidades
{
    public class RespuestaSexo
    {
        public List<Sexo> Datos { get; set; }
        public bool Resultado { get; set; }
        public string Error { get; set; }
    }
}
