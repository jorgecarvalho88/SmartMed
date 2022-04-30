using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtension
{
    public class RepositoryBase : IRepositoryBase
    {
        private DbContext context;

        public RepositoryBase(DbContext context)
        {
            this.context = context;
        }

        public async Task BeginTransaction()
        {
            await context.Database.BeginTransactionAsync();
        }

        public TEntity Create<TEntity>(TEntity entity) where TEntity : class
        {
            return context.Add(entity).Entity;
        }

        public void Update<TEntity>(TEntity entity)
        {
            context.Update(entity);
        }

        public void Delete<TEntity>(TEntity entity)
        {
            context.Remove(entity);
        }

        public async Task<int> Commit()
        {
            return await context.SaveChangesAsync();
        }

        public async Task CommitTransaction()
        {
            await context.Database.CurrentTransaction?.CommitAsync();
        }

        public async Task RollBackTransaction()
        {
            await context.Database.CurrentTransaction?.RollbackAsync();
        }

        public virtual IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>();
        }
    }
}
