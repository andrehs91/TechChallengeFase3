using FIAP.Producer.DTO;

namespace FIAP.Producer.Services;

public interface IProducerService
{
    public void EnviarPedido(PedidoDTO pedidoDTO);
}
