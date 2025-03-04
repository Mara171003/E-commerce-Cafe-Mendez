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
    public class FavoritosController : Controller
    {
        FavoritosModel favoritosM = new FavoritosModel();

        // Acción para consultar la lista de favoritos del usuario
        public ActionResult ConsultarFavoritos()
        {
            var datos = favoritosM.ConsultarFavoritos();
            FavoritosGeneral favoritos = new FavoritosGeneral
            {
                DatosFavoritos = datos
            };
            return View(favoritos);
        }

        // Acción POST para agregar un favorito
        [HttpPost]
        public JsonResult AgregarFavorito(int idProducto)
        {
            bool resultado = favoritosM.AgregarFavorito(idProducto);
            return Json(new { success = resultado, message = resultado ? "Producto agregado a favoritos" : "No se pudo agregar a favoritos" });
        }


        // Acción POST para eliminar un favorito
        [HttpPost]
        public ActionResult EliminarFavorito(int idFavorito)
        {
            favoritosM.EliminarFavorito(idFavorito);
            return RedirectToAction("ConsultarFavoritos");
        }
    }

}
