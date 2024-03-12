using FIAP.Core.Entities;

namespace FIAP.Producer.DTO;

public class ItemDTO
{
    public uint PedidoId { get; set; }
    public uint ProdutoId { get; set; }
    public ProdutoDTO Produto { get; set; }
    public int Quantidade { get; set; }

    public ItemDTO(Item item)
    {
        PedidoId = item.PedidoId;
        ProdutoId = item.ProdutoId;
        Quantidade = item.Quantidade;
        Produto = new ProdutoDTO(item.Produto);
    }
}
