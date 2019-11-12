using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAPI.Options
{
    /// <summary>
    /// Класс возрающий токен и прочую инфу
    /// </summary>
    public class JWTModel
    {
        public string NickName { get; set; } 
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
