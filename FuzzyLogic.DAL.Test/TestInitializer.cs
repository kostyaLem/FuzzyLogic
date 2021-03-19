using FuzzyLogic.DAL.Models;
using FuzzyLogic.DAL.Services.AccountService;
using FuzzyLogic.DB.Context;
using FuzzyLogic.DB.Context.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FuzzyLogic.DAL.Test
{
    [SetUpFixture]
    public class TestInitializer
    {
        public static FuzzyContext Context;
        public static AccountService Accounts;

        [OneTimeSetUp]
        public static void AssemblyInit()
        {
            Context = new FuzzyContext(new DbContextOptionsBuilder<FuzzyContext>()
                .UseSqlite("DataSource=:memory:").Options);

            Context.ChangeTracker.AutoDetectChangesEnabled = false;

            Context.Database.OpenConnection();
            Context.Database.EnsureCreated();

            var role1 = Context.Roles.Add(new Role() { Name = "Admin", Status = (int)AccountType.Admin });
            var role2 = Context.Roles.Add(new Role() { Name = "User", Status = (int)AccountType.Engineer });
            Context.SaveChanges();

            //role1.State = EntityState.Deleted;
            //role2.State = EntityState.Deleted;

            Accounts = new AccountService(Context);
        }
    }
}
