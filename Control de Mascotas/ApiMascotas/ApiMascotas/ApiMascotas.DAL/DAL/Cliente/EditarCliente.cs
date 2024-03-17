using ApiMascotas.Entidades;
using ApiMascotas.Entidades.BD;
using System.Collections.Generic;
using System.Globalization;

namespace ApiMascotas.DAL
{
    public class EditarCliente
    {
        public bool Ejecute(Cliente cliente)
        {
            string procedimiento = "per.EditarCliente";
            bool estado = false;
            System.DateTime FechaNacimiento = System.DateTime.ParseExact(cliente.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // Se definen los parámetros.
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("IdCliente", cliente.Id),
                new Parametro("PrimerNombre", cliente.PrimerNombre),
                new Parametro("SegundoNombre", cliente.SegundoNombre),
                new Parametro("PrimerApellido", cliente.PrimerApellido),
                new Parametro("SegundoApellido", cliente.SegundoApellido),
                new Parametro("Cedula", cliente.Cedula),
                new Parametro("FechaNacimiento", FechaNacimiento),
                new Parametro("Telefono", cliente.Telefono),
                new Parametro("Sexo", cliente.Sexo),
                new Parametro("Correo", cliente.Correo),
                new Parametro("Distrito", cliente.Distrito),
                new Parametro("DireccionExacta", cliente.Direccion),
                new Parametro("IdVeterinarioActual", cliente.IdUsuarioModificacion)
            };

            // Se obtienen los clientes del SP.
            List<Dictionary<string, object>> datosResultado = BD.EjecutarSP(procedimiento, parametros);

            // Recorre todos los datos y los convierte al objeto cliente.
            foreach(Dictionary<string, object> dato in datosResultado)
            {
                foreach (string llave in dato.Keys)
                {
                    if (llave == "ESTADO")
                        estado = (bool)dato[llave];
                }
            }

            return estado;
        }
    }
}
