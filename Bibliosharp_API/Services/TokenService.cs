using Bibliosharp_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bibliosharp_API.Services; 
public class TokenService {

    public string GenerateToken(Admin admin) {
        Claim[] claims = new Claim[] {
            new Claim("username", admin.UserName),
            new Claim("id", admin.Id)

        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1278eydachjbcssdsdhb"));

        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.Aes128CbcHmacSha256);

        var token = new JwtSecurityToken(
              expires: DateTime.Now.AddMinutes(10),
              claims: claims,
              signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
