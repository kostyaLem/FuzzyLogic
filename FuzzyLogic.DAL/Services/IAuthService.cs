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
        /// <param name="type"> Тип аккаунта </param>
        /// <returns> Найденыый аккаунт </returns>
        Task<AccountDto> TryLoginAsync(string login, string password, AccountType type);
        
        /// <summary>
        /// Создать новый аккаунт
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password1"> Пароль </param>
        /// <param name="password2"> Повторный пароль </param>
        /// <param name="type"> Тип аккаунта </param>
        /// <returns> Зарегистрированный аккаунт </returns>
        Task<AccountDto> CreateAccount(string login, string password1, string password2, AccountType type);
    }
}
