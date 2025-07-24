namespace KioscoAPI.DTOs
{
    
        public class ProductoDTO
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public int Stock { get; set; }
            public int StockMinimo { get; set; }
            public long CodigoBarra { get; set; }
            public bool Estado { get; set; }
            public string CategoriaNombre { get; set; }
            public string ProveedorNombre { get; set; }
        }

        public class ProductoCreateDTO
        {
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public int Stock { get; set; }
            public int StockMinimo { get; set; }
            public long CodigoBarra { get; set; }
            public bool Estado { get; set; }
            public int IdCategoria { get; set; }
            public int IdProveedor { get; set; }
        }
    public class ProductoUpdateDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public long CodigoBarra { get; set; }
        public bool Estado { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
    }
}
