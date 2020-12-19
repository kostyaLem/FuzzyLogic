using FuzzyLogic.DAL.Models;
using System.Threading.Tasks;

namespace FuzzyLogic.DAL.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Попытка авторизации пользователя
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password"> Пароль </param>
        /// <returns> True, если аккаунт найден </returns>
        Task<AccountDto> TryLogin(string login, string password);
    }
}
