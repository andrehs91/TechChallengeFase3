using FIAP.Producer.DTO;
using FIAP.Producer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Producer.Controllers;

[ApiController]
[Route("api/pedido")]
public class PedidoController(ILogger<PedidoController> logger, IProducerService producerService) : ControllerBase
{
    private readonly ILogger<PedidoController> _logger = logger;
    private readonly IProducerService _producerService = producerService;

    [HttpPost]
    [ProducesResponseType(typeof(RespostaDTO), StatusCodes.Status202Accepted)]
    [ProducesResponseType(typeof(RespostaDTO), StatusCodes.Status400BadRequest)]
    public ActionResult<RespostaDTO> EnviarPedido([FromBody] PedidoDTO pedidoDTO)
    {
        try
        {
            if (pedidoDTO.Produtos.Count == 0)
                return BadRequest(RespostaDTO.Erro("Informe ao menos um item."));

            if (pedidoDTO.Produtos.Where(i => i.Quantidade == 0).Any())
                return BadRequest(RespostaDTO.Erro("A quantidade do item deve ser maior do que zero."));

            _producerService.EnviarPedido(pedidoDTO);
            return Accepted(RespostaDTO.Sucesso("Pedido enviado com sucesso."));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "PedidoController.EnviarPedido");
            return StatusCode(500, RespostaDTO.Erro("Um erro impediu o envio do pedido. Entre em contato com o suporte."));
        }
    }
}
