using System.ComponentModel.DataAnnotations.Schema;

namespace KioscoAPI.Models
{
    public class Producto
    {
        public int id {get; set;}
        public string nombre{get; set;}
        public string descripcion{get; set;}
        public decimal precio {get; set;}
        public int stock {get; set;}
        public int stock_minimo {get; set;}
        public int codigo_barra{get; set;}
        public bool estado{get; set;}

        // FK a Categoria
        public int id_categoria { get; set; }

        [ForeignKey("id_categoria")]
        public Categoria Categoria { get; set; }

        // FK a Proveedor
        public int id_proveedor { get; set; }

        [ForeignKey("id_proveedor")]
        public Proveedore Proveedore { get; set; }

        //FK a DetalleVenta
        public ICollection<DetalleVenta> DetalleVenta { get; set; }
        //FK a PrecioProducto
        public ICollection<PrecioProducto> PreciosProducto { get; set; }

        public ICollection<MovimientoStock> MovimientoStock { get; set; }
        

    }
}
