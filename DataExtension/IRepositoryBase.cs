using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtension
{
    public interface IRepositoryBase
    {
        Task BeginTransaction();
        Task<int> Commit();
        Task CommitTransaction();
        TEntity Create<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity);
        IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class;
        Task RollBackTransaction();
        void Update<TEntity>(TEntity entity);
    }
}
