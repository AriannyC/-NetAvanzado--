using Desarrollo.Core.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Desarrollo.Core.Persistencia.TokenJWT
{
    public class TOKEN
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TOKEN(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {

            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;

        }


        public string encriptar(string text)
        {


            using (SHA256 sha256has = SHA256.Create())
            {


                byte[] bytes = sha256has.ComputeHash(Encoding.UTF8.GetBytes(text));


                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {


                    builder.Append(bytes[i].ToString("x2"));

                }

                return builder.ToString();
            }
        }

        public string GeneratJTW(Ustoken regiUs)
        {


            var userclaims = new[]
            {

               new Claim(ClaimTypes.NameIdentifier, regiUs.IdR.ToString()),
               new Claim(ClaimTypes.Email, regiUs.Username!)
           };

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
            var credential = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256Signature);



            var jwrconfi = new JwtSecurityToken(
                claims: userclaims,
                expires: DateTime.UtcNow.AddMinutes(30),
                 signingCredentials: credential

                             );
            return new JwtSecurityTokenHandler().WriteToken(jwrconfi);








        }
        
    }
}
