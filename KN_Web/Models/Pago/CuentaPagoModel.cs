using KN_Web.BaseDatos;
using KN_Web.Entidades.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Models.Pago
{
    public class CuentaPagoModel
    {
        public bool GuardarCuentaPago(CuentaPago cuentaPago)
        {
            using (var context = new MARTES_BDEntities1())
            {
                var nuevaCuenta = new tCuentaPago
                {
                    Consecutivo = cuentaPago.Consecutivo,
                    IdMetodoPago = cuentaPago.IdMetodoPago,
                    IdentificadorCuenta = cuentaPago.IdentificadorCuenta,
                    UltimosCuatroDigitos = cuentaPago.UltimosCuatroDigitos,
                    FechaRegistro = DateTime.Now,
                    Predeterminado = false
                };
                context.tCuentaPago.Add(nuevaCuenta);
                return context.SaveChanges() > 0;
            }
        }
        public List<CuentaPago> ConsultarCuentasPago(int consecutivo)
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.tCuentaPago
                    .Where(cp => cp.Consecutivo == consecutivo)
                    .Select(cp => new CuentaPago
                    {
                        IdCuentaPago = cp.IdCuentaPago,
                        Consecutivo = cp.Consecutivo,
                        IdMetodoPago = cp.IdMetodoPago,
                        IdentificadorCuenta = cp.IdentificadorCuenta,
                        UltimosCuatroDigitos = cp.UltimosCuatroDigitos,
                        FechaRegistro = cp.FechaRegistro,
                        Predeterminado = cp.Predeterminado
                    }).ToList();
            }
        }
    }

}