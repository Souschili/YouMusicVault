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
        public async  Task AddUser(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Поиск юзера по никнейму
        /// </summary>
        /// <param name="name">Никнейм</param>
        /// <returns>Возращает обьект юзер</returns>
        public async Task<User> FindByNickName(string name)
        {
            return await context.User.FirstOrDefaultAsync(x => x.Nickname == name);
        }

        /// <summary>
        /// Возращает список всех юзеров
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAll()
        {
            return await context.User.ToListAsync();
        }

    }
}
