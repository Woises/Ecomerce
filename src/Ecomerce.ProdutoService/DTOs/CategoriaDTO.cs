using System.ComponentModel.DataAnnotations;

namespace Ecomerce.ProdutoService.DTOs;

public class CategoriaDTO
{
    public int IdCategoria { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome da categoria não pode exceder 100 caracteres.")]
    [MinLength(3, ErrorMessage = "O nome da categoria deve ter pelo menos 3 caracteres.")]
    public string? Nome { get; set; }
}
