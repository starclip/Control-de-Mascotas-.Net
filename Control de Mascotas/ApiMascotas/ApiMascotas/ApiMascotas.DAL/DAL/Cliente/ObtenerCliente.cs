using ApiMascotas.Entidades;
using ApiMascotas.Entidades.BD;
using System.Collections.Generic;

namespace ApiMascotas.DAL
{
    public class ObtenerCliente
    {
        public List<Cliente> Ejecute(long IdCliente)
        {
            string procedimiento = "per.ObtenerCliente";

            // Se definen los parámetros.
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("IDCLIENTE", IdCliente)
            };

            // Se obtienen los clientes del SP.
            List<Dictionary<string, object>> datosResultado = BD.EjecutarSP(procedimiento, parametros);
            List<Cliente> clientes = new List<Cliente>();

            // Recorre todos los datos y los convierte al objeto cliente.
            foreach(Dictionary<string, object> dato in datosResultado)
            {
                // Creo el nuevo cliente.
                Cliente clienteNuevo = new Cliente()
                {
                    Id = long.Parse(dato["IDCLIENTE"].ToString()),
                    PrimerNombre = dato["PRIMERNOMBRE"].ToString(),
                    SegundoNombre = dato["SEGUNDONOMBRE"] != null ? dato["SEGUNDONOMBRE"].ToString() : null,
                    PrimerApellido = dato["PRIMERAPELLIDO"].ToString(),
                    SegundoApellido = dato["SEGUNDOAPELLIDO"].ToString(),
                    Cedula = dato["CEDULA"].ToString(),
                    FechaNacimiento = dato["FECHANACIMIENTO"].ToString(),
                    Telefono = dato["TELEFONO"] != null ? dato["TELEFONO"].ToString() : null,
                    Sexo = long.Parse(dato["SEXO"].ToString()),
                    Correo = dato["CORREO"] != null ? dato["CORREO"].ToString() : null,
                    Distrito = long.Parse(dato["DISTRITO"].ToString()),
                    Canton = long.Parse(dato["CANTON"].ToString()),
                    Provincia = long.Parse(dato["PROVINCIA"].ToString()),
                    Direccion = dato["DIRECCION"] != null ? dato["DIRECCION"].ToString() : null,
                    Cambios = dato["CAMBIOS"].ToString()
                };

                clientes.Add(clienteNuevo);
            }

            return clientes;
        }
    }
}
