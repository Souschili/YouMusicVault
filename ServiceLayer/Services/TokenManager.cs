using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Models;

namespace ServiceLayer.Services
{
    class TokenManager : ITokenManager
    {
        private readonly DbContext context;
        public TokenManager(DbContext db)
        {
            context = db;
        }

        /// <summary>
        /// Вписываем сгенерированые токены в таблицу
        /// </summary>
        /// <param name="user">текущий юзер</param>
        /// <param name="model">Пользовательские токены</param>
        /// <returns></returns>
        public async Task<bool> AddToken(User user,JWTModel model)
        {
            var utoken = new UserToken
            {
                Token = model.JwtToken,
                IsActive=true,
                Created=DateTime.Now,
            };
            utoken.User = user;

            //вписываем рефреш токен
            utoken.Refresh.Add(new UserRefreshToken
            {
                RefreshToken = model.RefreshToken,
                IsCalled = false,
                CreatedTime=DateTime.Now,
            });

            await context.Set<UserToken>().AddAsync(utoken);

            return true;
        }
    }
}
