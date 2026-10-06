using System;

namespace Ecomerce.Estoque.Consumer.Models;

public class EstoqueMessage
{
    public int ProdutoId { get; set; }
    public long Quantidade { get; set; }
    public string? Tipo { get; set; }
    public DateTime Timestamp { get; set; }
}
