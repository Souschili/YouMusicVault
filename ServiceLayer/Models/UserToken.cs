using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServiceLayer.Models
{
    [Table("UserJwtdb")]
    public class UserToken
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Токен доступа юзера
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Активен или устарел
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Список токенов обновления для данного юзера
        /// </summary>
        public List<UserRefreshToken> Refresh { get; set; }
        /// <summary>
        /// Внешний ключ из таблицы юзеры
        /// </summary>
        public virtual User User { get; set; } 

    }
}
