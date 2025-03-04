using KN_Web.BaseDatos;
using KN_Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_Web.Models
{
    public class FavoritosModel
    {
        // Método para agregar un favorito invocando el SP "AgregarFavorito"
        public bool AgregarFavorito(int idProducto)
        {
            int rowsAffected = 0;
            using (var context = new MARTES_BDEntities1())
            {
                // Se obtiene el consecutivo (ID del usuario) desde la sesión
                int consecutivo = int.Parse(HttpContext.Current.Session["ConsecutivoUsuario"].ToString());
                rowsAffected = context.AgregarFavorito(consecutivo, idProducto);
            }
            return (rowsAffected > 0);
        }

        // Método para consultar los favoritos del usuario invocando el SP "ConsultarFavoritos"
        public List<Favorito> ConsultarFavoritos()
        {
            using (var context = new MARTES_BDEntities1())
            {
                int consecutivo = int.Parse(HttpContext.Current.Session["ConsecutivoUsuario"].ToString());
                // Se obtiene el resultado del SP; este retorna un tipo generado (por ejemplo, ConsultarFavoritos_Result)
                var dbResults = context.ConsultarFavoritos(consecutivo).ToList();
                List<Favorito> favoritos = new List<Favorito>();

                // Se mapea cada registro al objeto Favorito de la capa de Entidades
                foreach (var item in dbResults)
                {
                    Favorito fav = new Favorito
                    {
                        IdFavorito = item.IdFavorito,
                        Consecutivo = item.Consecutivo,
                        IdProducto = item.IdProducto,
                        Descripcion = item.Descripcion,
                        Precio = item.Precio,
                        Fecha = item.Fecha,
                     
                    };
                    favoritos.Add(fav);
                }
                return favoritos;
            }
        }

        // Método para eliminar un favorito invocando el SP "EliminarFavorito"
        public bool EliminarFavorito(int idFavorito)
        {
            int rowsAffected = 0;
            using (var context = new MARTES_BDEntities1())
            {
                rowsAffected = context.EliminarFavorito(idFavorito);
            }
            return (rowsAffected > 0);
        }
    }
}

