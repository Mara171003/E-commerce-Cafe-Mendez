namespace KN_Web.Models
{
    public class ProductoViewModel
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int Inventario { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int IdCategoria { get; set; }
        // Aquí se asigna directamente la descripción de la categoría que devuelve el SP
        public string Categoria { get; set; }
        public string presentacion { get; set; }

    }
}
