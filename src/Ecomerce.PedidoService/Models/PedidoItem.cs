namespace Ecomerce.PedidoService.Models;

public class PedidoItem
{
    public int Id { get; set; }

    public int ProdutoId { get; set; }

    public string? NomeProduto { get; set; }

    public decimal PrecoUnitario { get; set; }

    public long Quantidade { get; set; }

    public decimal SubTotal => PrecoUnitario * Quantidade;

    public int PedidoId { get; set; }

    public Pedido? Pedido { get; set; }
}
