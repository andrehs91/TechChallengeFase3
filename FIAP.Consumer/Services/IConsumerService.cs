using FIAP.Consumer.DTO;
using FIAP.Core.Entities;

namespace FIAP.Consumer.Services;

public interface IConsumerService
{
    Task<Pedido> CadastrarPedidoAsync(Pedido pedido);
    Task<Pedido> ValidarPedidoAsync(PedidoDTO pedidoDTO);
}
