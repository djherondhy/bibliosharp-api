using AutoMapper;
using Bibliosharp_API.Data;
using Bibliosharp_API.Data.Dto.LivroDto;
using Bibliosharp_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliosharp_API.Services;
public class LivroService {

    private IMapper _mapper;
    private ApplicationDbContext _context;

    public LivroService(IMapper mapper, ApplicationDbContext context) {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Livro> AddLivroAsync(CreateLivroDto dto) {

        Livro livro = _mapper.Map<Livro>(dto);

        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();

        return livro;
    }

    public async Task<ReadLivroDto> findLivroById(int id) {
        var livro = await _context.Livros.FindAsync(id);
        var livroDto = _mapper.Map<ReadLivroDto>(livro);
        return livroDto;
    }

    public async Task<IEnumerable<ReadLivroDto>> getLivrosAsync() {
        var livroList = _mapper.Map<List<ReadLivroDto>>(await _context.Livros.ToListAsync());
        return livroList;
    }

    public async Task<Livro> UpdateLivroAsync(UpdateLivroDto dto) {
        Livro livro = _mapper.Map<Livro>(dto);
        _context.Livros.Update(livro);
        await _context.SaveChangesAsync();
        return livro;
    }

    public async Task<bool> deleteLivroAsync(int id) {
        var livro = await _context.Livros.FindAsync(id);

        if (livro == null) return false;

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
        return true;
    }
}
