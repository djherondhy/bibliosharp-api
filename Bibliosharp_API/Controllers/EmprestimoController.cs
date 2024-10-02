using Bibliosharp_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Swashbuckle.Swagger.Annotations;

namespace Bibliosharp_API.Controllers;

[ApiController]
[Route("[Controller]")]
[Authorize]
public class EmprestimoController : ControllerBase {

    public EmprestimoService _emprestimoService;

    public EmprestimoController(EmprestimoService emprestimoService) {
        _emprestimoService = emprestimoService;
    }

    /// <summary>
    /// Empresta um livro para um cliente.
    /// </summary>
    /// <param name="clienteId">ID do cliente que está emprestando o livro.</param>
    /// <param name="livroId">ID do livro a ser emprestado.</param>
    /// <returns>Uma mensagem de sucesso ou erro.</returns>
    /// <response code="200">Livro emprestado com sucesso.</response>
    /// <response code="400">Dados inválidos ou erro ao processar o empréstimo.</response>
    [HttpPost("{clienteId}/emprestar/{livroId}")]
    public async Task<IActionResult> EmprestarLivro(int clienteId, int livroId) {
        try {
            var emprestimo = await _emprestimoService.EmprestarLivroAsync(clienteId, livroId);
            return Ok("Livro emprestado com sucesso.");
        }
        catch (ApplicationException ex) {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Devolve um livro emprestado por um cliente.
    /// </summary>
    /// <param name="clienteId">ID do cliente que está devolvendo o livro.</param>
    /// <param name="livroId">ID do livro a ser devolvido.</param>
    /// <returns>Uma mensagem de sucesso ou erro.</returns>
    /// <response code="200">Livro devolvido com sucesso.</response>
    /// <response code="404">Empréstimo não encontrado ou erro ao processar a devolução.</response>
    [HttpPost("devolver/{clienteId}/{livroId}")]
    public async Task<IActionResult> DevolverLivro(int clienteId, int livroId) {
        try {
            bool resultado = await _emprestimoService.DevolverLivroAsync(clienteId, livroId);
            if (resultado) {
                return Ok("Livro devolvido com sucesso.");
            }
            return NotFound("Empréstimo não encontrado.");
        }
        catch (ApplicationException ex) {
            return NotFound(ex.Message);
        }
    }
}
