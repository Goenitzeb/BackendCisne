using Microsoft.EntityFrameworkCore;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Data.Models.Views;

namespace BackendMacetas.Database.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Maceta>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired();
            entity.Property(e => e.Precio).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Diseno>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Tamano>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<ListadoMacetasView>(entity =>
        {
            entity.ToView("ListadoMacetasView");
        });
    }

    public DbSet<Maceta> Macetas { get; set; }

    public DbSet<Color> Colores { get; set; }

    public DbSet<Diseno> Disenos { get; set; }

    public DbSet<Modelo> Modelos { get; set; }

    public DbSet<Tamano> Tamanos { get; set; }

    public DbSet<ListadoMacetasView> ListadoMacetas { get; set; }
}
