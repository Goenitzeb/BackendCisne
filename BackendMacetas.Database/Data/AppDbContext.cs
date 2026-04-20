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

        modelBuilder.Entity<ListadoColorView>(entity =>
        {
            entity.ToView("ListadoColorView");
        });

        modelBuilder.Entity<ListadoDisenoView>(entity =>
        {
            entity.ToView("ListadoDisenoView");
        });

        modelBuilder.Entity<ListadoTamanoView>(entity =>
        {
            entity.ToView("ListadoTamanoView");
        });

        modelBuilder.Entity<ListadoModeloView>(entity =>
        {
            entity.ToView("ListadoModeloView");
        });
    }

    public DbSet<Maceta> Macetas { get; set; }

    public DbSet<Color> Color { get; set; }

    public DbSet<Diseno> Diseno { get; set; }

    public DbSet<Modelo> Modelo { get; set; }

    public DbSet<Tamano> Tamano { get; set; }

    public DbSet<ListadoMacetasView> ListadoMacetas { get; set; }

    public DbSet<ListadoColorView> ListadoColores { get; set; }

    public DbSet<ListadoDisenoView> ListadoDisenos { get; set; }

     public DbSet<ListadoModeloView> ListadoModelos { get; set; }

     public DbSet<ListadoTamanoView> ListadoTamanos { get; set; }

    
}
