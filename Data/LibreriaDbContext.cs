using Microsoft.EntityFrameworkCore;

namespace LibreriaWeb.Data
{
    public class LibreriaDbContext : DbContext
    {
        public LibreriaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LibreriaWeb.Models.Libro> Libro { get; set; }
        public DbSet<LibreriaWeb.Models.Autor> Autor { get; set; }
        public DbSet<LibreriaWeb.Models.Editorial> Editorial { get; set; }
        public DbSet<LibreriaWeb.Models.Orden> Orden { get; set; }
        public DbSet<LibreriaWeb.Models.Cliente> Cliente { get; set; }
    }
}
