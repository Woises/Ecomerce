using Ecomerce.ProdutoService.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecomerce.ProdutoService.DTOs;

public class ProdutoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do produto não pode exceder 100 caracteres.")]
    [MinLength(3, ErrorMessage = "O nome do produto deve ter pelo menos 3 caracteres.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O preço do produto é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço do produto deve ser maior que zero.")]    
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "A quantidade do produto é obrigatória.")]
    [Range(0, long.MaxValue, ErrorMessage = "A quantidade do produto não pode ser negativa.")]
    public long Quantidade { get; set; }
    public string? ImageURL { get; set; }


    public Categoria? Categoria { get; set; }
    public int IdCategoria { get; set; }
}
