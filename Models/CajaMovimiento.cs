using System.ComponentModel.DataAnnotations.Schema;

namespace KioscoAPI.Models
{
    public class CajaMovimiento
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string tipo { get; set; }
        public decimal monto { get; set; }
        public string descripcion { get; set; }


        // FK a Usuario
        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario Usuario { get; set; }
        //FK A venta
        public int? id_venta { get; set; }
        [ForeignKey("id_venta")]
        public Venta Venta { get; set; }

        public int? id_pago_fiado { get; set; }
        [ForeignKey("id_pago_fiado")]
        public PagoFiado PagoFiado { get; set; }
    }
}
