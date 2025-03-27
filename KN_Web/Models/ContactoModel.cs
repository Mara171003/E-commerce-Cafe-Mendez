using KN_Web.BaseDatos;
using System;

namespace KN_Web.Models
{
    public class ContactoModel
    {
        // Método para agregar un mensaje de contacto
        public bool AgregarContacto(KN_Web.BaseDatos.Contacto contacto)
        {
            int rowsAffected = 0;
            try
            {
                using (var context = new MARTES_BDEntities1())
                {
                    context.Contacto.Add(contacto);
                    rowsAffected = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o registro de errores
                throw ex;
            }
            return (rowsAffected > 0);
        }
    }
}
