namespace FIAP.Consumer.Entities;

public class Pedido : DefaultEntity
{
    public uint ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;
    public List<Item> Itens { get; set; } = [];
    //public int QuantidadeTotal { get => Itens.Count; }
    //public double ValorTotal
    //{
    //    get
    //    {
    //        double resultado = 0;
    //        foreach (var item in Itens)
    //        {
    //            resultado += item.Produto.Preco * item.Quantidade;
    //        }
    //        return resultado;
    //    }
    //}
}
