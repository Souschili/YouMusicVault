using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Models;
using ServiceLayer.Services;
using ServiceLayer.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserData context;
        public AuthController(IUserData userData)
        {
            this.context = userData;
        }

      
        [HttpPost("register")]
        public async Task<IActionResult> CreateUserAsync([FromBody]UserRegistrationModel model)
        {
            //переделать , айди должен автоматом выдаваться
            if(ModelState.IsValid)
            {
                
                return Ok("User added");
            }
            //отлов ошибок модели , смотри аннотацию в User
            var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
            // отдаем список ошибок клиенту если модель не валидна
            return BadRequest(errors);
           
        }

    }
}