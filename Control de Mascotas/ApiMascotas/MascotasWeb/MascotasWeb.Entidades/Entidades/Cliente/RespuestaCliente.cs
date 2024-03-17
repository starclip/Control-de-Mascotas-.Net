using System.Collections.Generic;

namespace MascotasWeb.Entidades
{
    public class RespuestaCliente
    {
        public List<Cliente> Datos { get; set; }
        public bool Resultado { get; set; }
        public string Error { get; set; }
    }
}
