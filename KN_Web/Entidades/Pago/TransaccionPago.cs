using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Entidades.Pago
{
    public class TransaccionPago
    {
        public int IdTransaccion { get; set; }
        public int Consecutivo { get; set; }
        public int IdMaestro { get; set; }
        public int IdMetodoPago { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaPago { get; set; }
        public string EstadoPago { get; set; }
        public string CodigoTransaccion { get; set; }
        public decimal Impuesto { get; set; }
        public decimal SubTotal { get; set; }
    }
}