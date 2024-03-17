using ApiMascotas.BL;
using ApiMascotas.Entidades;
using System;
using System.Web.Http;


namespace ApiMascotas.Controllers
{
    public class GeneralController : ApiController
    {
        [HttpGet]
        [Route("api/General/ObtenerSexos")]
        public IHttpActionResult ObtenerSexos()
        {
            try
            {
                return Ok(new BL.ObtenerSexos().Ejecute());
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/General/ObtenerProvincias")]
        public IHttpActionResult ObtenerProvincias()
        {
            try
            {
                return Ok(new BL.ObtenerProvincias().Ejecute());
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/General/ObtenerCantones")]
        public IHttpActionResult ObtenerCantones(long IdProvincia)
        {
            try
            {
                Provincia provincia = new Provincia() { IdProvincia = IdProvincia };
                return Ok(new BL.ObtenerCantones().Ejecute(provincia));
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/General/ObtenerDistritos")]
        public IHttpActionResult ObtenerDistritos(long IdCanton)
        {
            try
            {
                Canton canton = new Canton() { IdCanton = IdCanton };
                return Ok(new BL.ObtenerDistritos().Ejecute(canton));
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/General/ValidarCedula")]
        public IHttpActionResult ValidarCedula(string Cedula)
        {
            try
            {
                Persona persona = new Persona() { Cedula = Cedula };
                return Ok(new BL.ValidarCedula().Ejecute(persona));
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }
    }
}