using KN_Web.Entidades;
using KN_Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    [FiltroAdmin]
    [FiltroSeguridad]
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class UsuarioController : Controller
    {
        UsuarioModel usuarioM = new UsuarioModel();
        RolModel rolM = new RolModel();

        [HttpGet]
        public ActionResult ConsultarUsuarios()
        {
            var respuesta = usuarioM.ConsultarUsuarios();
            return View(respuesta);
        }

        [HttpPost]
        public ActionResult CambiarEstadoUsuario(Usuario user)
        {
            var respuesta = usuarioM.CambiarEstadoUsuario(user);

            if (respuesta)
                return RedirectToAction("ConsultarUsuarios", "Usuario");
            else
            {
                ViewBag.msj = "No se ha podido inactivar la información del usuario";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarUsuario(int Consecutivo)
        {
            var respuesta = usuarioM.ConsultarUsuarioConsecutivo(Consecutivo);
            var roles = rolM.ConsultarRoles();

            List<SelectListItem> lstRoles = new List<SelectListItem>();
            foreach (var item in roles)
            {
                lstRoles.Add(new SelectListItem { Value = item.IdRol.ToString(), Text = item.NombreRol });
            }

            ViewBag.Roles = lstRoles;
            return View(respuesta);
        }

        [HttpPost]
        public ActionResult ActualizarUsuario(Usuario user)
        {
            var respuesta = usuarioM.ActualizarUsuario(user);

            if (respuesta)
                return RedirectToAction("ConsultarUsuarios", "Usuario");
            else
            {
                ViewBag.msj = "No se ha podido actualizar la información del usuario";
                return View();
            }
        }

        [HttpPost]
        public ActionResult EliminarUsuario(Usuario user)
        {
            var respuesta = usuarioM.EliminarUsuario(user.Consecutivo);
            if (respuesta)
                return RedirectToAction("ConsultarUsuarios", "Usuario");
            else
            {
                ViewBag.msj = "No se ha podido eliminar el usuario";
                var usuariosActuales = usuarioM.ConsultarUsuarios();
                return View("ConsultarUsuarios", usuariosActuales);
            }
        }
        [HttpGet]
        public ActionResult ConsultarPedidosUsuario(int idUsuario)
        {
            var pedidos = usuarioM.ObtenerPedidosPorUsuario(idUsuario);
            return PartialView("_PedidosUsuario", pedidos);
        }
    }
}