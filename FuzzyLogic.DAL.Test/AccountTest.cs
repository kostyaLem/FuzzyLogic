using FuzzyLogic.DAL.Mappers;
using FuzzyLogic.DAL.Models;
using FuzzyLogic.DAL.Services;
using FuzzyLogic.DAL.Services.AccountService;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace FuzzyLogic.DAL.Test
{
    [TestFixture]
    public class AccountTest
    {
        private string _login = "user";
        private string _password1 = "user";
        private string _password2 = "user";

        private AccountService _service = TestInitializer.Accounts;

        [Test, Order(1)]
        public async Task CreateNewAccount_Ok()
        {
            var account = await _service.CreateAccount(_login, _password1, AccountType.Engineer);

            var accounts = await _service.GetAccountsAsync();
            var expectedAccount = _service.GetAccountsAsync().Result.Single(x => x.Id == account.Id);
            Assert.IsNotNull(expectedAccount);
        }

        [Test, Order(2)]
        public async Task LoginAccount_Ok()
        {
            var account = await _service.TryLoginAsync(_login, _password1, AccountType.Engineer);

            Assert.IsNotNull(account);
        }

        [Test, Order(3)]
        public async Task ChangeAccauntType_Ok()
        {
            var account = TestInitializer.Context.Accounts.First().MapToDto();
            account.Role = TestInitializer.Context.Roles.First(x => x.Status == (int)AccountType.Admin).MapToDto();

            await _service.UpdateAccountAsync(account);
            _service.SaveAsync();

            var expectedAccount = _service.GetAccountsAsync().Result.Single(x => x.Id == account.Id);
            Assert.IsNotNull(expectedAccount);
        }

        [Test, Order(4)]
        public async Task RemoveExistedAccount_Ok()
        {
            var account = TestInitializer.Context.Accounts.First().MapToDto();

            await _service.DeleteAccountAsync(account);
            _service.SaveAsync();

            Assert.Zero(TestInitializer.Context.Accounts.Count());
        }
    }
}
