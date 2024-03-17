using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMascotas.Entidades
{
    public class RespuestaServidor<T> where T: class
    {
        public T Datos { get; set; }
        public String Respuesta { get; set; }
        public int CodigoRespuesta { get; set; }
    }
}
