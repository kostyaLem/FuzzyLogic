using FuzzyLogic.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FuzzyLogic.DAL.Repositories
{
    internal class BaseRepository<T> : IRepository<T> where T : class
    {
        private bool _disposed;

        readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Get(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            var items = await _dbContext.Set<T>().ToListAsync();

            return await Task.FromResult(items.Where(x => filter.Compile().Invoke(x)));
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing) _dbContext.Dispose();

            _disposed = true;
        }
    }
}
