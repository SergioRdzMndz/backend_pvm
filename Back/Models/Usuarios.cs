using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{
    public class Usuarios
    {
        private DateTime? fecha = DateTime.Now;
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string ContraseñaHash { get; set; }
        public string Rol {  get; set; }
        public DateTime? FechaRegistro { get => fecha; set => fecha = value; }
       

    }
}
