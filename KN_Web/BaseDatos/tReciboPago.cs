//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KN_Web.BaseDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class tReciboPago
    {
        public int IdRecibo { get; set; }
        public int IdTransaccion { get; set; }
        public string RutaArchivoPDF { get; set; }
        public System.DateTime FechaGeneracion { get; set; }
    
        public virtual tTransaccionPago tTransaccionPago { get; set; }
    }
}
