using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CEGameApp.API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CEGameApp.API.Data
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _config;

        public LoginService(IConfiguration config)
        {
            _config = config;
        }
        
        public string GenerateToken(Users user)
        {
            var claims = new[]
            {
                new Claim( ClaimTypes.NameIdentifier, user.Id.ToString() ),
                new Claim( ClaimTypes.Name, user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            //attaching key as part of signing credentials that's encrypted
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //creating first part of token with claims, expiration date and security credentials.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            var tokens = tokenHandler.WriteToken(token);

            return tokens;
        }
    }
}