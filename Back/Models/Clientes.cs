using System.ComponentModel.DataAnnotations;

namespace Back.Models//SAUL ANDRE ALVARADO ESPARZA
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public ICollection<Ventas>? Ventas { get; set; }

    }
}
