using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Auxo.Data
{
    public interface IRepository<T>
    {
        IQuery<T> Query();
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        void Insert(T model);
        void Update(T model);
        void Delete(T model);
    }
}