using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using URBAN.Filtros;
using URBAN.Models;
using CAPAENTIDAD;

namespace URBAN.Controllers
{
    public class LoguinController : Controller
    {
        // GET: Loguin
      
        public ActionResult Index()
        {
            return View();
        }
        [Acceso]
        public ActionResult CerrarSession()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Enter", "Loguin");
        }

        public ActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Enter(CAPAENTIDAD.UusariosCLS oUsuariosCLS)
        {
            string nombreusuario = oUsuariosCLS.usuario;
            string password = oUsuariosCLS.contraseña;
            SHA256Managed sha = new SHA256Managed();
            byte[] byteContra = Encoding.Default.GetBytes(password);
            byte[] byteContaCifrado = sha.ComputeHash(byteContra);
            string cadenaContraCifrada = BitConverter.ToString(byteContaCifrado).Replace("-", "");
            using (URBANEntities bd = new URBANEntities())
            {
                var Userdetails = bd.USUARIOS.Where(p => p.USUARIO == nombreusuario
                && p.CONTRASEÑA == cadenaContraCifrada).FirstOrDefault();
                if (Userdetails == null)
                {
                    ////Redireccionar al Login de nuevo
                    ViewBag.Message = "Usuario o Contraseña Incorrectos";
                    return View("Enter", Userdetails);
                }
                else
                {
                    if (Userdetails.TIPOUSUARIO == "V")
                    {
                        Session["Usuario"] = Userdetails.USUARIO;
                        return RedirectToAction("Index", "Ventas");
                    }
                    else if (Userdetails.TIPOUSUARIO == "B")
                    {
                        Session["Usuario"] = Userdetails.USUARIO;
                        return RedirectToAction("Index", "Ventas");
                    }
                    else if (Userdetails.TIPOUSUARIO == "A")
                    {
                        Session["Usuario"] = Userdetails.USUARIO;
                        return RedirectToAction("Index", "Ventas");
                    }
                    else 
                    {
                        ViewBag.Message = "Usuario Sin Permisos de Acceso";
                        return View("Enter", Userdetails);
                    }

                }


            }

        }






    }
}