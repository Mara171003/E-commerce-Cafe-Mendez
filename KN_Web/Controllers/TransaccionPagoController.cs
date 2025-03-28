using KN_Web.Entidades.Pago;
using KN_Web.Models.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    public class TransaccionPagoController : Controller
    {
        private TransaccionPagoModel _transaccionPagoModel;

        public TransaccionPagoController()
        {
            _transaccionPagoModel = new TransaccionPagoModel();
        }

        [HttpPost]
        public ActionResult RegistrarTransaccionPago(TransaccionPago transaccion)
        {
            try
            {
                bool resultado = _transaccionPagoModel.RegistrarTransaccionPago(transaccion);
                return Json(new { Success = resultado });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult ConsultarTransaccionesPago(int consecutivo)
        {
            try
            {
                var transacciones = _transaccionPagoModel.ConsultarTransaccionesPago(consecutivo);
                return Json(transacciones, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult ConsultarTransaccionPorId(int idTransaccion)
        {
            try
            {
                var transaccion = _transaccionPagoModel.ConsultarTransaccionPorId(idTransaccion);
                return Json(transaccion, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
