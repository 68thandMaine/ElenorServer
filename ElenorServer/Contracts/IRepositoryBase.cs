using System;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        // CRUD for all Models
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        // DB cleanup method
        void ClearAll(string tableName);
    }
}
