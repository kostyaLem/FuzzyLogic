using FuzzyLogic.DAL.Mappers;
using FuzzyLogic.DAL.Models;
using FuzzyLogic.DAL.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace FuzzyLogic.DAL.Test
{
    [TestFixture]
    public class AccauntTest
    {
        private AccountService _service = TestInitializer.Accounts;

        [Test, Order(1)]
        public void CreateNewAccount_Ok()
        {
            var account = new AccountDto
            {
                Login = "user",
                Password = "user",
                Role = TestInitializer.Context.Roles.First(x => x.Status == (int)AccountType.User).MapToDto()
            };

            _service.CreateAccount(account);
            _service.Save();

            var expectedAccount = _service.GetAccounts().Result.Single(x => x.Login == account.Login);
            Assert.IsNotNull(expectedAccount);
        }

        [Test, Order(2)]
        public async Task ChangeAccauntType_Ok()
        {
            var account = TestInitializer.Context.Accounts.First().MapToDto();
            account.Role = TestInitializer.Context.Roles.First(x => x.Status == (int)AccountType.Admin).MapToDto();

            await _service.UpdateAccount(account);
            _service.Save();

            var expectedAccount = _service.GetAccounts().Result.Single(x => x.Login == account.Login);
            Assert.IsNotNull(expectedAccount);
        }

        [Test, Order(3)]
        public void RemoveExistedAccount_Ok()
        {
            var account = TestInitializer.Context.Accounts.First().MapToDto();

            _service.DeleteAccount(account);
            _service.Save();

            Assert.Zero(TestInitializer.Context.Accounts.Count());
        }
    }
}
