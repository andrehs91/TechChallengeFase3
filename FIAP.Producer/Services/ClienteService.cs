using FIAP.Core.Data;
using FIAP.Core.Entities;
using FIAP.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Producer.Services;

public class ClienteService(IRepository<Cliente> repository, ApplicationDbContext context) : IClienteService
{
    private readonly IRepository<Cliente> _repository = repository;
    protected ApplicationDbContext _context = context;

    public async Task<IList<Cliente>> ListarClientesAsync()
    {
        return await _repository.GetAsync();
    }

    public async Task<IList<Cliente>> ListarClientesComPedidosAsync()
    {
        return await _context.Clientes
            .Include(c => c.Pedidos)
            .ThenInclude(p => p.Itens)
            .ThenInclude(i => i.Produto)
            .ToListAsync();
    }
}
