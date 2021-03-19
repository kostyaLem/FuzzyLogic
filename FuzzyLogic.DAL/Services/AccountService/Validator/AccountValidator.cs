using FuzzyLogic.DAL.Models;
using System;

namespace FuzzyLogic.DAL.Services.AccountService.Validator
{
    public class AccountValidator : IAccountValidator
    {
        public void Validate(AccountDto accountDto)
        {
            if (string.IsNullOrWhiteSpace(accountDto.Login))
                throw new NotImplementedException();

            if (string.IsNullOrWhiteSpace(accountDto.Password))
                throw new NotImplementedException();
        }

        public void Validate(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
