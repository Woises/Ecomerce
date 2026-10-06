using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Ecomerce.Estoque.Consumer.Models;

namespace Ecomerce.Estoque.Consumer.Services;

public class KafkaConsumerService : BackgroundService
{
    private readonly ILogger<KafkaConsumerService> _logger;
    private readonly IConfiguration _configuration;
    private IConsumer<Ignore, string>? _consumer;
    private readonly string _topic;

    public KafkaConsumerService(ILogger<KafkaConsumerService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _topic = _configuration.GetValue<string>("Kafka:Topic") ?? "Estoque";

        var config = new ConsumerConfig
        {
            BootstrapServers = _configuration.GetValue<string>("Kafka:BootstrapServers") ?? "localhost:9092",
            GroupId = _configuration.GetValue<string>("Kafka:GroupId") ?? "ecomerce-estoque-consumer",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = true
        };

        _consumer = new ConsumerBuilder<Ignore, string>(config)
            .SetErrorHandler((_, e) => _logger.LogError("Kafka error: {Reason}", e.Reason))
            .Build();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(() => StartConsumeLoop(stoppingToken), stoppingToken);
    }

    private void StartConsumeLoop(CancellationToken stoppingToken)
    {
        if (_consumer == null) return;

        _consumer.Subscribe(_topic);

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var cr = _consumer.Consume(stoppingToken);
                    if (cr?.Message?.Value != null)
                    {
                        _logger.LogInformation("Mensagem recebida do tópico {Topic}: {Message}", cr.Topic, cr.Message.Value);
                        try
                        {
                            var msg = JsonSerializer.Deserialize<EstoqueMessage>(cr.Message.Value);
                            if (msg != null)
                            {
                                // TODO: implementar lógica de processamento do estoque
                                _logger.LogInformation("Processando estoque - ProdutoId={ProdutoId}, Quantidade={Quantidade}", msg.ProdutoId, msg.Quantidade);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Falha ao desserializar mensagem de estoque");
                        }
                    }
                }
                catch (ConsumeException ex)
                {
                    _logger.LogError(ex, "Erro consumindo mensagem Kafka");
                }
            }
        }
        catch (OperationCanceledException) { }
        finally
        {
            try { _consumer.Close(); } catch { }
        }
    }

    public override void Dispose()
    {
        _consumer?.Dispose();
        base.Dispose();
    }
}
