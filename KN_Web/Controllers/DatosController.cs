using KN_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    [FiltroAdmin]
    [FiltroSeguridad]
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class DatosController : Controller
    {
        DatosModel model = new DatosModel();

        [HttpGet]
        public ActionResult ConsultarDatos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConsultarDatosVentasPorProducto()
        {
            var datos = model.ConsultarVentasPorProducto();
            return Json(datos);
        }

        [HttpPost]
        public ActionResult ConsultarDatosRotacionInventario()
        {
            var datos = model.ConsultarRotacionInventario();
            return Json(datos);
        }

        [HttpPost]
        public ActionResult ConsultarDatosVentasPorCategoria()
        {
            var datos = model.ConsultarVentasPorCategoria();
            return Json(datos);
        }

        [HttpPost]
        public ActionResult ConsultarDatosVentasMensuales()
        {
            var datos = model.ConsultarDatosVentasMensuales();
            return Json(datos);
        }
    }
}
