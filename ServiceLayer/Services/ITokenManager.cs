
using ServiceLayer.Models;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface ITokenManager
    {
        Task AddToken(JWTModel model);
    }
}
