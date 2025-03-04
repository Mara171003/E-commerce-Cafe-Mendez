using KN_Web.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Entidades
{
    public class CarritoGeneral
    {
        public int IdProducto { get; set; }
        public List<ConsultarCarrito_Result> DatosCarrito { get; set; }
    }
}