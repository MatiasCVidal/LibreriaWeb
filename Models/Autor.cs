using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibreriaWeb.Models
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }
        public string AutorNombre { get; set; }
        public string AutorApellido { get; set; }

        /*
         * Relaciones
         */

        public virtual ICollection<Libro> Libros { get; set; }
    }
}