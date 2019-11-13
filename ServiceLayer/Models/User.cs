using System;
using System.ComponentModel.DataAnnotations;

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
        [Key]
        public string ID { get; set; }
        /// <summary>
        /// Имя юзера
        /// </summary>
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Nickname { get; set; }
        /// <summary>
        /// Почтовый адресс
        /// </summary>
        [Required]
        [MaxLength(30)]
        [MinLength(5)]
        public string Email { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        /// <summary>
        /// Статус юзера
        /// </summary>
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Status { get; set; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime LastVisit { get; set; } = DateTime.Now;

        //TODO дополнить модель по мере надобности
    }
}
