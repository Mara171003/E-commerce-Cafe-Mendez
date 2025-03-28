using KN_Web.BaseDatos;
using KN_Web.Entidades.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Models.Pago
{
    public class ReciboPagoModel
    {
        public bool GenerarReciboPago(ReciboPago recibo)
        {
            using (var context = new MARTES_BDEntities1())
            {
                var nuevoRecibo = new tReciboPago
                {
                    IdTransaccion = recibo.IdTransaccion,
                    RutaArchivoPDF = recibo.RutaArchivoPDF,
                    FechaGeneracion = DateTime.Now
                };
                context.tReciboPago.Add(nuevoRecibo);
                return context.SaveChanges() > 0;
            }
        }
        public ReciboPago ConsultarReciboPorTransaccion(int idTransaccion)
        {
            using (var context = new MARTES_BDEntities1())
            {
                var recibo = context.tReciboPago.FirstOrDefault(r => r.IdTransaccion == idTransaccion);
                return recibo == null ? null : new ReciboPago
                {
                    IdRecibo = recibo.IdRecibo,
                    IdTransaccion = recibo.IdTransaccion,
                    RutaArchivoPDF = recibo.RutaArchivoPDF,
                    FechaGeneracion = recibo.FechaGeneracion
                };
            }
        }
    }
}