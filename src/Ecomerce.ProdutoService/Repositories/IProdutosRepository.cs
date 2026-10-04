using Ecomerce.ProdutoService.Models;

namespace Ecomerce.ProdutoService.Repositories;

public interface IProdutosRepository
{

    Task<IEnumerable<Produto>> GetAll();
    Task<IEnumerable<Produto>> GetProdutosCategorias(Categoria categoria);
    Task<Produto> GetById(int id);
    Task<Produto> Create(Produto produto);
    Task<Produto?> Update(Produto produto);
    Task<bool> Delete(int id);
}
