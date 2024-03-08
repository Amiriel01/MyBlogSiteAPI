using BlogSite.API.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogSite.API.Repositories.Implementation
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;

        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateJwtToken(IdentityUser user, List<string> roles)
        {
            //create claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            //iterate through each of the roles and creat the claim
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            //defined jwt security token params
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );

            //return the token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
