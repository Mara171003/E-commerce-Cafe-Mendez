using KN_Web.BaseDatos;
using KN_Web.Entidades.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Models.Pago
{
    public class MetodoPagoModel
    {
        public bool InsertarMetodoPago(MetodoPago metodoPago)
        {
            using (var context = new MARTES_BDEntities1())
            {
                var nuevoMetodo = new tMetodoPago
                {
                    Nombre = metodoPago.Nombre,
                    Descripcion = metodoPago.Descripcion
                };
                context.tMetodoPago.Add(nuevoMetodo);
                return context.SaveChanges() > 0;
            }
        }
        public List<MetodoPago> ConsultarMetodosPago()
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.tMetodoPago.Select(m => new MetodoPago
                {
                    IdMetodoPago = m.IdMetodoPago,
                    Nombre = m.Nombre,
                    Descripcion = m.Descripcion
                }).ToList();
            }
        }
    }
}