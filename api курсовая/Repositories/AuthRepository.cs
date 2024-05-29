using api_курсовая.Authentication;
using api_курсовая.model;
using Kursovaya.Core.Abstract;
using Kursovaya.Core.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_курсовая.Repositories
{
    public class AuthRepository : IAuthRepository
    {


        private readonly AppDbContext _context;
        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }




        async Task<string> IAuthRepository.GenerateRefreshToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("my_secret_key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "refreshToken"),
                    new Claim(ClaimTypes.Role, user.Role),
                     new Claim("userId", user.Id.ToString()),

                }),
                Issuer = AuthOptions.ISSUER,
                Audience = AuthOptions.AUDIENCE,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                                      SecurityAlgorithms.HmacSha256)
        };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            RefreshTokenEntity refresh = new RefreshTokenEntity(user.Id.ToString(), token.ToString());
            await _context.Refreshs.AddAsync(refresh);
            await _context.SaveChangesAsync();  

            return tokenHandler.WriteToken(token);
        }

        async Task<string> IAuthRepository.GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("my_secret_key");

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "accessToken"),
                     new Claim(ClaimTypes.Role, user.Role),
                     new Claim("userId", user.Id.ToString()),
                }),

                Issuer = AuthOptions.ISSUER,
                Audience = AuthOptions.AUDIENCE,
                Expires = DateTime.UtcNow.AddMinutes(15), // Устанавливаем время жизни токена
                SigningCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                                      SecurityAlgorithms.HmacSha256)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
