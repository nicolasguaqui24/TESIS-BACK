namespace KioscoAPI.Models
{
    public class Categoria
    {
        public int id{get; set;}
        public string nombre{get; set;}
        public string descripcion{get; set;}
        public bool estado { get; set; }
        public string? imagen { get; set; } // URL o ruta de la imagen de la categoría

        // Colección de productos asociados a la categoría
        public ICollection<Producto> Producto { get; set; } = new List<Producto>(); // Colección de productos asociados a la categoría

      
            


    }
}
