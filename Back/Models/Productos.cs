using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models//SERGIO RODRIGUEZ MENDOZA
{
    public class Productos
    {

        [Key]
        public int IdProducto { get; set; }
        [ForeignKey("Categorias")]
        public int IdCategoria { get; set; }
        public Categorias? Categoria { get; set; }
        [ForeignKey("Proveedores")]
        public int IdProveedor { get; set; }
        public Proveedores? Proveedor { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public ICollection<Inventario>? Inventarios { get; set; }
        public ICollection<DetalleVenta>? DetallesVenta { get; set; }

    }
}