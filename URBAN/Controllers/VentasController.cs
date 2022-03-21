using CAPAENTIDAD;
using CAPANEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using URBAN.Filtros;

namespace URBAN.Controllers
{
    public class VentasController : Controller
    {
        [Acceso]
        public ActionResult Index()
        {
            return View();
        }

        [Acceso]
        public JsonResult ListarReferencia()
        {
            VentasBL obj = new VentasBL();
            return Json(obj.ListarReferencia(), JsonRequestBehavior.AllowGet);
        }
        [Acceso]
        public JsonResult ListarReferencias()
        {
            VentasBL obj = new VentasBL();
            return Json(obj.ListarReferencias(), JsonRequestBehavior.AllowGet);
        }
        [Acceso]
        public JsonResult FiltrarReferencias(string descripcion)
        {
            VentasBL obj = new VentasBL();
            return Json(obj.FiltrarReferencias(descripcion), JsonRequestBehavior.AllowGet);
        }

        [Acceso]
        public JsonResult FiltarVentasWeb(string usuario)
        {
            VentasBL obj = new VentasBL();
            return Json(obj.FiltarVentasWeb(usuario), JsonRequestBehavior.AllowGet);
        }
        [Acceso]
        public JsonResult ListarVentasWeb()
        {
            VentasBL obj = new VentasBL();
            return Json(obj.ListarVentasWeb(), JsonRequestBehavior.AllowGet);
        }
        [Acceso]
        public JsonResult RecuperarRef(string descripcion)
        {
            VentasBL obj = new VentasBL();
            return Json(obj.RecuperarRef(descripcion), JsonRequestBehavior.AllowGet);
        }
        [Acceso]
        public JsonResult RecuperarVenta(int idweb)
        {
            VentasBL obj = new VentasBL();
            return Json(obj.RecuperarVenta(idweb), JsonRequestBehavior.AllowGet);
        }
        [Acceso]
        public int GuardarVenta(VentasCLS oVentaswebCLS)
        {
            VentasBL obj = new VentasBL();
            return obj.GuardarVenta(oVentaswebCLS);

        }

        [Acceso]
        public  int ActualizaReferencia(VentasCLS oVentaswebCLS)
        {
            VentasBL obj = new VentasBL();
            return obj.GuardarVenta(oVentaswebCLS);
        }
        [Acceso]
        public int ModificaReferencia(VentasCLS oVentaswebCLS)
        {
            VentasBL obj = new VentasBL();
            return obj.ModificaReferencia(oVentaswebCLS);
        }
        [Acceso]
        public int EliminarVenta(int idweb)
        {
            VentasBL obj = new VentasBL();
            return obj.EliminarVenta(idweb);
        }





    }
}