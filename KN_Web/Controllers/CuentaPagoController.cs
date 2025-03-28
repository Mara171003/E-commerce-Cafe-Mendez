using KN_Web.Entidades.Pago;
using KN_Web.Models.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    public class CuentaPagoController : Controller
    {
        private CuentaPagoModel _cuentaPagoModel;

        public CuentaPagoController()
        {
            _cuentaPagoModel = new CuentaPagoModel();
        }

        [HttpPost]
        public ActionResult GuardarCuentaPago(CuentaPago cuentaPago)
        {
            try
            {
                bool resultado = _cuentaPagoModel.GuardarCuentaPago(cuentaPago);
                return Json(new { Success = resultado });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult ConsultarCuentasPago(int? consecutivo)
        {
            try
            {
                if (!consecutivo.HasValue)
                {
                    return Json(new { Success = false, Message = "El parámetro 'consecutivo' es obligatorio." }, JsonRequestBehavior.AllowGet);
                }

                var cuentasPago = _cuentaPagoModel.ConsultarCuentasPago(consecutivo.Value);
                return Json(cuentasPago, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
