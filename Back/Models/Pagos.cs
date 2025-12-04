using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models //SERGIO RODRIGUEZ MENDOZA
{
    [Table("Pagos")]
    public class Pagos
    {
        private DateTime? fecha =DateTime.Now;
        [Key]
        public int IdPago { get; set; }
        [ForeignKey("Ventas")]
        public int IdVenta { get; set; }
        public Ventas? Venta { get; set; }
        public string MetodoPago { get; set; }
        public decimal Monto { get; set; }
        public DateTime? Fecha { get => fecha; set => fecha = value; }
    }
}