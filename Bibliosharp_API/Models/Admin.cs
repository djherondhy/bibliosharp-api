using Microsoft.AspNetCore.Identity;

namespace Bibliosharp_API.Models; 
public class Admin: IdentityUser {

    public string CPF { get; set; }
    public DateTime DataNascimento {  get; set; }                            
    public Admin():base() { }
}
