using FuzzyLogic.DAL.Models;

namespace FuzzyLogic.DAL.Services.AccountService.Validator
{
    public interface IAccountValidator : IValidator<AccountDto>
    {
        void Validate(string login, string password);
    }
}
