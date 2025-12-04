using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models //SERGIO RODRIGUEZ MENDOZA
{
    [Table("DetalleVenta")]
    public class DetalleVenta
    {
        [Key]
        public int IdDetalle { get; set; }
        [ForeignKey("Ventas")]
        public int IdVenta { get; set; }
        public Ventas? Venta { get; set; }
        [ForeignKey("Productos")]
        public int IdProducto { get; set; }
        public Productos? Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

    }
}
