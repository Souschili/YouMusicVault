using DataLayer.EF;
using ServiceLayer.Models;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;
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
        /// Возращает список всех юзеров
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
