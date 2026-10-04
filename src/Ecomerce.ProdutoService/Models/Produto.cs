namespace Ecomerce.ProdutoService.Models;

public class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public decimal Preco { get; set; }
    public string? Descricao { get; set; }
    public long Quantidade { get; set; }
    public string? ImageURL { get; set; }

    public Categoria? Categoria { get; set; }
    public int IdCategoria { get; set; }

}
