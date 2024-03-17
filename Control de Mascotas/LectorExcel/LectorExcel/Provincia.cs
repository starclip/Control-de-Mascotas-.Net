using CsvHelper.Configuration.Attributes;

namespace LectorExcel
{
    public class Provincia
    {
        [Index(0)]
        public int Codigo { get; set; } 
        [Index(1)]
        public string Nombre { get; set; }
    }
}
