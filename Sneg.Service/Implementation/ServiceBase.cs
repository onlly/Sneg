using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Sneg.Data.Entities;
using Sneg.Data.Repositories.Interfaces;
using Sneg.Service.Interfaces;

namespace Sneg.Service.Implementation
{
    public class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        protected readonly IRepository<T> Repository;

        protected ServiceBase(IRepository<T> repository)
        {
            this.Repository = repository;
        }

        protected virtual void Create(T entity)
        {
            Repository.Add(entity);
            Repository.SaveChanges();
        }

        protected virtual Task CreateAsync(T entity)
        {
            Repository.Add(entity);
            return Repository.SaveChangesAsync();
        }

        protected virtual void Update(T entity)
        {
            Repository.Update(entity);
            Repository.SaveChanges();
        }

        protected virtual Task UpdateAsync(T entity)
        {
            Repository.Update(entity);
            return Repository.SaveChangesAsync();
        }

        protected IDisposable BeginTransaction(IsolationLevel isolationLevel)
        {
            return Repository.BeginTransaction(isolationLevel);
        }

        protected void CommitTransaction()
        {
            Repository.CommitTransaction();
        }

        protected void RollBackTransaction()
        {
            Repository.RollbackTransaction();
        }

        protected virtual void Delete(T entity)
        {
            Repository.Delete(entity);
            Repository.SaveChanges();
        }

        protected virtual Task DeleteAsync(T entity)
        {
            Repository.Delete(entity);
            return Repository.SaveChangesAsync();
        }

        protected virtual IEnumerable<T> GetAll()
        {
            return Repository.Query().ToList();
        }
    }
}
