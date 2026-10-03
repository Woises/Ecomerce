using Microsoft.EntityFrameworkCore;
using Ecomerce.ProdutoService.Models;

namespace Ecomerce.ProdutoService.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }


}
