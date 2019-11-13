using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Options;
using ServiceLayer.Models;
using ServiceLayer.Services;
using ServiceLayer.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServerAPI.Controllers
{
    /// <summary>
    /// Контролер авторизации пользователей
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly ITokenGenerator tokenGenerator;

        public AuthController(IUserManager manager,ITokenGenerator generator)
        {
            userManager = manager;
            tokenGenerator = generator;
        }

        /// <summary>
        /// Регистрация нового пользовотеля
        /// </summary>
        /// <param name="model">Данные юзера из клиента</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> CreateUserAsync([FromBody]UserRegistrationModel model)
        {
            //по хорошему добавить сервис для выдачи статуса и айди
            User user = new User
            {
                Email = model.Email,
                Nickname = model.NickName,
                Password = model.Password,
                Status = "User",
                ID = System.Guid.NewGuid().ToString()
            };

            var rezult = await userManager.RegisterUser(user);

            if (rezult) return Ok("User added");

            return BadRequest("We cant add user!!");
            #region памятка ошибки валидации
            //отлов ошибок модели , смотри аннотацию в User
            //var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
            // отдаем список ошибок клиенту если модель не валидна
            //return BadRequest(errors);
            #endregion
        }
        /// <summary>
        /// Авторизация пользователя и выдача токена
        /// </summary>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<string>> UserLogInAsync([FromBody]UserLogInModel logInModel)
        {
            //тестовый набор клаймов
            var claims = new List<Claim> { 
            new Claim(ClaimTypes.Role,"User"),
            new Claim(ClaimTypes.Role,"Maroder")
            };

            return await tokenGenerator.GenerateJwtToken(claims);
           //return new
           //{
           //    Email = logInModel.Email,
           //    Password = logInModel.Password,
           //    JwtToken = "todo generate jwt",
           //    RefreshToken = "Generate RefreshToken"
           //};
        }

        /// <summary>
        /// Тестовый метод
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles ="Admin,User,Maroder")]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Very important content");
        }

    }
}