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

        public MusicRepository(ApplicationContext applicationContext)
        {
            this.context = applicationContext;
        }

        public async  Task AddUser(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public Task FindRefreshToken(string guid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возращает список всех юзеров
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }


        public Task<User> GetUserByNMail(string mail)
        {
            throw new NotImplementedException();
        }
    }
}
