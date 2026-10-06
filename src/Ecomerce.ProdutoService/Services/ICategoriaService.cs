using Ecomerce.ProdutoService.DTOs;


namespace Ecomerce.ProdutoService.Services;

public interface ICategoriaService
{

    Task<IEnumerable<CategoriaDTO>> GetCategorias();
    
    Task<IEnumerable<CategoriaDTO>> GetCategoriasProdutos();

    Task<IEnumerable<CategoriaDTO>> GetCategoriasByIds(IEnumerable<int> ids);

    Task<IEnumerable<CategoriaDTO>> GetCategoriasByNome(string nome);

}
