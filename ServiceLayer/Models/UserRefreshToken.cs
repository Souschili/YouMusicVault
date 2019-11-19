using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.Models
{
    /// <summary>
    /// Класс токенов обновления  пользователей
    /// </summary>
    public class UserRefreshToken
    {
        [Key]
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        /// <summary>
        /// Использовался ли токен обновления
        /// </summary>
        public bool IsCalled { get; set; } = false;
        /// <summary>
        /// Дата создания токена
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// Дата срабатывания токена обновления
        /// </summary>
        public DateTime? CallTime { get; set; }
    }
}
