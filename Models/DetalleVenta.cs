using System.ComponentModel.DataAnnotations.Schema;


namespace KioscoAPI.Models
{
    public class DetalleVenta
    {
        public int id{get; set;}
        public int cantidad{get; set;}
        public decimal precio_unitario{get; set;}
        public decimal subtotal{get; set;}

        // FK a producto 
        public int id_producto { get; set; }
        [ForeignKey("id_producto")]
        public Producto Producto { get; set; }

        // FK a venta
        public int id_venta { get; set; }
        [ForeignKey("id_venta")]
        public Venta Venta { get; set; }


    }
}
