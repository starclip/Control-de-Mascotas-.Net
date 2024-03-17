using ApiMascotas.Entidades;
using ApiMascotas.Entidades.BD;
using System.Collections.Generic;

namespace ApiMascotas.DAL
{
    public class ValidarCedula
    {
        public bool Ejecute(Persona persona)
        {
            string procedimiento = "per.ValidarCedula";

            // Se definen los parámetros.
            List<Parametro> parametros = new List<Parametro>(){
                new Parametro("CEDULA", persona.Cedula)
            };

            // Se obtienen los clientes del SP.
            List<Dictionary<string, object>> datosResultado = BD.EjecutarSP(procedimiento, parametros);
            bool estado = true;

            // Recorre todos los datos y los convierte al objeto distrito.
            foreach(Dictionary<string, object> dato in datosResultado)
            {
                foreach(string llave in dato.Keys)
                {
                    if (llave == "Valido")
                        estado = (bool)dato[llave];
                }
            }

            return estado;
        }
    }
}
