using CsvHelper.Configuration.Attributes;

namespace LectorExcel
{
    public class Distrito
    {
        [Index(0)]
        public int Codigo { get; set; } 
        [Index(1)]
        public int Canton { get; set; }
        [Index(2)]
        public string Nombre { get; set; }
    }
}
