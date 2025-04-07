using KN_Web.BaseDatos;
using KN_Web.Entidades;
using KN_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    public class ExternalController : Controller


    {
        ProductoModel productoM = new ProductoModel();
        public ActionResult productos()
        {

            var productos = productoM.ConsultarProductos();
            return View(productos);
        }
        // GET: External/InterfazVisita
        public ActionResult InterfazVisita()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Message = "Your contact page.";

            return View();


        }

        public ActionResult Politicas()
        {
            ViewBag.Message = "Your contact page.";

            return View();


        }
    }
}

   
    


