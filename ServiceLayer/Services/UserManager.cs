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
        
        private readonly DbContext context;


        public UserManager(DbContext data)
        {
            context = data;
        }

        /// <summary>
        /// Возращает список всех юзеров
        /// </summary>
        /// <returns>Список всех пользователей</returns>
        public async Task<List<User>> FindAllUsersAsync()
        {
            return await context.Set<User>().ToListAsync();
        }

        /// <summary>
        /// Поиск одной записи в таблице юзеров 
        /// </summary>
        /// <param name="login">Почтовый адресс</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task<User> FindUserAsync(string login, string password)
        {
            var user = await context.Set<User>().FirstOrDefaultAsync(x => x.Email == login && x.Password == password);
            return user;
        }

        /// <summary>
        /// Поиск юзера по никнейму
        /// </summary>
        /// <param name="name">Никнейм</param>
        /// <returns>Возращает обьект юзер</returns>
        public async Task<User> FindUserByNicknameAsync(string name)
        {
            return await context.Set<User>().FirstOrDefaultAsync(x => x.Nickname == name);
        }

        /// <summary>
        /// Запись нового юзера в таблицу
        /// </summary>
        /// <param name="user">Обьект типа User</param>
        /// <returns></returns>
        public async Task<bool> RegisterUserAsync(User user)
        {
            //TODO вернуть класс модели ошибки для информативности
            try
            {
                await context.Set<User>().AddAsync(user);
                await context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }



        }
    }
}
