using FIAP.Core.Entities;
using FIAP.Producer.DTO;
using FIAP.Producer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Producer.Controllers;

[ApiController]
[Route("api/produto")]
[Produces("application/json")]
public class ProdutoController(IProdutoService produtoService) : ControllerBase
{
    private readonly IProdutoService _produtoService = produtoService;

    [HttpGet]
    [Route("listar-produtos")]
    [ProducesResponseType(typeof(IList<ProdutoDTO>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IList<ProdutoDTO>>> ListarProdutos()
    {
        IList<Produto> produtos = await _produtoService.ListarProdutosAsync();
        return Ok(produtos.Select(c => new ProdutoDTO(c)).ToList());
    }
}
