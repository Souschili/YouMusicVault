using System;
using System.Threading.Tasks;
using ServiceLayer.Models;

namespace ServiceLayer.Services
{
    public class UserManager : IUserManager
    {
        public Task FindRefreshToken(string guid)
        {
            throw new NotImplementedException();
        }

        public  Task<User> FindUserByNickname(string name)
        {
            throw new NotImplementedException();
        }
    }
}
