namespace ServiceLayer.Models
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
