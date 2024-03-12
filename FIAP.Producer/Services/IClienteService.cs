using FIAP.Core.Entities;

namespace FIAP.Producer.Services;

public interface IClienteService
{
    Task<IList<Cliente>> ListarClientesAsync();
    Task<IList<Cliente>> ListarClientesComPedidosAsync();
}
