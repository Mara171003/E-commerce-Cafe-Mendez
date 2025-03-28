using KN_Web.Entidades.Pago;
using KN_Web.Models.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    public class ReciboPagoController : Controller
    {
        private ReciboPagoModel _reciboPagoModel;

        public ReciboPagoController()
        {
            _reciboPagoModel = new ReciboPagoModel();
        }

        [HttpPost]
        public ActionResult GenerarReciboPago(ReciboPago recibo)
        {
            try
            {
                bool resultado = _reciboPagoModel.GenerarReciboPago(recibo);
                return Json(new { Success = resultado });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult ConsultarReciboPorTransaccion(int idTransaccion)
        {
            try
            {
                var recibo = _reciboPagoModel.ConsultarReciboPorTransaccion(idTransaccion);
                return Json(recibo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
