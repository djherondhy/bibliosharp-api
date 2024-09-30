using System.ComponentModel.DataAnnotations;

namespace Bibliosharp_API.Data.Dto; 
public class LoginAdminDto {

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
