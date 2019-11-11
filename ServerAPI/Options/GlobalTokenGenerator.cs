using System;
using System.Threading.Tasks;

namespace ServerAPI.Options
{
    /// <summary>
    /// Класс отвечающий за генерацию токенов
    /// </summary>
    public class GlobalTokenGenerator : ITokenGenerator
    {
        
        private readonly JwtOptions options;
        
        public Task GenerateJwtToken()
        {
            throw new NotImplementedException();
        }

        public Task GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}
