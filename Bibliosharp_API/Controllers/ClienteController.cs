using Bibliosharp_API.Data;
using Bibliosharp_API.Data.Dto.ClienteDto;
using Bibliosharp_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bibliosharp_API.Controllers;

[ApiController]
[Route("[Controller]")]
[Authorize]
public class ClienteController : ControllerBase {

    private ClienteService _clienteService;

    public ClienteController(ClienteService clienteService) {
        _clienteService = clienteService;
    }

    /// <summary>
    /// Adiciona um novo cliente ao sistema.
    /// </summary>
    /// <param name="dto">Dados do cliente a ser adicionado.</param>
    /// <returns>Os dados do cliente adicionado.</returns>
    /// <response code="200">Cliente adicionado com sucesso.</response>
    /// <response code="400">Dados inválidos ao adicionar o cliente.</response>
    [HttpPost]
    public async Task<IActionResult> addCliente([FromBody] CreateClienteDto dto) {
        var newCliente = await _clienteService.AddClienteAsync(dto);
        return Ok(newCliente);
    }

    /// <summary>
    /// Obtém uma lista de todos os clientes.
    /// </summary>
    /// <returns>Lista de clientes.</returns>
    /// <response code="200">Lista de clientes retornada com sucesso.</response>
    [HttpGet]
    public async Task<IActionResult> getClientes() {
        var clientes = await _clienteService.getClientesAsync();
        return Ok(clientes);
    }

    /// <summary>
    /// Obtém os detalhes de um cliente específico pelo ID.
    /// </summary>
    /// <param name="id">ID do cliente a ser encontrado.</param>
    /// <returns>Detalhes do cliente.</returns>
    /// <response code="200">Cliente encontrado com sucesso.</response>
    /// <response code="404">Cliente não encontrado.</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> getClienteById(int id) {
        var cliente = await _clienteService.findClienteById(id);

        if (cliente == null) {
            return NotFound("Cliente não encontrado.");
        }

        return Ok(cliente);
    }

    /// <summary>
    /// Atualiza os dados de um cliente existente.
    /// </summary>
    /// <param name="id">ID do cliente a ser atualizado.</param>
    /// <param name="dto">Dados atualizados do cliente.</param>
    /// <returns>Dados do cliente atualizado.</returns>
    /// <response code="200">Cliente atualizado com sucesso.</response>
    /// <response code="404">Cliente não encontrado.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> updateCliente(int id, [FromBody] UpdateClienteDto dto) {
        var clienteUpdated = await _clienteService.UpdateClieteAsync(dto);
        return Ok(clienteUpdated);
    }

    /// <summary>
    /// Remove um cliente existente pelo ID.
    /// </summary>
    /// <param name="id">ID do cliente a ser removido.</param>
    /// <returns>Status da remoção.</returns>
    /// <response code="204">Cliente removido com sucesso.</response>
    /// <response code="404">Cliente não encontrado.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id) {
        var deleted = await _clienteService.deleteClienteAsync(id);
        if (!deleted) {
            return NotFound("Cliente não encontrado.");
        }

        return NoContent();
    }
}
