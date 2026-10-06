namespace Ecomerce.ProdutoService.Models;

public class Categoria
{
    public int IdCategoria { get; set; }
    public string? Nome { get; set; }    

    public ICollection<Produto>? Produtos { get; set; }



}
