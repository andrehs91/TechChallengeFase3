using FIAP.Core.Entities;

namespace FIAP.Producer.Services;

public interface IProdutoService
{
    Task<IList<Produto>> ListarProdutosAsync();
}
