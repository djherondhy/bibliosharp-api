using Bibliosharp_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bibliosharp_API.Data {
    public class ApplicationDbContext: IdentityDbContext<Admin> {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Cliente)
                .WithMany(c => c.LivrosEmprestados)
                .HasForeignKey(e => e.ClienteId);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Livro)
                .WithMany()
                .HasForeignKey(e => e.LivroId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Livro> Livros { get; set; }

    }
}
