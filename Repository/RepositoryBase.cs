using BankingApp.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankingApp.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected BRileyDbContext _repositoryContext { get; set; }

        public RepositoryBase(BRileyDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public void Create(T entity)
        {
            this._repositoryContext.Set<T>().Add(entity);
            this._repositoryContext.SaveChanges();
        }

        public async Task CreateAsync(T entity)
        {
            await this._repositoryContext.Set<T>().AddAsync(entity);
            await this._repositoryContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            this._repositoryContext.Set<T>().Remove(entity);
            this._repositoryContext.SaveChanges();
        }

        public IQueryable<T> FindAll()
        {
            return this._repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return this._repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this._repositoryContext.Set<T>().Update(entity);
            this._repositoryContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            this._repositoryContext.Set<T>().Update(entity);
            //  this._repositoryContext.Entry(entity).State = EntityState.Detached;
            await this._repositoryContext.SaveChangesAsync();
        }
    }
}
