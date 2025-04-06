using iTextSharp.text;
using iTextSharp.text.pdf;
using KN_Web.BaseDatos;
using KN_Web.Entidades;
using KN_Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    public class ExternalController : Controller
    {
        // GET: External/InterfazVisita
        public ActionResult InterfazVisita()
        {
            return View();
        }
    }
}