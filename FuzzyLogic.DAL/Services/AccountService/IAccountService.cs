using FuzzyLogic.DAL.Models;
using FuzzyLogic.DB.Context.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuzzyLogic.DAL.Services.AccountService
{
    public interface IAccountService
    {
        /// <summary>
        /// Обновить существующий аккаунт
        /// </summary>
        /// <param name="accountDto"> Аккаунт для обновления </param>
        /// <returns></returns>
        Task UpdateAccountAsync(AccountDto accountDto);

        /// <summary>
        /// Удалить существующий аккаунт
        /// </summary>
        /// <param name="accountDto"> Аккаунт для удаления </param>        
        Task DeleteAccountAsync(AccountDto accountDto);

        /// <summary>
        /// Получить список аккаунтов
        /// </summary>
        /// <returns> Список аккаунтов </returns>
        Task<IEnumerable<AccountDto>> GetAccountsAsync();

        /// <summary>
        /// Получить список аккаунтов по фильтру
        /// </summary>
        /// <param name="filter"> Фильтр отбора </param>
        /// <returns> Список аккаунтов </returns>
        Task<IEnumerable<AccountDto>> GetAccountsAsync(Func<AccountDto, bool> filter);

        /// <summary>
        /// Получить список ролей
        /// </summary>
        /// <returns> Список ролей </returns>
        Task<IEnumerable<Role>> GetRoles();

        /// <summary>
        /// Сохранить историю изменений
        /// </summary>
        void SaveAsync();

        void Dispose();
    }
}