using DataLayer.EF;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Models;
using ServiceLayer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    /// <summary>
    /// Класс репозиторий для работы с бд
    /// </summary>
    public class MusicRepository : IUserData
    {
        private ApplicationContext context;

        /// <summary>
        /// Конструктор класса 
        /// </summary>
        /// <param name="applicationContext">Контекст приложения</param>
        public MusicRepository(ApplicationContext applicationContext)
        {
            this.context = applicationContext;
        }

        /// <summary>
        /// Запись нового юзера в таблицу
        /// </summary>
        /// <param name="user">Обьект типа User</param>
        /// <returns></returns>
        public async  Task AddUserAsync(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Поиск юзера по никнейму
        /// </summary>
        /// <param name="name">Никнейм</param>
        /// <returns>Возращает обьект юзер</returns>
        public async Task<User> FindByNickNameAsync(string name)
        {
            return await context.User.FirstOrDefaultAsync(x => x.Nickname == name);
        }

        /// <summary>
        /// Поиск одной записи в таблице юзеров 
        /// </summary>
        /// <param name="login">Почтовый адресс</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task<User> FindUserAsync(string login, string password)
        {
            var user = await context.User.FirstOrDefaultAsync(x => x.Email == login && x.Password == password);
            return user;
        }

        /// <summary>
        /// Возращает список всех юзеров
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllAsync()
        {
            return await context.User.ToListAsync();
        }

    }
}
