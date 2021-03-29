using FuzzyLogic.DAL.Mappers;
using FuzzyLogic.DAL.Models;
using FuzzyLogic.DAL.Services.AccountService;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace FuzzyLogic.DAL.Test
{
    [TestFixture]
    public class AccountServiceScenarioTest
    {
        private string _login = "user";
        private string _password1 = "user";

        private AccountService _service = TestInitializer.Accounts;

        [Test, Order(1)]
        public async Task CreateNewAccount_Ok()
        {
            //Act
            var account = await _service.CreateAccount(_login, _password1, AccountType.Engineer);

            //Assert
            var expectedAccount = _service.GetAccountsAsync().Result.Single(x => x.Id == account.Id);
            Assert.IsNotNull(expectedAccount);
        }

        [Test, Order(2)]
        public async Task LoginAccount_Ok()
        {
            //Act
            var account = await _service.TryLoginAsync(_login, _password1, AccountType.Engineer);

            //Assert
            Assert.IsNotNull(account);
        }

        [Test, Order(3)]
        public async Task ChangeAccountType_Ok()
        {
            //Arrange
            var account = TestInitializer.Context.Accounts.First().MapToDto();
            account.Role = TestInitializer.Context.Roles.First(x => x.Status == (int)AccountType.Admin).MapToDto();

            //Act
            await _service.UpdateAccountAsync(account);
            _service.SaveAsync();

            //Assert
            var expectedAccount = _service.GetAccountsAsync().Result.Single(x => x.Id == account.Id);
            Assert.IsNotNull(expectedAccount);
        }

        [Test, Order(4)]
        public async Task RemoveExistedAccount_Ok()
        {
            //Arrange
            var account = TestInitializer.Context.Accounts.First().MapToDto();

            //Act
            await _service.DeleteAccountAsync(account);
            _service.SaveAsync();

            //Assert
            Assert.Zero(TestInitializer.Context.Accounts.Count());
        }
    }
}
