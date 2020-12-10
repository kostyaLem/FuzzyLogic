using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FuzzyLogic.DAL.Interfaces
{
    internal interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        TContext DbContext { get; }

        Task<int> SaveChangesAsync();
    }
}
