using ServiceLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IUserData
    {
        Task<List<User>> GetAll();

        Task AddUser(User user);

        Task<User> GetUserByNMail(string mail);

        //TODO for refresh token
        Task FindRefreshToken(string guid);


        //public DbSet<User> Users { get; set; } //?? delete this
    }
}
