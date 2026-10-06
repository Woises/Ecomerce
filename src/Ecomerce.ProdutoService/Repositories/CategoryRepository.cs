using Ecomerce.ProdutoService.Context;
using Ecomerce.ProdutoService.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.ProdutoService.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Categoria>> GetAll()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task<IEnumerable<Categoria>> GetCategoriasProdutos()
    {
        return await _context.Categorias.Include(c => c.Produtos).ToListAsync();
    }

    public async Task<IEnumerable<Categoria>> GetById(int id)
    {
        return await _context.Categorias.Where(c => c.IdCategoria == id).ToListAsync();
    }

    public async Task<Categoria?> Update(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> Create(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<bool> Delete(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null)
            return false;

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
        return true;
    }
}
