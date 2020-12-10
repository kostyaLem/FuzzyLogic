using FuzzyLogic.DAL.Interfaces;
using FuzzyLogic.DAL.Repositories;
using FuzzyLogic.DB.Context.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FuzzyLogic.DAL.Services
{
    internal class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private bool _disposed;

        private Lazy<IRepository<Account>> _accountRepo;
        private Lazy<IRepository<Material>> _materialRepo;
        private Lazy<IRepository<MaterialColor>> _materialColorRepo;
        private Lazy<IRepository<Report>> _reportRepo;
        private Lazy<IRepository<Role>> _roleRepo;

        public TContext DbContext { get; }

        public UnitOfWork(TContext dbContext)
        {
            DbContext = dbContext;

            DbContext.Database.OpenConnection();
            DbContext.Database.EnsureCreated();

            _accountRepo = new Lazy<IRepository<Account>>(() => new BaseRepository<Account>(DbContext));
            _materialRepo = new Lazy<IRepository<Material>>(() => new BaseRepository<Material>(DbContext));
            _materialColorRepo = new Lazy<IRepository<MaterialColor>>(() => new BaseRepository<MaterialColor>(DbContext));
            _reportRepo = new Lazy<IRepository<Report>>(() => new BaseRepository<Report>(DbContext));
            _roleRepo = new Lazy<IRepository<Role>>(() => new BaseRepository<Role>(DbContext));
        }

        public IRepository<Account> Acconts => _accountRepo.Value;
        public IRepository<Material> Materials => _materialRepo.Value;
        public IRepository<MaterialColor> MaterialColors => _materialColorRepo.Value;
        public IRepository<Report> Reports => _reportRepo.Value;
        public IRepository<Role> Roles => _roleRepo.Value;

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                // _repositories?.Clear();

                DbContext.Dispose();
            }

            _disposed = true;

            GC.SuppressFinalize(this);
        }
    }
}
