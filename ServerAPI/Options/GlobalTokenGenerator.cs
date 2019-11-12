using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace ServerAPI.Options
{
    /// <summary>
    /// Класс отвечающий за генерацию токенов
    /// </summary>
    public class GlobalTokenGenerator : ITokenGenerator
    {

        private readonly IOptions<JwtOptions> options;

        public GlobalTokenGenerator(IOptions<JwtOptions> opt)
        {
            options = opt;
        }
        //TODO generate jwt
        public Task GenerateJwtToken()
        {
            throw new NotImplementedException();
        }

        public Task GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public JwtOptions GetOption()
        {
            return options.Value ;
        }
    }
}
