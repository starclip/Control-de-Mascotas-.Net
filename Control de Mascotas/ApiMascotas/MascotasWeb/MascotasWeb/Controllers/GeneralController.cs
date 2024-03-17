using MascotasWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MascotasWeb.Controllers
{
    public class GeneralController : Controller
    {
        // Obtengo la lista de sexos del sistema.
        public ActionResult ObtenerSexos()
        {
            // Procedo a hacer la llamada para obtener los sexos del sistema.
            List<Sexo> listaSexos = new BL.ObtenerSexos().Ejecute();

            return Json(new
            {
                sexos = listaSexos
            }, JsonRequestBehavior.AllowGet);
        }

        // Obtengo la lista de provincias del sistema.
        public ActionResult ObtenerProvincias()
        {
            // Procedo a hacer la llamada para obtener las provincias del sistema.
            List<Provincia> listaProvincias = new BL.ObtenerProvincias().Ejecute();

            return Json(new
            {
                provincias = listaProvincias
            }, JsonRequestBehavior.AllowGet);
        }

        // Obtengo la lista de cantones del sistema.
        public ActionResult ObtenerCantones(long IdProvincia)
        {
            // Procedo a hacer la llamada para obtener los cantones del sistema.
            List<Canton> listaCantones = new BL.ObtenerCantones().Ejecute(IdProvincia);

            return Json(new
            {
                cantones = listaCantones
            }, JsonRequestBehavior.AllowGet);
        }

        // Obtengo la lista de distritos del sistema.
        public ActionResult ObtenerDistritos(long IdCanton)
        {
            // Procedo a hacer la llamada para obtener los distritos del sistema.
            List<Distrito> listaDistritos = new BL.ObtenerDistritos().Ejecute(IdCanton);

            return Json(new
            {
                distritos = listaDistritos
            }, JsonRequestBehavior.AllowGet);
        }

        // Realizo la validación de la cédula para verificar si ya se ingresó.
        public ActionResult ValidarCedula(string Cedula)
        {
            // Procedo a hacer la llamada
            bool resultado = new BL.ValidarCedula().Ejecute(Cedula);

            return Json(new
            {
                estado = resultado
            }, JsonRequestBehavior.AllowGet);
        }
    }
}