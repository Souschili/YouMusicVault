using ServiceLayer.Models;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IUserData
    {   
        /// <summary>
        /// Поиск Юзера по таблице
        /// </summary>
        /// <param name="mail">User İD</param>
        /// <returns></returns>
        Task<User> GetUserByNMail(string mail);

        //TODO for refresh token
        Task FindRefreshToken(string guid);
    }
}
