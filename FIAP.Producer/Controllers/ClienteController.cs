using FIAP.Core.Entities;
using FIAP.Producer.DTO;
using FIAP.Producer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Producer.Controllers;

[ApiController]
[Route("api/cliente")]
[Produces("application/json")]
public class ClienteController(IClienteService clienteService) : ControllerBase
{
    private readonly IClienteService _clienteService = clienteService;

    [HttpGet]
    [Route("listar-clientes")]
    [ProducesResponseType(typeof(IList<ClienteDTO>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IList<ClienteDTO>>> ListarClientes(bool incluirPedidos = false)
    {
        IList<Cliente> clientes = incluirPedidos
            ? clientes = await _clienteService.ListarClientesComPedidosAsync()
            : clientes = await _clienteService.ListarClientesAsync();
        return Ok(clientes.Select(c => new ClienteDTO(c)).ToList());
    }
}
