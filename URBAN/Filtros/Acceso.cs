using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace URBAN.Filtros
{
    public class Acceso : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Si session es nulo , entonces retorne al Login
            var usuario = HttpContext.Current.Session["Usuario"];

            if (usuario == null)
            {                                           //Controlado / Vista
                filterContext.Result = new RedirectResult("~/Loguin/Enter");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}