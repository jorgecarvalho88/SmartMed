using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtension
{
    public interface IRepositoryBase
    {
        void BeginTransaction();
        int Commit();
        void CommitTransaction();
        TEntity Create<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity);
        IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class;
        void RollBackTransaction();
        void Update<TEntity>(TEntity entity);
    }
}
