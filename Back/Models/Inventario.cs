using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Back.Models//SERGIO RODRIGUEZ MENDOZA
{
    public class Inventario
    {
        private DateTime? fecha = DateTime.Now;
        [Key]
        public int IdMovimiento { get; set; }
        [ForeignKey("Inventario")]
        public int IdProducto { get; set; }
        public Productos? Producto { get; set; }
        public string TipoMovimiento { get; set; }
        public int Cantidad { get; set; }
        public DateTime? Fecha { get => fecha; set => fecha = value; }
    }
}