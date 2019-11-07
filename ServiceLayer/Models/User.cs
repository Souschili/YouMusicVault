using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    /// <summary>
    /// Класс представляющий пользователей
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный айди юзера
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Имя юзера
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// Почтовый адресс
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Статус юзера
        /// </summary>
        public string Status { get; set; }
        //TODO дополнить модель по мере надобности
    }
}
