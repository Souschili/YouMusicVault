using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceLayer.Models;

namespace ServiceLayer.Services
{
    /// <summary>
    /// Класс по работе с пользователями
    /// </summary>
    public class UserManager : IUserManager
    {
        private IUserData context;

        public UserManager(IUserData data)
        {
            context = data;
        }

        /// <summary>
        /// Вывести всех пользователей в базе
        /// </summary>
        /// <returns>Список пользователей</returns>
        public Task<List<User>> FindAllUsers()
        {
            throw new NotImplementedException();
        }

     
        /// <summary>
        /// Найти нового юзера по никнейму
        /// </summary>
        /// <param name="name">Никнейм юзера</param>
        /// <returns>Возращает пользователя </returns>
        public  Task<User> FindUserByNickname(string name)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Метод для регистрации новых юзеров
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Результат попытки добавления нового юзера</returns>
        public async Task<bool> RegisterUser(User user)
        {
                await context.AddUser(user);
                return true;
        }
    }
}
