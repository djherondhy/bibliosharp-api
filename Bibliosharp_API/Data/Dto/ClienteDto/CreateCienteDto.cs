using Bibliosharp_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Bibliosharp_API.Data.Dto.ClienteDto;
public class CreateClienteDto{

    [Required]
    public string Nome { get; set; }

    [Required]
    public string CPF { get; set; }
    

}
