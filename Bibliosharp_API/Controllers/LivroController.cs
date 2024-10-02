using Bibliosharp_API.Data.Dto.LivroDto;
using Bibliosharp_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bibliosharp_API.Controllers;

[ApiController]
[Route("[Controller]")]
public class LivroController : ControllerBase {

    private readonly LivroService _livroService;

    public LivroController(LivroService livroService) {
        _livroService = livroService;
    }

    [HttpPost]
    public async Task<IActionResult> addLivro([FromBody] CreateLivroDto dto) {
        var newLivro = await _livroService.AddLivroAsync(dto);
        return Ok(newLivro);
    }

    [HttpGet]
    public async Task<IActionResult> getLivros() {
        var livros = await _livroService.getLivrosAsync();
        return Ok(livros);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getLivroById(int id) {
        var livro = await _livroService.findLivroById(id);

        if (livro == null) {
            return NotFound("Livro Não Encontrado");
        }

        return Ok(livro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> updateLivro(int id, [FromBody] UpdateLivroDto dto) {
        var livroUpdated = await _livroService.UpdateLivroAsync(dto);
        return Ok(livroUpdated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteLivro(int id) {
        var deleted = await _livroService.deleteLivroAsync(id);
        if (!deleted) {
            return NotFound("Livro Não Encontrado");
        }

        return NoContent();
    }
}
