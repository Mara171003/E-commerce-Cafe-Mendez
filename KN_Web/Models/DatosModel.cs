using KN_Web.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Models
{
    public class DatosModel
    {
        // Método para consultar ventas mensuales (REP-006 ejemplo proporcionado)
        public List<ConsultarVentasMensuales_Result> ConsultarDatosVentasMensuales()
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.ConsultarVentasMensuales().ToList();
            }
        }

        // Método para consultar ventas por producto (REP-006)
        public List<ConsultarVentasPorProducto_Result> ConsultarVentasPorProducto()
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.ConsultarVentasPorProducto().ToList();
            }
        }

        // Método para consultar rotación de inventario (REP-014)
        public List<ConsultarRotacionInventario_Result> ConsultarRotacionInventario()
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.ConsultarRotacionInventario().ToList();
            }
        }

        // Método para consultar ventas por categoría (REP-015)
        public List<ConsultarVentasPorCategoria_Result> ConsultarVentasPorCategoria()
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.ConsultarVentasPorCategoria().ToList();
            }
        }
    }
}