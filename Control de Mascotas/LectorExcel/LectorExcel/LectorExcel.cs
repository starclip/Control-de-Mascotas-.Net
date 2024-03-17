using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace LectorExcel
{
    public class LectorExcel
    {
        private readonly string rutaProvincias;
        private readonly string rutaCantones;
        private readonly string rutaDistritos;

        // Constructor del excel.
        public LectorExcel(string rutaProvincias, string rutaCantones, string rutaDistritos)
        {
            this.rutaProvincias = rutaProvincias;
            this.rutaCantones = rutaCantones;
            this.rutaDistritos = rutaDistritos;
        }

        // Función que permite obtener la lista de provincias.
        public List<Provincia> ObtenerProvincias()
        {
            List<Provincia> provincias;

            string rutaBase = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\.."));
            using (var reader = new StreamReader(Path.Combine(rutaBase, rutaProvincias)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                IEnumerable<Provincia> records = csv.GetRecords<Provincia>();
                provincias = records.ToList();
            }

            return provincias;
        }

        // Función que permite obtener la lista de cantones.
        public List<Canton> ObtenerCantones()
        {
            List<Canton> cantones;

            string rutaBase = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\.."));
            using (var reader = new StreamReader(Path.Combine(rutaBase, rutaCantones)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                IEnumerable<Canton> records = csv.GetRecords<Canton>();
                cantones = records.ToList();
            }

            return cantones;
        }

        // Función que permite obtener la lista de distritos.
        public List<Distrito> ObtenerDistritos()
        {
            List<Distrito> distritos;

            string rutaBase = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\.."));
            using (var reader = new StreamReader(Path.Combine(rutaBase, rutaDistritos)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                IEnumerable<Distrito> records = csv.GetRecords<Distrito>();
                distritos = records.ToList();
            }

            return distritos;
        }

    }
}
