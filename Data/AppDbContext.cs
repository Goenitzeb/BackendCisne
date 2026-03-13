using Microsoft.EntityFrameworkCore;
using BackendMacetas.Models;

namespace BackendMacetas.Data{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Maceta> Macetas { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<Diseno> Disenos { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Tamano> Tamanos { get; set; }
    }
}