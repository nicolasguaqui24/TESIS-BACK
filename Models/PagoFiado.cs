using System.ComponentModel.DataAnnotations.Schema;

namespace KioscoAPI.Models

{
    public class PagoFiado
    {
        public int id{get; set;}
        public decimal monto{get; set;}
        public DateTime fecha_pago{get; set;}


        // FK a Venta
        public int id_venta { get; set; }
        [ForeignKey("id_venta")]
            public Venta Venta { get; set; }

        //FK a Cliente
        public int id_cliente { get; set; }
        [ForeignKey("id_cliente")]
        public Cliente Cliente { get; set; }

        //Fk a Cuenta
        public int id_cuenta { get; set; }
        [ForeignKey("id_cuenta")]
        public Cuenta Cuenta { get; set; }

        //POSIBLE CAMBIO A MEJORAR
        /*
        // FK a Usuario
        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario Usuario { get; set; }
        */
    }
}
