namespace FIAP.Core.Entities;

public class Pedido : DefaultEntity
{
    public uint ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;
    public List<Item> Itens { get; set; } = [];
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
}
