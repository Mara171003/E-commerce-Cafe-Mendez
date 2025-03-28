using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Entidades.Pago
{
    public class ReciboPago
    {
        public int IdRecibo { get; set; }
        public int IdTransaccion { get; set; }
        public string RutaArchivoPDF { get; set; }
        public DateTime FechaGeneracion { get; set; }
    }
}