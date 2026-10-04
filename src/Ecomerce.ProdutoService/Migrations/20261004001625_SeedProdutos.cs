using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.ProdutoService.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Produtos (Nome, Preco, Descricao, Quantidade, ImageURL, CategoriaIdCategoria, IdCategoria) VALUES ('Smartphone', 1999.99, 'Smartphone de última geração', 10, 'smartphone.jpg', 1, 1)");
            mb.Sql("INSERT INTO Produtos (Nome, Preco, Descricao, Quantidade, ImageURL, CategoriaIdCategoria, IdCategoria) VALUES ('Camiseta', 49.99, 'Camiseta de algodão', 50, 'camiseta.jpg', 2, 2)");
            mb.Sql("INSERT INTO Produtos (Nome, Preco, Descricao, Quantidade, ImageURL, CategoriaIdCategoria, IdCategoria) VALUES ('Livro de Programação', 79.99, 'Livro sobre programação em C#', 20, 'livro.jpg', 3, 3)");
            mb.Sql("INSERT INTO Produtos (Nome, Preco, Descricao, Quantidade, ImageURL, CategoriaIdCategoria, IdCategoria) VALUES ('Chocolate', 9.99, 'Chocolate ao leite', 100, 'chocolate.jpg', 4, 4)");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Produtos");
        }
    }
}
