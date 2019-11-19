using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Models;

namespace ServiceLayer.Services
{
    public class TokenManager : ITokenManager
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
        public async Task<bool> AddToken(User user, JWTModel model)
        {
            //создаем обьект аксес токена
            var jwt_token = new UserToken
            {
                Created = DateTime.Now,
                IsActive = true,
                Token = model.JwtToken,
                User = user
            };

            //создаем объект рефреш токена
            var refresh_token = new UserRefreshToken
            {
                CreatedTime = DateTime.Now,
                RefreshToken = model.RefreshToken,
                CallTime=null
            };

            //добавляем токен обновления
            jwt_token.Refresh.Add(refresh_token);

            //производим запись в таблицу
            await context.Set<UserToken>().AddAsync(jwt_token);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
