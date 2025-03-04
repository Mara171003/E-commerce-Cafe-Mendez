using KN_Web.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Models
{
    public class RolModel
    {

        public List<tRol> ConsultarRoles()
        {
            using (var context = new MARTES_BDEntities1())
            {
                return (from x in context.tRol
                        select x).ToList();
            }
        }

    }
}