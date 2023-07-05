using HealthCareOrganization.Interfaces;
using HealthCareOrganization.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthCareOrganization.Services
{
    public class GenerateTokenService : IGenerateToken
    {
        private readonly SymmetricSecurityKey _key;
        public GenerateTokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
        public string GenerateToken(UserDTO user)
        {
            string token = string.Empty;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.UserId.ToString()),
                new Claim(ClaimTypes.Role,user.Role)

            };
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = cred
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var myToken = tokenHandler.CreateToken(tokenDescription);
            token = tokenHandler.WriteToken(myToken);
            return token;
        }
    }
}

