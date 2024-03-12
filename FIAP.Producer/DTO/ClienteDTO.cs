using FIAP.Core.Entities;

namespace FIAP.Producer.DTO;

public class ClienteDTO
{
    public uint Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public virtual List<PedidoDTO>? Pedidos { get; set; }

    public ClienteDTO(Cliente cliente)
    {
        Id = cliente.Id;
        Nome = cliente.Nome;
        Email = cliente.Email;
        if (cliente.Pedidos is not null && cliente.Pedidos.Count != 0)
        {
            Pedidos = cliente.Pedidos.Select(p => new PedidoDTO(p)).ToList();
        }
    }
}
