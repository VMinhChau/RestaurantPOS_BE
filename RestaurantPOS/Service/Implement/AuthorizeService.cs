using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using RestaurantPOS.Common;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.DTOs.Token;
using RestaurantPOS.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantPOS.Service.Implement
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IConfiguration _configuration;
        private readonly RestaurantDbContext _dbContext;
        public AuthorizeService(IConfiguration configuration, RestaurantDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public TokenDto Authorize(string userName, string pwd)
        {
            var user= _dbContext.User.FirstOrDefault(c=>c.UserName == userName);
            if (user == null) return new TokenDto() { Check = false };
            else
            {
                var checkPwd = Utils.CheckHashPwd(pwd, user.PasswordHash);
                if (!checkPwd) return new TokenDto() { Check = false };
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

                var role = new Claim(ClaimTypes.Role, "IsUser");
                var clam = new Claim("IsAdmin", "false");
                if (user.Role == EnumCommon.Role.Admin)
                {
                    role = new Claim(ClaimTypes.Role, "IsAdmin");
                    clam = new Claim("IsAdmin", "true");
                }
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                              {
                                new Claim("Id", user.Id.ToString()),
                                new Claim("Name", user.FirstName+" "+user.LastName),
                                new Claim("Email", user.Email),
                                new Claim("Phone", user.PhoneNumber),
                                new Claim("Point", user.Points==null?"":user.Points.ToString()),
                                new Claim("Rank", user.Ranking==null?"":user.Ranking.ToString()),
                                new Claim("UserName", userName),
                                role,
                                clam
                              }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new TokenDto()
                {
                    Check = true,
                    Token = tokenHandler.WriteToken(token)
                };
            }
        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
    }
}
