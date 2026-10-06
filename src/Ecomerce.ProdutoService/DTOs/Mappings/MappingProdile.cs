using AutoMapper;
using Ecomerce.ProdutoService.Models;


namespace Ecomerce.ProdutoService.DTOs.Mappings;

public class MappingProdile : Profile
{
    public MappingProdile()
    {
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();

    }

}
