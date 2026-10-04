using Ecomerce.ProdutoService.Context;
using Ecomerce.ProdutoService.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.ProdutoService.Repositories;

public class ProdutoRepository : IProdutosRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Produto> Create(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<bool> Delete(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null) return false;

        _context.Remove(produto);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Produto>> GetAll()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto> GetById(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
            
        return produto;
    }
    

    public async Task<IEnumerable<Produto>> GetProdutosCategorias(Categoria categoria)
    {
        return await _context.Produtos.Where(p => p.Categoria == categoria).ToListAsync();
    }

    public async Task<Produto?> Update(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
        return produto;
    }
}
