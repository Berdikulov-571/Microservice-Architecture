using Autorization.Api.Interfaces;
using Autorization.Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Autorization.Api.Services
{
    public class AuthService : IAuthService
    {
        public string GenerateToken(Login login)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mana-shu-security-key"));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, login.Email),
                new Claim(ClaimTypes.Role, login.Role.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}