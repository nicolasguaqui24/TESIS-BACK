
namespace KioscoAPI.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
    }

    public class CategoriaCreateDTO
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }


    }
}