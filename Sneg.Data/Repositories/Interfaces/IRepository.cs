using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T: class
    {
        T GetById(int id);
        IRepository<T> Add(T entity);
        IRepository<T> AddRange(IEnumerable<T> entities);
        void DeleteRange(IEnumerable<T> entities);
        IRepository<T> Update(T entity);
        IRepository<T> Delete(T entity);
        IQueryable<T> Query();
        void SaveChanges();
        Task SaveChangesAsync();
        IDisposable BeginTransaction(IsolationLevel isolationLevel);
        void CommitTransaction();
        void RollbackTransaction();
    }
}
