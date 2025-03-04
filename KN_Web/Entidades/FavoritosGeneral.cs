using KN_Web.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Collections.Generic;

namespace KN_Web.Entidades
{
    public class FavoritosGeneral
    {
        // Lista que contendrá los registros de favoritos
        public List<Favorito> DatosFavoritos { get; set; }

        public FavoritosGeneral()
        {
            DatosFavoritos = new List<Favorito>();
        }
    }

    public class Favorito
    {
        public int IdFavorito { get; set; }
        public int Consecutivo { get; set; }  // Id del usuario
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
        // Opcional: Si deseas mostrar el nombre del usuario (retornado en el SP)
        public string Nombre { get; set; }
    }
}
