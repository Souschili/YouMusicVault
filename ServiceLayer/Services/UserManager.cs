using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Models;

namespace ServiceLayer.Services
{
    /// <summary>
    /// Класс по работе с пользователями
    /// </summary>
    public class UserManager : IUserManager
    {
        //private IUserData context;
        private DbContext context;
        

        public UserManager(DbContext data)
        {
            context = data;
        }

        /// <summary>
        /// Вывести всех пользователей в базе
        /// </summary>
        /// <returns>Список пользователей</returns>
        public async Task<List<User>> FindAllUsersAsync()
        {
            return await context.GetAllAsync();
        }
        /// <summary>
        /// Поиск юзера по параметрам
        /// </summary>
        /// <param name="login">Почтовый адресс</param>
        /// <param name="password">Пароль</param>
        /// <returns>Обьект пользователь</returns>
        public async Task<User> FindUserAsync(string login, string password)
        {
            return await context.FindUserAsync(login, password);
        }

        /// <summary>
        /// Найти нового юзера по никнейму
        /// </summary>
        /// <param name="name">Никнейм юзера</param>
        /// <returns>Возращает пользователя </returns>
        public async Task<User> FindUserByNicknameAsync(string name)
        {
            return await context.FindByNickNameAsync(name);
        }

        /// <summary>
        /// Метод для регистрации новых юзеров
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Результат попытки добавления нового юзера</returns>
        public async Task<bool> RegisterUserAsync(User user)
        {
            await context.AddUserAsync(user);
            return true;
        }
    }
}
