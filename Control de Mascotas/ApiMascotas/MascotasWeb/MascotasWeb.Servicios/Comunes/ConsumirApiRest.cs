using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MascotasWeb.Servicios
{
    public static class ConsumirApiRest
    {
        // Método de ejecutar a la hora de consumir el api rest.
        public static string Ejecute(string metodo, string tipo, string contenido)
        {
            string servidor = ConfigurationManager.AppSettings["Servidor"];
            string url = servidor;
            var cliente = new RestClient(url);
            RestRequest request;

            if (tipo == TipoMetodo.Get)
            {
                if (!contenido.Equals(""))
                    metodo = metodo + contenido;

                request = new RestRequest(metodo, Method.Get);
            }
            else
            {
                request = new RestRequest(metodo, Method.Post);
            }

            if (tipo == TipoMetodo.Post)
                request.AddJsonBody(contenido);

            RestResponse respuesta = cliente.Execute(request);
            return respuesta.Content;
        }
    }
}
