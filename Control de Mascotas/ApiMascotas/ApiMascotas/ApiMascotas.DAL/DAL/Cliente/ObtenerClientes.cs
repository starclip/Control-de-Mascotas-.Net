using ApiMascotas.Entidades;
using ApiMascotas.Entidades.BD;
using System.Collections.Generic;

namespace ApiMascotas.DAL
{
    public class ObtenerClientes
    {
        public List<Cliente> Ejecute(DatosFiltroCliente datosFiltro)
        {
            string procedimiento = "per.ObtenerClientes";

            // Se definen los parámetros.
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("Pagina", datosFiltro.NumeroPagina),
                new Parametro("TotalRegistros", datosFiltro.CantidadRegistros),
                new Parametro("ColumnaOrdenamiento", datosFiltro.ColumnaOrdenamiento),
                new Parametro("TipoOrdenamiento", datosFiltro.TipoOrdenamiento),
                new Parametro("Nombre", datosFiltro.Nombre)
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
                    Cedula = dato["CEDULA"].ToString(),
                    Nombre = dato["NOMBRE"].ToString(),
                    Telefono = dato["TELEFONO"] != null ? dato["TELEFONO"].ToString() : null,
                    Correo = dato["CORREO"] != null ? dato["CORREO"].ToString() : null,
                    Direccion = dato["DIRECCION"] != null ? dato["DIRECCION"].ToString() : null,
                    Cambios = dato["CAMBIOS"].ToString()
                };

                // Obtengo la lista de mascotas.
                string[] mascotas = dato["MASCOTAS"] != null ? (dato["MASCOTAS"].ToString()).Split(',') : new string[] { };
                List<Mascota> listaMascotas = new List<Mascota>();

                foreach (string mascota in mascotas)
                    listaMascotas.Add(new Mascota() { Nombre = mascota });

                clienteNuevo.Mascotas = listaMascotas;
                clientes.Add(clienteNuevo);
            }

            return clientes;
        }
    }
}
