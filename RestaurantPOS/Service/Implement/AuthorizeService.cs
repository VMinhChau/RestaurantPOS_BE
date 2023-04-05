using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantPOS.Service.Implement
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly RestaurantDbContext _dbContext;
        
        public AuthorizeService(IConfiguration iconfiguration,SignInManager<User> signInManager, RestaurantDbContext dbContext)
        {
            _configuration = iconfiguration;
            _signInManager=signInManager;
            _dbContext=dbContext;
        }
        public string Authenticate(string userName, string pwd)
        {
            var check= _dbContext.User.Any(x => x.UserName == userName && x.Password==pwd);
            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                          {
                            new Claim(ClaimTypes.Name, userName),
                            new Claim(ClaimTypes.Email,pwd)
                          }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
