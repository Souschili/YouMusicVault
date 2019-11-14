using ServiceLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IUserData
    {
        Task<List<User>> GetAllAsync();

        Task AddUserAsync(User user);

        Task<User> FindByNickNameAsync(string name);

        Task<User> FindUserAsync(string login, string password);
    }
}
