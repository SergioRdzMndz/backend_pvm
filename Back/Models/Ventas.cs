using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models //SERGIO RODRIGUEZ MENDOZA
{
    public class Ventas
    {
        private DateTime? fecha = DateTime.Now; 

        [Key]
        public int IdVenta { get; set; }
        public DateTime? Fecha { get => fecha; set => fecha = value; }
        public decimal Total { get; set; }
        [ForeignKey("Clientes")]
        public int IdCliente { get; set; }
        public Clientes? Cliente { get; set; }
        [ForeignKey("Empleados")]
        public int IdEmpleado { get; set; }
        public Empleados? Empleado { get; set; }

        public string? Estado { get; set; } = "Pedido";
        
        
        public ICollection<Pagos>? Pago { get; set; }
        public ICollection<DetalleVenta>? DetallesVentas { get; set; }
    }
}