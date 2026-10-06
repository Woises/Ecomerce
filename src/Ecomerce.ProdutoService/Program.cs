
using Ecomerce.ProdutoService.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.ProdutoService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            string? mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
                                        options.UseMySQL(mysqlConnection!));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecomerce.PedidoService v1");
                options.RoutePrefix = string.Empty; // abre o swagger na raiz
            });

            app.MapControllers();

            app.Run();
        }
    }
}
