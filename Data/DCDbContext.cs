using DestinoCertoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DestinoCertoMVC.Data
{
    public class DCDbContext : DbContext
{
    public DCDbContext(DbContextOptions<DCDbContext> options)
        : base(options)
    {
    }

    public DbSet<UsuarioViewModel> Usuarios { get; set; }
    public DbSet<PacoteViewModel> Pacotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UsuarioViewModel>().ToTable("usuarios");
        modelBuilder.Entity<PacoteViewModel>().ToTable("pacotes");

        modelBuilder.Entity<PacoteViewModel>()
            .HasOne(p => p.Usuario)
            .WithMany()
            .HasForeignKey(p => p.UsuarioId);
    }
}
}
