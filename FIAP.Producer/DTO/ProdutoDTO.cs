using FIAP.Core.Entities;

namespace FIAP.Producer.DTO;

public class ProdutoDTO
{
    public uint Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public double Preco { get; set; }

    public ProdutoDTO(Produto produto)
    {
        Id = produto.Id;
        Nome = produto.Nome;
        Descricao = produto.Descricao;
        Preco = produto.Preco;
    }
}
