using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAPI.Options
{
    /// <summary>
    /// Класс отвечающий за генерацию токенов
    /// </summary>
    public class GlobalTokenGenerator : ITokenGenerator
    {
        
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
