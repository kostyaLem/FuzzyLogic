using FuzzyLogic.DAL.Mappers;
using FuzzyLogic.DAL.Models;
using FuzzyLogic.DAL.Services.AccountService.Validator;
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
        private readonly UnitOfWork<FuzzyContext> _unitOfWork;
        private readonly IAccountValidator _validator;

        public AccountService(FuzzyContext debugContext, IAccountValidator accountValidator)
        {
            _unitOfWork = new UnitOfWork<FuzzyContext>(debugContext);
            _validator = accountValidator;
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _unitOfWork.Roles.GetAll();
        }

        public async Task<AccountDto> CreateAccount(string login, string password, AccountType type)
        {
            _validator.Validate(login, password);

            var account = await CheckAccountAsync(login);

            if (account == null)
            {
                account = new Account
                {
                    Login = login,
                    Password = password,
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
            _validator.Validate(accountDto);

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
            _validator.Validate(login, password);

            var account = await CheckAccountAsync(login);

            if (account != null)
            {
                if (account.Password == PasswordCreator.CreateHash(password))
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
            var accounts = (await _unitOfWork.Acconts.GetAll()).ToList();
            return accounts.SingleOrDefault(a => string.Equals(a.Login, login, StringComparison.OrdinalIgnoreCase));
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
