using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMascotas.Entidades
{
    public class Cliente : Persona
    {
        public string Direccion { get; set; }
        public List<Mascota> Mascotas { get; set; }
        public long Distrito { get; set; }
        public long Canton { get; set; }
        public long Provincia { get; set; }
        public long Sexo { get; set; }
    }
}
