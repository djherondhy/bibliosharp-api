using System.ComponentModel.DataAnnotations;

namespace Bibliosharp_API.Models; 
public class Cliente {

    [Key]
    [Required]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public virtual ICollection<Emprestimo> LivrosEmprestados { get; set; } = new List<Emprestimo>();

}
