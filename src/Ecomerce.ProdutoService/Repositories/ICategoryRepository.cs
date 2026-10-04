using Ecomerce.ProdutoService.Models;

namespace Ecomerce.ProdutoService.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Categoria>> GetAll();
    Task<IEnumerable<Categoria>> GetCategoriasProdutos();
    Task<IEnumerable<Categoria>> GetById(int id);
    Task<Categoria> Create(Categoria categoria);
    Task<Categoria?> Update(Categoria categoria);
    Task<bool> Delete(int id);
}
