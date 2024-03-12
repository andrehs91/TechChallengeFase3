namespace FIAP.Core.Entities;

public class Cliente : DefaultEntity
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public virtual List<Pedido>? Pedidos { get; set; }
}
