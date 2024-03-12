using FIAP.Core.Entities;

namespace FIAP.Producer.Services;

public interface IPedidoService
{
    Task<IList<Pedido>> ListarPedidosAsync();
    Task<IList<Pedido>> ListarPedidosComItensAsync();
}
