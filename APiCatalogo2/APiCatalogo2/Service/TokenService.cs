using APiCatalogo2.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APiCatalogo2.Service
{
    public class TokenService : ITokenService
    {
        public string GerarToken(string key, string issuer, string audience, UserModel userModel)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,userModel.UserName ),
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString())
            };


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer:issuer,
                                            audience:audience,
                                            expires:DateTime.Now.AddHours(1),
                                            claims:claims,signingCredentials:credentials);


            var tokenHandler = new JwtSecurityTokenHandler();
            var StringToken = tokenHandler.WriteToken(token);
            return StringToken;
        }
         

    }
}
