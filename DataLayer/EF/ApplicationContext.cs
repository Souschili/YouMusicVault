using Microsoft.EntityFrameworkCore;
using ServiceLayer.Models;

namespace DataLayer.EF
{
    /// <summary>
    /// Класс содержащий таблицы и отвечающий за работу с БД
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Таблица пользователей приложения
        /// </summary>
        public DbSet<User> User { get; set; }
        /// <summary>
        /// Таблица токенов доступа
        /// </summary>
        public DbSet<UserToken> userTokens { get; set; }
        /// <summary>
        /// Таблица токенов обновления
        /// </summary>
        public DbSet<UserRefreshToken> refreshTokens { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="options">дефолтные настройки для передачи в базовый класс</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();
        }

    }
}
