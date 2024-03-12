namespace FIAP.Core.Entities;

public class Item : DefaultEntity
{
    public uint PedidoId { get; set; }
    public Pedido Pedido { get; set; } = null!;
    public uint ProdutoId { get; set; }
    public Produto Produto { get; set; } = null!;
    public int Quantidade { get; set; }

    public Item() { }

    public Item(Pedido pedido, Produto produto, int quantidade)
    {
        PedidoId = pedido.Id;
        Pedido = pedido;
        ProdutoId = produto.Id;
        Produto = produto;
        Quantidade = quantidade;
    }
}
