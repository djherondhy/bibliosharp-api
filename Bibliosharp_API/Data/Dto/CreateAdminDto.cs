using System.ComponentModel.DataAnnotations;

namespace Bibliosharp_API.Data.Dto; 
public class CreateAdminDto {

    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }

    [Required]
    public string Username { get; set; }
    [Required]

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }

}
