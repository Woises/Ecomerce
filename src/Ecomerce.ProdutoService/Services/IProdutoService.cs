using Ecomerce.ProdutoService.DTOs;

namespace Ecomerce.ProdutoService.Services;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDTO>> GetProdutos();
    Task<IEnumerable<ProdutoDTO>> GetProdutosByIds(IEnumerable<int> ids);
    Task<IEnumerable<ProdutoDTO>> GetProdutosByNome(string nome);
    Task<IEnumerable<ProdutoDTO>> GetProdutosByCategoriaId(int categoriaId);    
}
