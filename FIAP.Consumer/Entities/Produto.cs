namespace FIAP.Consumer.Entities;

public class Produto : DefaultEntity
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public double Preco { get; set; }
}
