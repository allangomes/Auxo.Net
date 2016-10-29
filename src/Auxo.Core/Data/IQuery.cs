using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Auxo.Data
{
    public interface IQuery<T>
    {
        IQuery<T> Where(string predicate);
        IQuery<T> Where(Expression<Func<T, bool>> predicate);
        IQuery<T> Paginate(int page, int count);
        Task<List<T>> FetchAsync();
        Task<List<TR>> FetchAsync<TR>(Expression<Func<T, TR>> selector);
    }
}