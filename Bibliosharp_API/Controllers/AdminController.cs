using Bibliosharp_API.Data.Dto;
using Bibliosharp_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bibliosharp_API.Controllers;

[ApiController]
[Route("[Controller]")]
public class AdminController:ControllerBase {

    private AdminService _adminService;

    public AdminController(AdminService adminService) {
        _adminService = adminService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> addAdmin(CreateAdminDto dto) {

        await _adminService.addAdmin(dto);
        return Ok("Administrador Adicionado");
    }

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
