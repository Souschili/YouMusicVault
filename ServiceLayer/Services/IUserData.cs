using ServiceLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IUserData
    {
        Task<List<User>> GetAll();

        Task AddUser(User user);

        Task<User> FindByNickName(string name);
    }
}
