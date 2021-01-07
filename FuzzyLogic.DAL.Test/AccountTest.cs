using FuzzyLogic.DAL.Mappers;
using FuzzyLogic.DAL.Models;
using FuzzyLogic.DAL.Services;
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
            var account = await _service.CreateAccount(_login, _password1, _password2, AccountType.Engineer);

            var accounts = await _service.GetAccounts();
            var expectedAccount = _service.GetAccounts().Result.Single(x => x.Id == account.Id);
            Assert.IsNotNull(expectedAccount);
        }

        [Test, Order(2)]
        public async Task LoginAccount_Ok()
        {
            var account = await _service.TryLogin(_login, _password1, AccountType.Engineer);

            Assert.IsNotNull(account);
        }

        [Test, Order(3)]
        public async Task ChangeAccauntType_Ok()
        {
            var account = TestInitializer.Context.Accounts.First().MapToDto();
            account.Role = TestInitializer.Context.Roles.First(x => x.Status == (int)AccountType.Admin).MapToDto();

            await _service.UpdateAccount(account);
            _service.Save();

            var expectedAccount = _service.GetAccounts().Result.Single(x => x.Id == account.Id);
            Assert.IsNotNull(expectedAccount);
        }

        [Test, Order(4)]
        public async Task RemoveExistedAccount_Ok()
        {
            var account = TestInitializer.Context.Accounts.First().MapToDto();

            await _service.DeleteAccount(account);
            _service.Save();

            Assert.Zero(TestInitializer.Context.Accounts.Count());
        }
    }
}
