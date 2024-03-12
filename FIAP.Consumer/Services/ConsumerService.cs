using FIAP.Consumer.DTO;
using FIAP.Consumer.Entities;
using FIAP.Consumer.Exceptions;
using FiapStore.Repository;

namespace FIAP.Consumer.Services;

public class ConsumerService(IRepository<Cliente> clienteRepository, IRepository<Pedido> pedidoRepository, IRepository<Produto> produtoRepository) : IConsumerService
{
    private readonly IRepository<Cliente> _clienteRepository = clienteRepository;
    private readonly IRepository<Pedido> _pedidoRepository = pedidoRepository;
    private readonly IRepository<Produto> _produtoRepository = produtoRepository;

    public async Task<Pedido> CadastrarPedidoAsync(Pedido pedido)
    {
        await _pedidoRepository.AddAsync(pedido);
        return pedido;
    }

    public async Task<Pedido> ValidarPedidoAsync(PedidoDTO pedidoDTO)
    {
        Pedido pedido = new();

        uint clienteID = pedidoDTO.ClienteId;
        Cliente cliente = await _clienteRepository.GetAsync(clienteID)
            ?? throw new ClienteException($"Cliente de ID '{clienteID}' não encontrado.");
        pedido.ClienteId = cliente.Id;
        pedido.Cliente = cliente;

        List<Item> items = [];
        foreach (var produtoDTO in pedidoDTO.Produtos)
        {
            uint produtoId = produtoDTO.ProdutoId;
            Produto produto = await _produtoRepository.GetAsync(produtoId)
                ?? throw new ProdutoException($"Produto de ID '{produtoId}' não encontrado.");
            items.Add(new(pedido, produto, produtoDTO.Quantidade));
        }
        pedido.Itens = items;

        return pedido;
    }
}
