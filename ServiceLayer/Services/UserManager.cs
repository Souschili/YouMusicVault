using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceLayer.Models;

namespace ServiceLayer.Services
{
    public class UserManager : IUserManager
    {
        private IUserData context;

        public UserManager(IUserData data)
        {
            context = data;
        }

        public Task<List<User>> FindAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task FindRefreshToken(string guid)
        {
            throw new NotImplementedException();
        }

        public  Task<User> FindUserByNickname(string name)
        {
            throw new NotImplementedException();
        }

        public Task RegisterUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
