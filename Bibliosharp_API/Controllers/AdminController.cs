using Bibliosharp_API.Data.Dto;
using Bibliosharp_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bibliosharp_API.Controllers;

[ApiController]
[Route("[Controller]")]
public class AdminController : ControllerBase {

    private AdminService _adminService;

    public AdminController(AdminService adminService) {
        _adminService = adminService;
    }

    /// <summary>
    /// Adiciona um novo administrador ao sistema.
    /// </summary>
    /// <param name="dto">Dados do administrador a ser adicionado.</param>
    /// <returns>Uma mensagem de sucesso.</returns>
    /// <response code="200">Administrador adicionado com sucesso.</response>
    /// <response code="400">Dados inválidos ou erro ao adicionar o administrador.</response>
    [HttpPost("register")]
    public async Task<IActionResult> addAdmin(CreateAdminDto dto) {
        await _adminService.addAdmin(dto);
        return Ok("Administrador adicionado.");
    }

    /// <summary>
    /// Realiza o login de um administrador.
    /// </summary>
    /// <param name="dto">Dados de login do administrador.</param>
    /// <returns>Uma mensagem de sucesso e um token de autenticação.</returns>
    /// <response code="200">Login bem-sucedido, token retornado.</response>
    /// <response code="400">Login falhou, credenciais inválidas.</response>
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginAdminDto dto) {
        var token = await _adminService.Login(dto, _adminService.GetTokenService());

        if (string.IsNullOrEmpty(token)) {
            return BadRequest(new { message = "Login falhou, tente novamente." });
        }

        return Ok(new {
            message = "Login bem-sucedido!",
            token = token
        });
    }
}
