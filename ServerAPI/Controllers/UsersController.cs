using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

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



    }
}