using System.Linq.Expressions;

namespace BankingApp.Repository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
