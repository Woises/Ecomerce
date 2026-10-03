var builder = DistributedApplication.CreateBuilder(args);

var produtoApi = builder.AddProject<Projects.Ecomerce_ProdutoService>("apiservice-produto");
var pedidoApi = builder.AddProject<Projects.Ecomerce_PedidoService>("apiservice-pedido");
//var clienteApi = builder.AddProject<Projects.Ecomerce_ClienteService>("apiservice-cliente");
var pagamentoApi = builder.AddProject<Projects.Ecomerce_PagamentoService>("apiservice-pagamento");
//var estoqueApi = builder.AddProject<Projects.Ecomerce_EstoqueService>("apiservice-estoque");
//var notificacaoApi = builder.AddProject<Projects.Ecomerce_NotificacaoService>("apiservice-notificacao");
//var ecomercceWebApp = builder.AddProject<Projects.Ecomerce_WebApp>("ecomerce-webapp");

builder.AddProject<Projects.Ecomerce_WebApp>("web-frontend")
    .WithReference(produtoApi)
    .WithReference(pedidoApi)
    .WithReference(pagamentoApi);


builder.Build().Run();
