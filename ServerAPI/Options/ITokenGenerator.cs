using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServerAPI.Options
{
    public interface ITokenGenerator
    {
        Task<string> GenerateJwtToken(List<Claim> claims);
        Task GenerateRefreshToken();

        JwtOptions GetOption();
    }
}
