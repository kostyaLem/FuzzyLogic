using FuzzyLogic.DAL.Mappers;
using FuzzyLogic.DAL.Models;
using FuzzyLogic.DAL.Utils;
using FuzzyLogic.DB.Context;
using FuzzyLogic.DB.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuzzyLogic.DAL.Services
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

        public void CreateAccount(AccountDto accountDto)
        {
            var account = accountDto.MapToEntity();
            account.Password = PasswordCreator.CreatePasswordHash(account.Password);
            account.Role = _unitOfWork.DbContext.Roles.First(x => x.Id == accountDto.Role.Id);

            _unitOfWork.Acconts.Create(account);
            _unitOfWork.SaveChangesAsync().Wait();

            accountDto.Id = account.Id;
        }

        public async Task DeleteAccount(AccountDto accountDto)
        {
            var account = await _unitOfWork.Acconts.Get(accountDto.Id);

            _unitOfWork.Acconts.Delete(account);
        }

        public async Task UpdateAccount(AccountDto accountDto)
        {
            var account = await _unitOfWork.Acconts.Get(accountDto.Id);
            account.Role = _unitOfWork.DbContext.Roles.First(x => x.Id == accountDto.Role.Id);

            _unitOfWork.Acconts.Update(account);
        }

        public async Task<IEnumerable<AccountDto>> GetAccounts()
        {
            return await GetAccounts(_ => true);
        }

        public async Task<IEnumerable<AccountDto>> GetAccounts(Func<AccountDto, bool> filter)
        {
            return (await _unitOfWork.Acconts.GetAll(x => filter(x.MapToDto()))).Select(x => x.MapToDto());
        }

        public async Task<AccountDto> TryLogin(string login, string password)
        {
            var account = await _unitOfWork.Acconts.Get(x => x.Login == login);

            if (account != null)
            {
                if (account.Password == PasswordCreator.CreatePasswordHash(password))
                {
                    return account.MapToDto();
                }
            }

            return default;
        }

        public async void Save()
        {
            await _unitOfWork.SaveChangesAsync();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
