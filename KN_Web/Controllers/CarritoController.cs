using KN_Web.BaseDatos;
using KN_Web.Entidades;
using KN_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    public class CarritoController : Controller
    {
        CarritoModel carritoM = new CarritoModel();

        [HttpGet]
        public ActionResult ConsultarCarrito()
        {
            var datos = carritoM.ConsultarCarrito();

            //Se setea el objeto general que tiene el id del producto necesario del modal y la lista actual del carrito
            CarritoGeneral carrito = new CarritoGeneral();
            carrito.DatosCarrito = datos;

            Session["Cantidad"] = datos.Sum(c => c.Cantidad);
            Session["SubTotal"] = datos.Sum(c => c.SubTotal);
            Session["Total"] = datos.Sum(c => c.Total);

            return View(carrito);
        }

        [HttpPost]
        public ActionResult PagarCarrito()
        {
            var datos = carritoM.ValidarExistencias();

            //Es porque no hay existencias inclumpliendose
            if (datos.Count() <= 0)
            {
                carritoM.PagarCarrito();
                return RedirectToAction("Home", "Login");
            }
            else
            {
                var productosEnCarrito = carritoM.ConsultarCarrito();

                //Se setea el objeto general que tiene el id del producto necesario del modal y la lista actual del carrito
                CarritoGeneral carrito = new CarritoGeneral();
                carrito.DatosCarrito = productosEnCarrito;

                var mensaje = "";
                var contador = 0;
                foreach (var item in datos)
                {
                    if (contador != datos.Count() - 2)
                        mensaje += item.Descripcion + ", ";
                    else
                        mensaje += item.Descripcion + " y ";
                    
                    contador += 1;
                }

                ViewBag.msj = "No se puede realizar el pago, los productos " + mensaje + "superan la cantidad en el inventario disponible";
                return View("ConsultarCarrito", carrito);
            }
        }

        [HttpGet]
        public ActionResult ConsultarFacturas()
        {
            var datos = carritoM.ConsultarFacturas();
            return View(datos);
        }

        [HttpGet]
        public ActionResult ConsultarDetalleFactura(int Consecutivo)
        {
            var datos = carritoM.ConsultarDetalleFactura(Consecutivo);
            return View(datos);
        }

        [HttpPost]
        public ActionResult EliminarProductoCarrito(CarritoGeneral ent)
        {
            carritoM.EliminarProductoCarrito(ent.IdProducto);
            return RedirectToAction("ConsultarCarrito", "Carrito");
        }

        [HttpPost]
        public ActionResult ActualizarCantidadCarrito(int IdProducto, int Cantidad)
        {
            try
            {
                // Primero eliminar el producto del carrito
                carritoM.EliminarProductoCarrito(IdProducto);

                // Luego agregar el producto con la nueva cantidad
                bool resultado = carritoM.RegistrarCarrito(IdProducto, Cantidad);

                if (resultado)
                {
                    // Actualizar la sesión
                    var datos = carritoM.ConsultarCarrito();
                    Session["Cantidad"] = datos.Sum(c => c.Cantidad);
                    Session["SubTotal"] = datos.Sum(c => c.SubTotal);
                    Session["Total"] = datos.Sum(c => c.Total);
                }

                return Json(new { success = resultado, message = resultado ? "Cantidad actualizada correctamente" : "No se pudo actualizar la cantidad" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }
    }
}