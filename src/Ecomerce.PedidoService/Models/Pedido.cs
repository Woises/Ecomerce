using System;
using System.Collections.Generic;

namespace Ecomerce.PedidoService.Models;

public class Pedido
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public string? ClienteNome { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public decimal Total { get; set; }

    public string? Status { get; set; }

    public ICollection<PedidoItem>? Itens { get; set; }
}
