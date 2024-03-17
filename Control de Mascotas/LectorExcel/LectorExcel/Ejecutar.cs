using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace LectorExcel
{
    class Ejecutar
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json");

            var configuration = builder.Build();

            // Defino los archivos de variables.
            string rutaArchivoProvincias = configuration["RutaArchivoProvincias"];
            string rutaArchivoCantones = configuration["RutaArchivoCantones"];
            string rutaArchivoDistritos = configuration["RutaArchivoDistritos"];
            string hileraConexion = configuration["HileraConexion"];
            string spLimpiar = configuration["SPLimpiar"];
            string spActualizar = configuration["SPActualizar"];

            Console.WriteLine("Iniciando aplicación.....");
            LectorExcel lector = new LectorExcel(rutaArchivoProvincias, rutaArchivoCantones, rutaArchivoDistritos);

            Console.WriteLine("Leyendo los archivos excel .....");
            // Obtengo las provincias, cantones y distritos.
            List<Provincia> provincias = lector.ObtenerProvincias();
            List<Canton> cantones = lector.ObtenerCantones();
            List<Distrito> distritos = lector.ObtenerDistritos();
            Console.WriteLine("Archivos excel leídos.....");

            // Obtengo la base de datos.
            BD baseDatos = new BD(hileraConexion);

            Console.WriteLine("Limpio todos los registros de la tabla temporal.....");

            // Limpio las tablas.
            baseDatos.EjecutarSP(spLimpiar, new List<Parametro>());

            Console.WriteLine("Cargo los registros en las tablas temporales.....");

            // Cargo las provincias, cantones y distritos en la tabla temporal.
            baseDatos.CargarProvincias(provincias);
            baseDatos.CargarCantones(cantones);
            baseDatos.CargarDistritos(distritos);

            Console.WriteLine("Registros cargados.");

            // Actualizo la tabla final.
            baseDatos.EjecutarSP(spActualizar, new List<Parametro>());
            Console.WriteLine("Actualización finalizada.....");

            Console.ReadLine();
        }
    }
}
