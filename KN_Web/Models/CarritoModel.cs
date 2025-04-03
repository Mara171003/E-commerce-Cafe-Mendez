using KN_Web.BaseDatos;
using KN_Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Models
{
    public class CarritoModel
    {
        public bool RegistrarCarrito(int IdProducto, int Cantidad)
        {
            var rowsAffected = 0;
        
            using (var context = new MARTES_BDEntities1())
            {
                int Consecutivo = int.Parse(HttpContext.Current.Session["ConsecutivoUsuario"].ToString());
                rowsAffected = context.RegistrarCarrito(Consecutivo, IdProducto, Cantidad);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public List<ConsultarCarrito_Result> ConsultarCarrito()
        {
            using (var context = new MARTES_BDEntities1())
            {
                int Consecutivo = int.Parse(HttpContext.Current.Session["ConsecutivoUsuario"].ToString());
                return context.ConsultarCarrito(Consecutivo).ToList();
            }
        }

        public List<ValidarExistencias_Result> ValidarExistencias()
        {
            using (var context = new MARTES_BDEntities1())
            {
                int Consecutivo = int.Parse(HttpContext.Current.Session["ConsecutivoUsuario"].ToString());
                return context.ValidarExistencias(Consecutivo).ToList();
            }
        }

        public bool PagarCarrito()
        {
            var rowsAffected = 0;

            using (var context = new MARTES_BDEntities1())
            {
                int Consecutivo = int.Parse(HttpContext.Current.Session["ConsecutivoUsuario"].ToString());
                rowsAffected = context.PagarCarrito(Consecutivo);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public List<ConsultarFacturas_Result> ConsultarFacturas()
        {
            using (var context = new MARTES_BDEntities1())
            {
                int Consecutivo = int.Parse(HttpContext.Current.Session["ConsecutivoUsuario"].ToString());
                return context.ConsultarFacturas(Consecutivo).ToList();
            }
        }

        public List<ConsultarDetalleFactura_Result> ConsultarDetalleFactura(int Consecutivo)
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.ConsultarDetalleFactura(Consecutivo).ToList();
            }
        }

        public bool EliminarProductoCarrito(int IdProducto)
        {
            var rowsAffected = 0;

            using (var context = new MARTES_BDEntities1())
            {
                int Consecutivo = int.Parse(HttpContext.Current.Session["ConsecutivoUsuario"].ToString());
                rowsAffected = context.EliminarProductoCarrito(Consecutivo, IdProducto);
            }

            return (rowsAffected > 0 ? true : false);
        }
        public ObtenerFacturaPorId_Result ObtenerFacturaPorId(int idFactura)
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.ObtenerFacturaPorId(idFactura).FirstOrDefault();
            }
        }
    }
}