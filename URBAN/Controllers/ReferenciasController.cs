using CAPANEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using URBAN.Filtros;

namespace URBAN.Controllers
{
    public class ReferenciasController : Controller
    {
        // GET: Referencias
        [Acceso]
        public ActionResult Index()
        {
            return View();
        }
   
        [Acceso]
        public JsonResult ListarReferencias()
        {
            ReferenciasBL obj = new ReferenciasBL();
            return Json(obj.ListarReferencias(), JsonRequestBehavior.AllowGet);
        }
        [Acceso]
        public JsonResult FiltrarReferencias(string descripcion)
        {
            ReferenciasBL obj = new ReferenciasBL();
            return Json(obj.FiltrarReferencias(descripcion), JsonRequestBehavior.AllowGet);
        }





    }
}