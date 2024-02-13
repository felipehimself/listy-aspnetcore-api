using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Entities.User;
using Api.Domain.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {

        public string GenerateJwtToken(Guid userId, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("MySuperSecretKey12345678901234567890tKey@345");


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role, role.ToString()),

                }),
                Expires = DateTime.UtcNow.AddDays(7), // Token expires in 7 days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = "listy-api",
                Issuer = "https://localhost:5001",

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public static Tuple<Guid, string> ValidateAndDecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();


            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://localhost:5001",
                    ValidAudience = "listy-api",
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("MySuperSecretKey12345678901234567890tKey@345")) // todo: alterar para env

                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;


                var userId = Guid.Parse(jwtToken.Claims.ToList().First(x => x.Type == JwtRegisteredClaimNames.NameId).Value);

                var userRole = jwtToken.Claims.ToList().First(x => x.Type == "role").Value;

                return new Tuple<Guid, string>(userId, userRole);
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException();
            }
        }

    }
}