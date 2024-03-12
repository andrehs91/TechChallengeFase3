using FIAP.Core.Entities;

namespace FIAP.Producer.DTO;

public class PedidoDTO
{
    public uint Id { get; set; }
    public DateTime Data { get; set; }
    public uint ClienteId { get; set; }
    public List<ItemDTO> Itens { get; set; } = [];
    public int QuantidadeTotal
    {
       get
       {
           int resultado = 0;
           foreach (var item in Itens)
               resultado += item.Quantidade;
           return resultado;
       }
    }
    public double ValorTotal
    {
       get
       {
           double resultado = 0;
           foreach (var item in Itens)
               resultado += item.Produto.Preco * item.Quantidade;
           return resultado;
       }
    }

    public PedidoDTO(Pedido pedido)
    {
        Id = pedido.Id;
        Data = pedido.Data;
        ClienteId = pedido.ClienteId;
        if (pedido.Itens.Count != 0)
        {
            Itens = pedido.Itens.Select(i => new ItemDTO(i)).ToList();
        }
    }
}
