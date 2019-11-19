using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    [Obsolete("Интерфейс больше не используется так как не актуален")]
    public interface IUserData
    {
        Task<List<User>> GetAllAsync();

        Task AddUserAsync(User user);

        Task<User> FindByNickNameAsync(string name);

        Task<User> FindUserAsync(string login, string password);
    }
}
