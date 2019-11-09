﻿using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Models;
using ServiceLayer.Services;
using ServiceLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAPI.Controllers
{
    /// <summary>
    /// Контролер авторизации пользователей
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager userManager;

        public AuthController(IUserManager manager)
        {
            userManager = manager;
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
        /// Показ всех имеющихся пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet("all")]
        [Produces("application/json")]
        public async Task<ActionResult<List<User>>> All()
        {
            return await userManager.FindAllUsers();
        }
    }
}