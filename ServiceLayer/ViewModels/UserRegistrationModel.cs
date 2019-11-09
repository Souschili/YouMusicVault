using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ViewModels
{
    /// <summary>
    /// Класс для передачи данных юзера для регистрации
    /// </summary>
    public class UserRegistrationModel
    {
        /// <summary>
        /// Общедоступное имя пользователя
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// Почтовый адресс
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        //TODO добавить поля по мере надобности  
    }
}
