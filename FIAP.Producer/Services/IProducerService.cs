using FIAP.Producer.DTO;

namespace FIAP.Producer.Services;

public interface IProducerService
{
    void EnviarPedido(EnviarPedidoDTO pedidoDTO);
}
