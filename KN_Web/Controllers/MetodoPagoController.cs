using KN_Web.Entidades.Pago;
using KN_Web.Models.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    public class MetodoPagoController : Controller
    {
        private MetodoPagoModel _metodoPagoModel;

        public MetodoPagoController()
        {
            _metodoPagoModel = new MetodoPagoModel();
        }

        [HttpPost]
        public ActionResult InsertarMetodoPago(MetodoPago metodoPago)
        {
            try
            {
                bool resultado = _metodoPagoModel.InsertarMetodoPago(metodoPago);
                return Json(new { Success = resultado });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult ConsultarMetodosPago()
        {
            try
            {
                var metodosPago = _metodoPagoModel.ConsultarMetodosPago();
                return Json(metodosPago, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
