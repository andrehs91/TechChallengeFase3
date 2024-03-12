using FIAP.Core.Data;
using FIAP.Core.Entities;
using FiapStore.Repository;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Producer.Services;

public class PedidoService(IRepository<Pedido> repository, ApplicationDbContext context) : IPedidoService
{
    private readonly IRepository<Pedido> _repository = repository;
    protected ApplicationDbContext _context = context;

    public async Task<IList<Pedido>> ListarPedidosAsync()
    {
        return await _repository.GetAsync();
    }

    public async Task<IList<Pedido>> ListarPedidosComItensAsync()
    {
        return await _context.Pedidos
            .Include(p => p.Itens)
            .ThenInclude(i => i.Produto)
            .ToListAsync();
    }
}
