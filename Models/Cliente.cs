using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibreriaWeb.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }

        /*
         * Relaciones
         */
        public virtual ICollection<Orden> Ordenes { get; set; }
    }
}
