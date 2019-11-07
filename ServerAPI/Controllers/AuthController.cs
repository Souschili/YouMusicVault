using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Models;
using System;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Token="my JWT object", Refresh="my refresh token" });
        }

        // TODO delete this controller it's only for testing
        [HttpGet("Guid")]
        public IActionResult Guid()
        {
            //генератор уникального глобального айди
            //var t = System.Guid.NewGuid().ToString();
            //новый юзер тестовый вариант + randome ID
            var user = new User { ID = System.Guid.NewGuid().ToString(), Name = "Xoasit" };
            return Ok(user);
        }
        
    }
}