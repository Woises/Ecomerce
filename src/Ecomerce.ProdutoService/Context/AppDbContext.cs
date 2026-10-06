using Microsoft.EntityFrameworkCore;
using Ecomerce.ProdutoService.Models;

namespace Ecomerce.ProdutoService.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Categoria>().HasKey(c => c.IdCategoria);
        mb.Entity<Categoria>().Property(c => c.Nome).
            HasMaxLength(100).
            IsRequired();


        mb.Entity<Produto>().HasKey(p => p.Id);
        mb.Entity<Produto>().
            Property(p => p.Nome).
            HasMaxLength(100).
            IsRequired();

        mb.Entity<Produto>().
            Property(p => p.Descricao).
            HasMaxLength(255);

        mb.Entity<Produto>().
            Property(p => p.Preco).
            HasPrecision(12, 2).
            IsRequired();

        mb.Entity<Produto>().
            Property(p => p.ImageURL).
            HasMaxLength(255).
            IsRequired();

        mb.Entity<Categoria>().
            HasMany(c => c.Produtos).
            WithOne(p => p.Categoria).           
            OnDelete(DeleteBehavior.Cascade).
            IsRequired();

        mb.Entity<Categoria>().HasData(
            new Categoria { IdCategoria = 1, Nome = "Eletrônicos" },
            new Categoria { IdCategoria = 2, Nome = "Roupas" },
            new Categoria { IdCategoria = 3, Nome = "Livros" },
            new Categoria { IdCategoria = 4, Nome = "Alimentos" }
        );





    }
}
