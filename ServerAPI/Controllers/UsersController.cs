using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Models;
using ServiceLayer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerAPI.Controllers
{
    /// <summary>
    /// Работа с текущими пользователями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager userManager;

        public UsersController(IUserManager manager)
        {
            userManager = manager;
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

        /// <summary>
        /// Получить юзера по нику
        /// </summary>
        /// <param name="name">Никнейм пользователя</param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<ActionResult<User>> GetUserAsync(string name)
        {
            var user = await userManager.FindUserByNickname(name);
            return user;
        }


    }
}