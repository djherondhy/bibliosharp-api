using Bibliosharp_API.Data;
using Bibliosharp_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliosharp_API.Services;
public class EmprestimoService {

    public ApplicationDbContext _context;

    public EmprestimoService(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<bool> EmprestarLivroAsync(int clienteId, int livroId) {
        var cliente = await _context.Clientes.Include(c => c.LivrosEmprestados).FirstOrDefaultAsync(c => c.Id == clienteId);
        if (cliente == null) {
            throw new ApplicationException("Cliente não encontrado");
        }

        if (cliente.LivrosEmprestados.Count(e => e.DataDevolucao == null) >= 3) {
            throw new Exception("O cliente já emprestou 3 livros.");
        }

        var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == livroId && l.EstaEmprestado);
        if (livro == null) {
            throw new Exception("Livro não disponível.");
        }

        var emprestimo = new Emprestimo {
            ClienteId = clienteId,
            LivroId = livroId,
            DataEmprestimo = DateTime.Now
        };

        // Atualizar disponibilidade do livro
        livro.EstaEmprestado = true;

        _context.Emprestimos.Add(emprestimo);
        await _context.SaveChangesAsync();

        return true;

    }

    public async Task<bool> DevolverLivroAsync(int clienteId, int livroId) {
        var emprestimo = await _context.Emprestimos.FirstOrDefaultAsync(e => e.ClienteId == clienteId && e.LivroId == livroId && e.DataDevolucao == null);
        if (emprestimo == null) {
            throw new Exception("Empréstimo não encontrado.");
        }

        emprestimo.DataDevolucao = DateTime.Now;

        // Tornar o livro disponível novamente
        var livro = await _context.Livros.FindAsync(livroId);
        livro.EstaEmprestado = false;

        await _context.SaveChangesAsync();

        return true;
    }

}
