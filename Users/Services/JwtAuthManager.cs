using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Services
{
    public class JwtAuthManager:IJwtAuthManager
    {
        private readonly AppDbContext _context;
        public IConfiguration Configuration { get; }

        public JwtAuthManager(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public string Authenticate(string username, string password)
        {
            var user = _context.User.Where(x=>x.Email==username && x.Password==password);
            if (user==null)            
                return null;
            

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(Configuration["MyKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
