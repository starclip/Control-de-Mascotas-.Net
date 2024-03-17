using MascotasWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MascotasWeb.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        // Procede a Cargar la lista de clientes del sistema.
        public ActionResult CargarDatos()
        {
            // Se obtienen los datos de los filtros de la tabla.
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var inicio = Request.Form.GetValues("start").FirstOrDefault();
            var largo = Request.Form.GetValues("length").FirstOrDefault();
            var columnaOrdenamiento = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault()
                + "][name]").FirstOrDefault();
            var direccionOrdenamiento = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var busqueda = Request.Form.GetValues("search[value]").FirstOrDefault();

            // Se cálcula el número de página.
            int tamanoPagina = largo != null ? Convert.ToInt32(largo) : 0;
            int skip = inicio != null ? Convert.ToInt32(inicio) : 0;
            int pagina = skip / tamanoPagina;

            // Se define el objeto de estructura de los clientes filtros.
            DatosFiltroCliente datosFiltro = new DatosFiltroCliente()
            {
                NumeroPagina = pagina,
                CantidadRegistros = tamanoPagina,
                ColumnaOrdenamiento = columnaOrdenamiento,
                TipoOrdenamiento = direccionOrdenamiento,
                Nombre = busqueda
            };

            // Procedo a hacer la llamada para obtener los clientes del sistema.
            List<Cliente> listaClientes = new BL.ObtenerClientes().Ejecute(datosFiltro);

            // Obtengo la cantidad total de registros de la tabla.
            int totalRegistros = new BL.ObtenerTotal().Ejecute(datosFiltro);

            return Json(new 
            { 
                draw = draw,
                recordsFiltered = totalRegistros,
                recordsTotal = totalRegistros,
                data = listaClientes
            }, JsonRequestBehavior.AllowGet);
        }

        // Procede a crear un nuevo cliente.
        public ActionResult Agregar(Cliente cliente)
        {
            cliente.IdUsuarioCreacion = 1; // Se tiene que obtener del contexto general de la aplicación.
            return new JsonResult() { Data = new BL.AgregarCliente().Ejecute(cliente), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // Procede a actualizar la información del cliente.
        public ActionResult Editar(Cliente cliente)
        {
            cliente.IdUsuarioModificacion = 1; // Se tiene que obtener del contexto general de la aplicación.
            return new JsonResult() { Data = new BL.EditarCliente().Ejecute(cliente), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // Procede a obtener los datos del cliente.
        public ActionResult Obtener(long IdCliente)
        {
            return new JsonResult() { Data = new BL.ObtenerCliente().Ejecute(IdCliente), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // Procede a eliminar el cliente seleccionado.
        public ActionResult Eliminar(Cliente cliente)
        {
            cliente.IdUsuarioModificacion = 1; // Se tiene que obtener del contexto general de la aplicación.
            return new JsonResult() { Data = new BL.EliminarCliente().Ejecute(cliente), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}