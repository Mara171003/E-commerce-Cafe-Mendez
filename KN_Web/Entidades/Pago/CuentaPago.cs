using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Entidades.Pago
{
    public class CuentaPago
    {
        public int IdCuentaPago { get; set; }
        public int Consecutivo { get; set; }
        public int IdMetodoPago { get; set; }
        public string IdentificadorCuenta { get; set; }
        public string UltimosCuatroDigitos { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Predeterminado { get; set; }
    }
}