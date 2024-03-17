using ApiMascotas.Entidades;
using System;
using System.Web.Http;

namespace ApiMascotas.Controllers
{
    public class ClienteController : ApiController
    {
        /*
         * Obtener Clientes
         * Parámetros: DatosFiltroCliente, son los datos de filtro de la tabla de la lista de clientes.
         * Retorna: Devuelve la lista de clientes.
         */
        [HttpPost]
        [Route("api/Cliente/ObtenerClientes")]
        public IHttpActionResult ObtenerClientes([FromBody] DatosFiltroCliente datosFiltro)
        {
            try
            {
                return Ok(new BL.ObtenerClientes().Ejecute(datosFiltro));
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
        }

        /*
         * Obtener Clientes
         * Parámetros: DatosFiltroCliente, son los datos de filtro de la tabla de la lista de clientes.
         * Retorna: Devuelve la cantidad total de clientes.
         */
        [HttpPost]
        [Route("api/Cliente/ObtenerTotal")]
        public IHttpActionResult ObtenerTotal([FromBody] DatosFiltroCliente datosFiltro)
        {
            try
            {
                return Ok(new BL.ObtenerClientesTotal().Ejecute(datosFiltro));
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        /*
         * Agregar Cliente
         * Parámetros: Cliente, se reciben los datos a guardar del nuevo cliente.
         * Retorna: El estatus de si se insertó exitosamente o no.
         */
        [HttpPost]
        [Route("api/Cliente/Agregar")]
        public IHttpActionResult Agregar([FromBody] Cliente cliente)
        {
            try
            {
                return Ok(new BL.AgregarCliente().Ejecute(cliente));
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        /*
         * Editar Cliente
         * Parámetros: Cliente, se reciben los datos a guardar del cliente.
         * Retorna: El estatus de si se actualizó exitosamente o no.
         */
        [HttpPost]
        [Route("api/Cliente/Editar")]
        public IHttpActionResult Editar([FromBody] Cliente cliente)
        {
            try
            {
                return Ok(new BL.EditarCliente().Ejecute(cliente));
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        /*
         * Obtener Cliente
         * Parámetros: Se recibe el identificador del cliente.
         * Retorna: El cliente con la información.
         */
        [HttpGet]
        [Route("api/Cliente/Obtener")]
        public IHttpActionResult Obtener(long IdCliente)
        {
            try
            {
                return Ok(new BL.ObtenerCliente().Ejecute(IdCliente));
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        /*
         * Eliminar Cliente
         * Parámetros: Se recibe el identificador del cliente.
         * Retorna: El estado de la operación.
         */
        [HttpPost]
        [Route("api/Cliente/Eliminar")]
        public IHttpActionResult Eliminar([FromBody] Cliente cliente)
        {
            try
            {
                return Ok(new BL.EliminarCliente().Ejecute(cliente));
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }
    }
}