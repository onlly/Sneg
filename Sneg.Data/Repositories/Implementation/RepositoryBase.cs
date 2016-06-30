using Sneg.Data.Context;
using Sneg.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneg.Data.Repositories.Implementation
{
    public abstract class RepositoryBase<T> : IRepository<T> where T:class
    {
        private readonly SnegDbContext _context;
        private DbContextTransaction _contextTransaction;

        protected RepositoryBase(SnegDbContext context)
        {
            _context = context;
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IRepository<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return this;
        }

        public IRepository<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return this;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public virtual IRepository<T> Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return this;
        }

        public virtual IRepository<T> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return this;
        }

        public virtual IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public IDisposable BeginTransaction(IsolationLevel isolationLevel)
        {
            return _contextTransaction = _context.Database.BeginTransaction(isolationLevel);
        }

        public void CommitTransaction()
        {
            _contextTransaction.Commit();
        }
        public void RollbackTransaction()
        {
            _contextTransaction.Rollback();
        }
    }
}
