using GoCook_API.Model;
using Microsoft.EntityFrameworkCore;

namespace GoCook_API;

public class GoCookDbContext : DbContext
{
    public GoCookDbContext(DbContextOptions<GoCookDbContext> options) : base(options)
    {
    }

    // Defina as DbSet para suas entidades (Usuário, Receita, etc.) aqui
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Receita> Receitas { get; set; }
    public DbSet<Ingrediente> Ingredientes { get; set; }

    // ...

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .Property(u => u.Cd_Usuario)
            .ValueGeneratedOnAdd(); 

        modelBuilder.Entity<Usuario>()
            .HasKey(u => u.Cd_Usuario);


        modelBuilder.Entity<Receita>()
            .HasKey(r => r.Cd_Receita);

        modelBuilder.Entity<Ingrediente>()
            .HasKey(i => new { i.Cd_Ingrediente, i.Cd_Receita });

        modelBuilder.Entity<Ingrediente>()
            .Property(u => u.Cd_Ingrediente)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Receitas)
            .WithOne(r => r.Usuario)
            .HasForeignKey(r => r.Cd_Usuario);

        modelBuilder.Entity<Receita>()
            .HasMany(r => r.Ingredientes)
            .WithOne(i => i.Receita)
            .HasForeignKey(i => i.Cd_Receita);

        base.OnModelCreating(modelBuilder);


    }
}
