using ServiceLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    /// <summary>
    /// Интерфейс для поиска и фильтрации юзеров
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Поиск юзера по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<User> FindUserByNicknameAsync(string name);

        /// <summary>
        /// Найти всех юзеров в базе данных
        /// </summary>
        /// <returns></returns>
        Task<List<User>> FindAllUsersAsync();

        /// <summary>
        /// Регистрация нового юзера в базу
        /// </summary>
        /// <param name="user">Объект представляющий нового юзера</param>
        /// <returns>Возращает удачно или нет прошла регистрация</returns>
        Task<bool> RegisterUserAsync(User user);
        /// <summary>
        /// Проверка есть ли такой позователь
        /// </summary>
        /// <param name="login">Почтовый адресс</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        Task<User> FindUserAsync(string login, string password);
    }
}
