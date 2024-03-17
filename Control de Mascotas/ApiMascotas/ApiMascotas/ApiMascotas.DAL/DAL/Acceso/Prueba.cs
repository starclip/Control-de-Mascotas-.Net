using ApiMascotas.Entidades.BD;
using ApiMascotas.Entidades;
using System.Collections.Generic;

namespace ApiMascotas.DAL.Prueba
{
    public class Prueba
    {
        public RespuestaPrueba Ejecute(string parametro1, int parametro2, bool parametro3, long parametro4)
        {
            List<Dictionary<string, object>> resultados;
            RespuestaPrueba respuestaPrueba;
            string SP = "[sis].[ObtenerDatos]";

            // Se definen la lista de parámetros.
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("Parametro1", parametro1),
                new Parametro("Parametro2", parametro2),
                new Parametro("Parametro3", parametro3),
                new Parametro("Parametro4", parametro4),
            };

            // Se llama a ejecutar la BD.
            resultados = BD.EjecutarSP(SP, parametros);

            Dictionary<string, object> datoResultado = resultados[0];

            // Defino los datos de respuesta de prueba.
            respuestaPrueba = new RespuestaPrueba();
            respuestaPrueba.ParametroRetorno = datoResultado["ParametroRetorno"].ToString();
            respuestaPrueba.SegundoRetorno = (int) datoResultado["SegundoRetorno"];
            respuestaPrueba.TercerRetorno = (bool) datoResultado["TercerRetorno"];
            respuestaPrueba.CuartoRetorno = (decimal) datoResultado["CuartoRetorno"];
            

            return respuestaPrueba;
        }
    }
}
