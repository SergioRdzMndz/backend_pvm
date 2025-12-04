using System.ComponentModel.DataAnnotations;

namespace Back.Models//SAUL ANDRE ALVARADO ESPARZA
{
    public class Categorias
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Productos>? productos { get; set; }
    }
}
