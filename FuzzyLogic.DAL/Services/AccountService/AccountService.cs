using FuzzyLogic.DAL.Mappers;
using FuzzyLogic.DAL.Models;
using FuzzyLogic.DAL.Utils;
using FuzzyLogic.DB.Context;
using FuzzyLogic.DB.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuzzyLogic.DAL.Services.AccountService
{
    public sealed class AccountService : IAccountService, IAuthService, IDisposable
    {
        private UnitOfWork<FuzzyContext> _unitOfWork;

        public AccountService(FuzzyContext debugContext)
        {
            _unitOfWork = new UnitOfWork<FuzzyContext>(debugContext);
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _unitOfWork.Roles.GetAll();
        }

        public async Task<AccountDto> CreateAccount(string login, string password1, string password2, AccountType type)
        {
            if (password1 != password2)
                throw new Exception("Пароли не совпадают");

            var account = await CheckAccountAsync(login);

            if (account == null)
            {
                account = new Account
                {
                    Login = login,
                    Password = password1,
                    Role = await _unitOfWork.Roles.Get((int)type),
                    RoleId = (int)type
                };

                _unitOfWork.Acconts.Create(account);

                await _unitOfWork.SaveChangesAsync();

                return account.MapToDto();
            }

            throw new Exception("Аккаунт с таким логином уже существует");
        }

        public async Task DeleteAccountAsync(AccountDto accountDto)
        {
            var account = await _unitOfWork.Acconts.Get(accountDto.Id);

            _unitOfWork.Acconts.Delete(account);
        }

        public async Task UpdateAccountAsync(AccountDto accountDto)
        {
            var account = await _unitOfWork.Acconts.Get(accountDto.Id);
            account.Role = _unitOfWork.DbContext.Roles.First(x => x.Id == accountDto.Role.Id);

            _unitOfWork.Acconts.Update(account);
        }

        public async Task<IEnumerable<AccountDto>> GetAccountsAsync()
        {
            return await GetAccountsAsync(_ => true);
        }

        public async Task<IEnumerable<AccountDto>> GetAccountsAsync(Func<AccountDto, bool> filter)
        {
            return (await _unitOfWork.Acconts.GetAll(x => filter(x.MapToDto()))).Select(x => x.MapToDto());
        }

        public async Task<AccountDto> TryLoginAsync(string login, string password, AccountType type)
        {
            var account = await CheckAccountAsync(login);

            if (account != null)
            {
                if (PasswordCreator.CreateHash(account.Password) == PasswordCreator.CreateHash(password))
                {
                    return account.MapToDto();
                }
            }

            throw new Exception("Данный аккаунт не существует");
        }

        public async void SaveAsync()
        {
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<Account> CheckAccountAsync(string login)
        {
            return await _unitOfWork.Acconts.Get(x => x.Login == login);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
