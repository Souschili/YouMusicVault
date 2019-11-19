using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Options;
using ServiceLayer.Services;
using ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Linq;
using ServiceLayer.Models;

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
        private readonly ITokenManager tokenManager;

        public AuthController(IUserManager manager, ITokenGenerator generator, ITokenManager token)
        {
            userManager = manager;
            tokenGenerator = generator;
            tokenManager = token;
        }

        /// <summary>
        /// Регистрация нового пользовотеля
        /// </summary>
        /// <param name="model">Данные юзера из клиента</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> CreateUserAsync([FromBody]UserRegistrationModel model)
        {
            //смотрим есть такой в базе ( запилить отдельный метод)
            var user = (await userManager.FindAllUsersAsync())
                .FirstOrDefault(x => x.Password == model.Password && x.Nickname == model.NickName);
            //если нету то добавляем
            if (user == null)
            {
                user = new User
                {
                    ID = System.Guid.NewGuid().ToString(),
                    Nickname = model.NickName,
                    Password = model.Password,
                    Email = model.Email,
                    Status = "User" //пока все юзеры
                };

                //создаем нового юзера
                var rezult = await userManager.RegisterUserAsync(user);

                if (rezult)
                    return Ok("User added");

            }

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
        public async Task<IActionResult> UserLogInAsync([FromBody]UserLogInModel logInModel)
        {
            var user = await userManager.FindUserAsync(logInModel.Email, logInModel.Password);
            //если юзер не найден , то ответ 400
            if (user == null)
            {
                return BadRequest("Can't find this user!");
            }

            var token = await tokenGenerator.GenerateUserToken(user);
            //пишем полученные токены в таблицу
            var rez = await tokenManager.AddToken(user, token);

            return Ok(token);


        }

        /// <summary>
        /// Тестовый метод
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,User,Maroder")]
        [HttpGet("test")]
        public ActionResult<string> Test()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

    }
}