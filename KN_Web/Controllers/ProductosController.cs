using KN_Web.BaseDatos;
using KN_Web.Entidades;
using KN_Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    [FiltroAdmin]
    [FiltroSeguridad]
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class ProductosController : Controller
    {
        ProductoModel productoM = new ProductoModel();

        [HttpGet]
        public ActionResult ConsultarProductos()
        {
            var respuesta = productoM.ConsultarProductos();
            return View(respuesta);
        }

        [HttpGet]
        public ActionResult RegistrarProducto()
        {
            CargarCategorias();
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarProducto(HttpPostedFileBase ImagenProducto, tProducto prd)
        {
            var consecutivo = productoM.RegistrarProducto(prd);

            if (consecutivo > 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(ImagenProducto.FileName));
                string ruta = AppDomain.CurrentDomain.BaseDirectory + "ImgProductos\\" + consecutivo + extension;
                ImagenProducto.SaveAs(ruta);

                prd.IdProducto = consecutivo;
                prd.Imagen = "/ImgProductos/" + consecutivo + extension;
                productoM.ActualizarImagenProducto(prd);

                return RedirectToAction("ConsultarProductos", "Productos");
            }
            else
            {
                CargarCategorias();
                ViewBag.msj = "No se ha podido registrar la información del producto";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarProducto(int Consecutivo)
        {
            var respuesta = productoM.ConsultarProductoConsecutivo(Consecutivo);
            CargarCategorias();
            return View(respuesta);
        }

        [HttpPost]
        public ActionResult ActualizarProducto(HttpPostedFileBase ImagenProducto, tProducto prd)
        {
            var respuesta = productoM.ActualizarProducto(prd);

            if (respuesta)
            {
                if (ImagenProducto != null)
                {
                    string extension = Path.GetExtension(Path.GetFileName(ImagenProducto.FileName));
                    string ruta = AppDomain.CurrentDomain.BaseDirectory + "ImgProductos\\" + prd.IdProducto + extension;
                    ImagenProducto.SaveAs(ruta);

                    prd.Imagen = "/ImgProductos/" + prd.IdProducto + extension;
                    productoM.ActualizarImagenProducto(prd);
                }

                return RedirectToAction("ConsultarProductos", "Productos");
            }
            else
            {
                CargarCategorias();
                ViewBag.msj = "No se ha podido actualizar la información del producto";
                return View();
            }
        }

        private void CargarCategorias()
        {
            var categorias = productoM.ConsultarCategorias();

            List<SelectListItem> lstCategorias = new List<SelectListItem>();
            foreach (var item in categorias)
            {
                lstCategorias.Add(new SelectListItem { Value = item.IdCategoria.ToString(), Text = item.Descripcion });
            }

            ViewBag.Categorias = lstCategorias;
        }

    }
}