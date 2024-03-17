using ApiMascotas.Entidades;
using ApiMascotas.Entidades.BD;
using System.Collections.Generic;

namespace ApiMascotas.DAL
{
    public class EliminarCliente
    {
        public bool Ejecute(Cliente cliente)
        {
            string procedimiento = "per.EliminarCliente";

            // Se definen los parámetros.
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("IDCLIENTE", cliente.Id),
                new Parametro("IdVeterinarioActual", cliente.IdUsuarioModificacion)
            };

            // Se obtienen los clientes del SP.
            List<Dictionary<string, object>> datosResultado = BD.EjecutarSP(procedimiento, parametros);
            bool estado = false;

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
