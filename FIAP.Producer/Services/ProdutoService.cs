using FIAP.Core.Entities;
using FIAP.Core.Repositories;

namespace FIAP.Producer.Services;

public class ProdutoService(IRepository<Produto> repository) : IProdutoService
{
    private readonly IRepository<Produto> _repository = repository;

    public async Task<IList<Produto>> ListarProdutosAsync()
    {
        return await _repository.GetAsync();
    }
}
