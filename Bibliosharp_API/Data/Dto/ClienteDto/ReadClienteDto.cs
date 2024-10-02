using Bibliosharp_API.Data.Dto.LivroDto;
using Bibliosharp_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Bibliosharp_API.Data.Dto.ClienteDto; 
public class ReadClienteDto {

    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public virtual List<ReadLivroEmprestadoDto> LivrosEmprestados { get; set; }

}
