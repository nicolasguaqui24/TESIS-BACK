using System.ComponentModel.DataAnnotations.Schema;

namespace KioscoAPI.Models
{
    public class MovimientoStock
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string tipo { get; set; } // "Venta", "ConsumoInterno", "Ajuste", "Reposición", etc.
        public string observacion { get; set; }
        public int cantidad { get; set; }// Positivo (ingreso), Negativo (egreso)

        public int id_producto { get; set; }
        [ForeignKey("id_producto")]
        public Producto Producto { get; set;   }

        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario Usuario { get; set; }
        public int? id_movimientointerno { get; set; }
        [ForeignKey("id_movimientointerno")]
        public MovimientoInterno? MovimientoInterno { get; set; }
        public int? id_venta { get; set; }
        [ForeignKey("id_venta")]
        public Venta? Venta { get; set; }

    }
}
    