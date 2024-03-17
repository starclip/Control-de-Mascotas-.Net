using CsvHelper.Configuration.Attributes;

namespace LectorExcel
{
    public class Canton
    {
        [Index(0)]
        public int Codigo { get; set; } 
        [Index(1)]
        public int Provincia { get; set; }
        [Index(2)]
        public string Nombre { get; set; }
    }
}
