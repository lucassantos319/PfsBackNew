
using Microsoft.IdentityModel.Tokens;
using PfsDomain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PfsInfrastructure.Configurations
{
    public static class TokenConfiguration
    {
        private static readonly Guid _guid = new Guid();

        public static string Generate(User user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("e5ea3b5c-f67f-45f4-931f-13138caa29cb");
            var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(User user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            return ci;
        }
    }
}
