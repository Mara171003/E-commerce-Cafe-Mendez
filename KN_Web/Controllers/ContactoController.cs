using KN_Web.Models;
using KN_Web.Entidades; // Aqu� se utiliza ContactoView
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    public class ContactoController : Controller
    {
        private ContactoModel contactoModel = new ContactoModel();

        // Acci�n GET: Muestra el formulario de contacto
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactoView contactoView)
        {
            if (ModelState.IsValid)
            {
                // Mapeamos ContactoView a la entidad de persistencia
                var contactoBD = new KN_Web.BaseDatos.Contacto
                {
                    Nombre = contactoView.Nombre,
                    Email = contactoView.Email,
                    Telefono = contactoView.Telefono,
                    Mensaje = contactoView.Mensaje
                };

                bool resultado = contactoModel.AgregarContacto(contactoBD);
                if (resultado)
                {
                    // Redirigir a la acci�n "About" en el controlador "Login"
                    return RedirectToAction("Contact", "Login");
                }
                else
                {
                    ViewBag.Message = "Ocurri� un error al enviar tu mensaje. Int�ntalo de nuevo.";
                }
            }
            return View(); // Si hay errores, se vuelve a mostrar el formulario
        }
    }
}
