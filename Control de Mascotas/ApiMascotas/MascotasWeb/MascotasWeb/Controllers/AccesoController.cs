using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MascotasWeb.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult IniciarSesion()
        {
            return View();
        }
    }
}