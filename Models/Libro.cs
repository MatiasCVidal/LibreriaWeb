using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaWeb.Models
{
    public class Libro
    {
        [Key]
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public int CantidadPaginas { get; set; }
        public float Precio { get; set; }

        [EnumDataType(typeof(Genero))]
        public Genero Genero { get; set; }
        
        /*
         * Relaciones
         */

        public int AutorId { get; set; }
        [ForeignKey("AutorId")]
        public virtual Autor Autor { get; set; }
        public int EditorialId { get; set; }
        [ForeignKey("EditorialId")]
        public virtual Editorial Editorial { get; set; }

    }
}
