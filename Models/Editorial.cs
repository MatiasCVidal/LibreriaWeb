using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibreriaWeb.Models
{
    public class Editorial
    {
        [Key]
        public int EditorialId { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

        /*
         * Relaciones
         */

        public virtual ICollection<Libro> Libros { get; set; }
    }
}