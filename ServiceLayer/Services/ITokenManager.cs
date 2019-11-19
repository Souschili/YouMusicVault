
using ServiceLayer.Models;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface ITokenManager
    {
        Task<bool> AddToken(User user,JWTModel model);
    }
}
