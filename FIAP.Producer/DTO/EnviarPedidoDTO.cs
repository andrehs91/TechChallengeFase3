using FIAP.Producer.Filters;

namespace FIAP.Producer.DTO;

public class EnviarPedidoDTO
{
    [SwaggerExclude]
    public DateTime Data { get; set; } = DateTime.Now;
    public uint ClienteId { get; set; }
    public List<ProdutosDTO> Produtos { get; set; } = [];

    public struct ProdutosDTO
    {
        public uint ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
