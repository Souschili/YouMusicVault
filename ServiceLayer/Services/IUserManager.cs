﻿using ServiceLayer.Models;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    /// <summary>
    /// Интерфейс для поиска и фильтрации юзеров
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Поиск юзера по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<User> FindUserByNickname(string name);

        //Todo for refresh tokens
        Task FindRefreshToken(string guid);
        
    }
}