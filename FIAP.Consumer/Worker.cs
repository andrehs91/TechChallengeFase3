using FIAP.Consumer.DTO;
using FIAP.Consumer.Exceptions;
using FIAP.Consumer.Services;
using FIAP.Core.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace FIAP.Consumer;

public sealed class Worker(ILogger<Worker> logger, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;
    private readonly IConfiguration _configuration = configuration;
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        ConnectionFactory factory = new()
        {
            HostName = _configuration["RabbitMQ:HostName"],
            UserName = _configuration["RabbitMQ:UserName"],
            Password = _configuration["RabbitMQ:Password"]
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.ExchangeDeclare(exchange: "fiap.direct", type: ExchangeType.Direct);
        channel.QueueDeclare(queue: "pedido",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
        channel.QueueBind(queue: "pedido",
                          exchange: "fiap.direct",
                          routingKey: "pedido");
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            byte[] body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var pedidoDTO = JsonSerializer.Deserialize<PedidoDTO>(message);
            if (pedidoDTO is not null)
            {
                using IServiceScope scope = _serviceScopeFactory.CreateScope();
                try
                {
                    _logger.LogInformation(
                        "Starting scoped work, provider hash: {hash}.",
                        scope.ServiceProvider.GetHashCode()
                    );
                    var consumerService = scope.ServiceProvider.GetRequiredService<IConsumerService>();
                    Pedido pedido = await consumerService.ValidarPedidoAsync(pedidoDTO);
                    pedido = await consumerService.CadastrarPedidoAsync(pedido);
                    _logger.LogInformation("Pedido de ID '{id}' cadastrado.", pedido.Id);
                }
                catch (ClienteException e)
                {
                    _logger.LogError(e, "Cliente n�o encontrado.");
                    SendError(channel, "clientenaoencontrado", message);
                }
                catch (ProdutoException e)
                {
                    _logger.LogError(e, "Produto n�o encontrado.");
                    SendError(channel, "produtonaoencontrado", message);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Erro n�o identificado.");
                    SendError(channel, "outros", message);
                }
            }
        };
        channel.BasicConsume(queue: "pedido",
                             autoAck: true,
                             consumer: consumer);

        _logger.LogInformation("Consumer started at: {time}", DateTimeOffset.Now);

        while (!stoppingToken.IsCancellationRequested)
        {
        }
    }

    private static void SendError(IModel channel, string routingKey, string body)
    {
        string queue = "erro." + routingKey.ToLower();
        channel.QueueDeclare(queue: queue,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
        channel.QueueBind(queue: queue,
                          exchange: "fiap.direct",
                          routingKey: routingKey);
        var basicProperties = channel.CreateBasicProperties();
        basicProperties.Persistent = true;
        channel.BasicPublish(exchange: "fiap.direct",
                             routingKey: routingKey,
                             basicProperties: basicProperties,
                             body: Encoding.UTF8.GetBytes(body));
    }
}
