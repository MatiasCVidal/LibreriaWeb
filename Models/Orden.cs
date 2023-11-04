using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibreriaWeb.Models
{
    public class Orden
    {
        [Key]
        public int OrdenId { get; set; }
        public DateTime FechaOrden { get; set; }
        public int Cantidad { get; set; }

        /*
         * Relaciones
         */

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
