
namespace KioscoAPI.Models
{
    public class Proveedore
    {
    public int id{get; set;}
    public string nombre {get; set;}
    public string telefono {get; set;}
    public string CBU {get; set;}   
    public int deuda {get; set;}
    public string email { get; set; }
    public string direccion { get; set; }
    public bool activo { get; set; }
    public string? observaciones { get; set; }

    


        public ICollection<Producto> Producto { get; set; } = new List<Producto>(); // Colección de productos asociados al proveedor
        public ICollection<PrecioProducto> PreciosProducto { get; set; } = new List<PrecioProducto>(); // Colección de precios asociados al proveedor
     
        /* POSIBLE CAMBIOS A MEJORAR
        // FK a Usuario
        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario Usuario { get; set; }
        // FK a PagoFiado
        public int id_pago_fiado { get; set; }
        [ForeignKey("id_pago_fiado")]
        public PagoFiado PagoFiado { get; set; }
            POSIBLES CAMBIOS A MEJORAR*/




    }
}
