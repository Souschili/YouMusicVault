using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAPI.Options
{
    public interface ITokenGenerator
    {
        Task GenerateJwtToken();
        Task GenerateRefreshToken();

        JwtOptions GetOption();
    }
}
