using Bibliosharp_API.Data.Dto.LivroDto;
using Bibliosharp_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bibliosharp_API.Controllers;

[ApiController]
[Route("[Controller]")]
[Authorize]
public class LivroController : ControllerBase {

    private readonly LivroService _livroService;

    public LivroController(LivroService livroService) {
        _livroService = livroService;
    }

    /// <summary>
    /// Adiciona um novo livro ao sistema.
    /// </summary>
    /// <param name="dto">Dados do livro a ser adicionado.</param>
    /// <returns>Os dados do livro adicionado.</returns>
    /// <response code="200">Livro adicionado com sucesso.</response>
    /// <response code="400">Dados inválidos ao adicionar o livro.</response>
    [HttpPost]
    public async Task<IActionResult> addLivro([FromBody] CreateLivroDto dto) {
        var newLivro = await _livroService.AddLivroAsync(dto);
        return Ok(newLivro);
    }

    /// <summary>
    /// Obtém uma lista de todos os livros.
    /// </summary>
    /// <returns>Lista de livros.</returns>
    /// <response code="200">Lista de livros retornada com sucesso.</response>
    [HttpGet]
    public async Task<IActionResult> getLivros() {
        var livros = await _livroService.getLivrosAsync();
        return Ok(livros);
    }

    /// <summary>
    /// Obtém os detalhes de um livro específico pelo ID.
    /// </summary>
    /// <param name="id">ID do livro a ser encontrado.</param>
    /// <returns>Detalhes do livro.</returns>
    /// <response code="200">Livro encontrado com sucesso.</response>
    /// <response code="404">Livro não encontrado.</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> getLivroById(int id) {
        var livro = await _livroService.findLivroById(id);

        if (livro == null) {
            return NotFound("Livro não encontrado.");
        }

        return Ok(livro);
    }

    /// <summary>
    /// Atualiza os dados de um livro existente.
    /// </summary>
    /// <param name="id">ID do livro a ser atualizado.</param>
    /// <param name="dto">Dados atualizados do livro.</param>
    /// <returns>Dados do livro atualizado.</returns>
    /// <response code="200">Livro atualizado com sucesso.</response>
    /// <response code="404">Livro não encontrado.</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> updateLivro(int id, [FromBody] UpdateLivroDto dto) {
        var livroUpdated = await _livroService.UpdateLivroAsync(dto);
        return Ok(livroUpdated);
    }

    /// <summary>
    /// Remove um livro existente pelo ID.
    /// </summary>
    /// <param name="id">ID do livro a ser removido.</param>
    /// <returns>Status da remoção.</returns>
    /// <response code="204">Livro removido com sucesso.</response>
    /// <response code="404">Livro não encontrado.</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteLivro(int id) {
        var deleted = await _livroService.deleteLivroAsync(id);
        if (!deleted) {
            return NotFound("Livro não encontrado.");
        }

        return NoContent();
    }
}
