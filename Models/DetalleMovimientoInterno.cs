using System.ComponentModel.DataAnnotations.Schema;

namespace KioscoAPI.Models
{
    public class DetalleMovimientoInterno
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public decimal preciocosto { get; set; }

        // FK al MovimientoInterno
        public int id_movimientointerno{ get; set; }
        [ForeignKey("id_movimientointerno")]
        public MovimientoInterno MovimientoInterno { get; set; }

        // FK a Producto

        public int id_producto { get; set; }
        [ForeignKey("id_producto")]
        public Producto Producto { get; set; }

       
     
    }
}