using KN_Web.BaseDatos;
using KN_Web.Entidades;
using System.Collections.Generic;
using System.Data.Entity; // Asegúrate de tener esta using statement
using System.Data.SqlClient;
using System.Linq;

namespace KN_Web.Models
{
    public class ProductoModel
    {
        public List<tProducto> ConsultarProductos()
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.tProducto.Include("tCategoria").ToList();
            }
        }

        public tProducto ConsultarProductoConsecutivo(int Consecutivo)
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.tProducto.Where(x => x.IdProducto == Consecutivo).FirstOrDefault();
            }
        }

        public List<tCategoria> ConsultarCategorias()
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.tCategoria.ToList();
            }
        }

        public List<ProductoViewModel> FiltrarProductosPorCategoria(int idCategoria)
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.Database.SqlQuery<ProductoViewModel>(
                    "EXEC sp_FiltrarProductosPorCategoria @IdCategoria",
                    new SqlParameter("@IdCategoria", idCategoria)
                ).ToList();
            }
        }

        // Opcional: Si necesitas mostrar todos los productos en el filtro, puedes proyectar desde tProducto:
        public List<ProductoViewModel> ConsultarProductosViewModel()
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.tProducto
                    .Include("tCategoria")
                    .ToList()
                    .Select(p => new ProductoViewModel
                    {
                        IdProducto = p.IdProducto,
                        Descripcion = p.Descripcion,
                        Inventario = p.Inventario,
                        Precio = p.Precio,
                        Imagen = p.Imagen,
                        IdCategoria = p.IdCategoria,
                        Categoria = p.tCategoria != null ? p.tCategoria.Descripcion : "",
                        presentacion = p.presentacion
                    })
                    .ToList();
            }
        }

        public int RegistrarProducto(tProducto prd)
        {
            using (var context = new MARTES_BDEntities1())
            {
                var consecutivo = context.RegistrarProducto(prd.Descripcion, prd.Inventario, prd.Precio, prd.Imagen, prd.IdCategoria).FirstOrDefault();
                return int.Parse(consecutivo.ToString());
            }
        }

        public bool ActualizarImagenProducto(tProducto prd)
        {
            var rowsAffected = 0;

            using (var context = new MARTES_BDEntities1())
            {
                rowsAffected = context.ActualizarImagenProducto(prd.IdProducto, prd.Imagen);
            }

            return (rowsAffected > 0);
        }

        public bool ActualizarProducto(tProducto prd)
        {
            var rowsAffected = 0;

            using (var context = new MARTES_BDEntities1())
            {
                rowsAffected = context.ActualizarProducto(
                    prd.Descripcion,
                    prd.Inventario,
                    prd.Precio,
                    prd.Imagen,
                    prd.IdCategoria,
                    prd.IdProducto,
                    prd.presentacion // Se agrega el valor de Presentacion
                );
            }

            return (rowsAffected > 0);
        }

        // Función para eliminar producto usando el Stored Procedure a través de Entity Framework
        public bool EliminarProducto(int idProducto)
        {
            using (var context = new MARTES_BDEntities1())
            {
                var resultado = context.Database.ExecuteSqlCommand("EXEC sp_EliminarProducto @IdProducto",
                    new SqlParameter("@IdProducto", idProducto));
                return resultado > 0;
            }
        }
    }
}