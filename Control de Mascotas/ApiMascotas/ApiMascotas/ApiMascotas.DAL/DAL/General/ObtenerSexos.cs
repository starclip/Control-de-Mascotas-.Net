using ApiMascotas.Entidades;
using ApiMascotas.Entidades.BD;
using System.Collections.Generic;

namespace ApiMascotas.DAL
{
    public class ObtenerSexos
    {
        public List<Sexo> Ejecute()
        {
            string procedimiento = "sis.ObtenerSexos";

            // Se definen los parámetros.
            List<Parametro> parametros = new List<Parametro>(){};

            // Se obtienen los clientes del SP.
            List<Dictionary<string, object>> datosResultado = BD.EjecutarSP(procedimiento, parametros);
            List<Sexo> sexos = new List<Sexo>();

            // Recorre todos los datos y los convierte al objeto sexo.
            foreach(Dictionary<string, object> dato in datosResultado)
            {
                Sexo sexo = new Sexo()
                {
                    Id = long.Parse(dato["ID"].ToString()),
                    Codigo = dato["CODIGO"].ToString(),
                    Nombre = dato["NOMBRE"].ToString()
                };

                sexos.Add(sexo);
            }

            return sexos;
        }
    }
}
