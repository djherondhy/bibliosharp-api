using Bibliosharp_API.Data;
using Bibliosharp_API.Data.Dto.ClienteDto;
using Bibliosharp_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bibliosharp_API.Controllers;


[ApiController]
[Route("[Controller]")]

public class ClienteController: ControllerBase {

    public ClienteService _clienteService;

    public ClienteController(ClienteService clienteService) {
        _clienteService = clienteService;
    }

    [HttpPost]
    public async Task<IActionResult> addCliente([FromBody] CreateClienteDto dto) {

        var newCliente = await _clienteService.AddClienteAsync(dto);
        return Ok(newCliente);
    }

    [HttpGet]
    public async Task<IActionResult> getClientes() {
        var clientes = await _clienteService.getClientesAsync();

        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getClienteById(int id) {
        var cliente = await _clienteService.findClienteById(id);

        if (cliente == null) {
            return NotFound("Cliente Não Encontrado");
        }

        return Ok(cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> updateCliente(int id, [FromBody] UpdateClienteDto dto) {
        var clienteUpdated = await _clienteService.UpdateClieteAsync(dto);
        return Ok(clienteUpdated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id) {
        var deleted = await _clienteService.deleteClienteAsync(id);
        if (!deleted) {
            return NotFound("Cliente Não Encontrado");
        }

        return NoContent();
    }

}
