using FuzzyLogic.DAL.Mappers;
using FuzzyLogic.DAL.Models;
using FuzzyLogic.DB.Context;
using FuzzyLogic.DB.Context.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuzzyLogic.DAL.Services
{
    public sealed class AccountService : IDisposable
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
            account.Role = _unitOfWork.DbContext.Roles.First(x => x.Id == accountDto.Role.Id);

            _unitOfWork.Acconts.Create(account);
        }

        public void DeleteAccount(AccountDto accountDto)
        {
            _unitOfWork.Acconts.Delete(accountDto.MapToEntity());
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

        public async Task<IEnumerable<AccountDto>> GetAccounts(Func<Account, bool> filter)
        {
            var acc = await _unitOfWork.Acconts.GetAll(x => filter(x));

            return (await _unitOfWork.Acconts.GetAll(x => filter(x))).Select(x => x.MapToDto());
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
