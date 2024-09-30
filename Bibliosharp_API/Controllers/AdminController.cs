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

}
