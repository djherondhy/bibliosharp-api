using Bibliosharp_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bibliosharp_API.Controllers;

[ApiController]
[Route("[Controller]")]
public class EmprestimoController: ControllerBase {

    public EmprestimoService _emprestimoService;

    public EmprestimoController(EmprestimoService emprestimoService) {
        _emprestimoService = emprestimoService;
    }

    [HttpPost("{clienteId}/emprestar/{livroId}")]
    public async Task<IActionResult> EmprestarLivro(int clienteId, int livroId) {
         
        var emprestimo = await _emprestimoService.EmprestarLivroAsync(clienteId, livroId);
          return Ok(emprestimo);
        
    }
}
