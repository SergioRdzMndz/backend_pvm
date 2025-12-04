using System.ComponentModel.DataAnnotations;

namespace Back.Models//SAUL ANDRE ALVARADO ESPARZA
{
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public ICollection<Productos>? productos { get; set; }
    }
}