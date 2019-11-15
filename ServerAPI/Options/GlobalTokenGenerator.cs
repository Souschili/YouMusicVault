using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServerAPI.Options
{
    /// <summary>
    /// Класс отвечающий за генерацию токенов
    /// </summary>
    public class GlobalTokenGenerator : ITokenGenerator
    {

        private readonly IOptions<JwtOptions> options;

        public GlobalTokenGenerator(IOptions<JwtOptions> opt)
        {
            options = opt;
        }
        //TODO generate jwt
         private async Task<string> GenerateJwtToken(List<Claim> userclaims)
        {

            var symetrickey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Secret));
            var singincredencials = new SigningCredentials(symetrickey, SecurityAlgorithms.HmacSha256);

            var JwtToken = new JwtSecurityToken(
                issuer: options.Value.Issuer,
                audience: options.Value.Audience,
                claims: userclaims,
                signingCredentials: singincredencials,
                expires: DateTime.Now.AddMinutes(options.Value.ExpireTime)
                //удалить или разобраться почему кидает эксепшион
                //notBefore: new DateTimeOffset(DateTime.Now).DateTime
                );
            
            var token = await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(JwtToken));
            return token;
        }

        public async Task<JWTModel> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>();

            var token = await GenerateJwtToken(claims) ;
            var refresh = await GenerateRefreshToken();
            return new JWTModel { NickName = user.Nickname, JwtToken = token, RefreshToken = refresh };
        }

        public async Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return await Task.Run(()=> Convert.ToBase64String(randomNumber));
            }
        }

        public JwtOptions GetOption()
        {
            return options.Value;
        }
    }
}
