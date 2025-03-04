using KN_Web.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Models
{
    public class DatosModel
    {

        public List<ConsultarVentasMensuales_Result> ConsultarDatosVentasMensuales()
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.ConsultarVentasMensuales().ToList();
            }
        }
        

    }
}