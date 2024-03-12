using FIAP.Producer.DTO;
using RabbitMQ.Client;
using System.Text.Json;

namespace FIAP.Producer.Services;

public class ProducerService(IConfiguration configuration) : IProducerService
{
    private readonly IConfiguration _configuration = configuration;

    public void EnviarPedido(PedidoDTO pedidoDTO)
    {
        ConnectionFactory factory = new();
        factory.HostName = _configuration["RabbitMQ:HostName"];
        factory.UserName = _configuration["RabbitMQ:UserName"];
        factory.Password = _configuration["RabbitMQ:Password"];

        using var connection = factory.CreateConnection();

        using var channel = connection.CreateModel();

        var basicProperties = channel.CreateBasicProperties();
        basicProperties.Persistent = true;

        channel.BasicPublish(exchange: "fiap.direct",
                             routingKey: "pedido",
                             basicProperties: basicProperties,
                             body: JsonSerializer.SerializeToUtf8Bytes(pedidoDTO));
    }
}
