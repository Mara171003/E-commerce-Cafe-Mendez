using KN_Web.BaseDatos;
using KN_Web.Entidades.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Models.Pago
{
    public class TransaccionPagoModel
    {
        public bool RegistrarTransaccionPago(TransaccionPago transaccion)
        {
            using (var context = new MARTES_BDEntities1())
            {
                var nuevaTransaccion = new tTransaccionPago
                {
                    Consecutivo = transaccion.Consecutivo,
                    IdMaestro = transaccion.IdMaestro,
                    IdMetodoPago = transaccion.IdMetodoPago,
                    MontoTotal = transaccion.MontoTotal,
                    FechaPago = DateTime.Now,
                    EstadoPago = transaccion.EstadoPago,
                    CodigoTransaccion = transaccion.CodigoTransaccion,
                    Impuesto = transaccion.MontoTotal * 0.13m,
                    SubTotal = transaccion.MontoTotal / 1.13m
                };
                context.tTransaccionPago.Add(nuevaTransaccion);
                return context.SaveChanges() > 0;
            }
        }
        public List<TransaccionPago> ConsultarTransaccionesPago(int consecutivo)
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.tTransaccionPago
                    .Where(tp => tp.Consecutivo == consecutivo)
                    .OrderByDescending(tp => tp.FechaPago)
                    .Select(tp => new TransaccionPago
                    {
                        IdTransaccion = tp.IdTransaccion,
                        Consecutivo = tp.Consecutivo,
                        IdMaestro = tp.IdMaestro,
                        IdMetodoPago = tp.IdMetodoPago,
                        MontoTotal = tp.MontoTotal,
                        FechaPago = tp.FechaPago,
                        EstadoPago = tp.EstadoPago,
                        CodigoTransaccion = tp.CodigoTransaccion,
                        Impuesto = tp.Impuesto,
                        SubTotal = tp.SubTotal
                    }).ToList();
            }
        }
        public TransaccionPago ConsultarTransaccionPorId(int idTransaccion)
        {
            using (var context = new MARTES_BDEntities1())
            {
                var transaccion = context.tTransaccionPago.FirstOrDefault(tp => tp.IdTransaccion == idTransaccion);
                return transaccion == null ? null : new TransaccionPago
                {
                    IdTransaccion = transaccion.IdTransaccion,
                    Consecutivo = transaccion.Consecutivo,
                    IdMaestro = transaccion.IdMaestro,
                    IdMetodoPago = transaccion.IdMetodoPago,
                    MontoTotal = transaccion.MontoTotal,
                    FechaPago = transaccion.FechaPago,
                    EstadoPago = transaccion.EstadoPago,
                    CodigoTransaccion = transaccion.CodigoTransaccion,
                    Impuesto = transaccion.Impuesto,
                    SubTotal = transaccion.SubTotal
                };
            }
        }
    }
}