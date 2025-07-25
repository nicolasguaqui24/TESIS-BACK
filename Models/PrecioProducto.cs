using System.ComponentModel.DataAnnotations.Schema;

namespace KioscoAPI.Models
{
    public class PrecioProducto
    { //decimal totalAjustado = detalle.Cantidad * producto.PrecioActual; (Esta es la formula para obtener el actualizado de precio)
        public int id { get; set; }
        public DateTime fecha_desde { get; set; }
        public decimal precio { get; set; }

        // FK a Producto    
        public int id_producto { get; set; }
        [ForeignKey("id_producto")]
        public Producto Producto { get; set; }
        // FK a Proveedor
        public int id_proveedor { get; set; }
        [ForeignKey("id_proveedor")]
        public Proveedore Proveedore { get; set; }

        // FK a Categoria
        public int id_categoria { get; set; }
        [ForeignKey("id_categoria")]
        public Categoria Categoria { get; set; }



        //POSIBLE CAMBIO A MEJORAR
        /*
        // FK a Usuario
        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario Usuario { get; set; }
        // FK a Proveedor   
        public int id_proveedor { get; set; }
        [ForeignKey("id_proveedor")]
        public Proveedor Proveedor { get; set; }
        // FK a Categoria
        public int id_categoria { get; set; }
        [ForeignKey("id_categoria")]
        public Categoria Categoria
        {
            get; set;


        }
        */
    }
    }
