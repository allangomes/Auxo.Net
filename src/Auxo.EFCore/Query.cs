using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Auxo.Data
{
    public class Query<T> : IQuery<T>
    {
        private IQueryable<T> _query;

        public Query(IQueryable<T> query)
        {
            _query = query;
        }
        public Task<List<T>> FetchAsync()
        {
            return _query.ToListAsync();
        }

        public Task<List<TR>> FetchAsync<TR>(Expression<Func<T, TR>> selector)
        {
            return _query.Select(selector).ToListAsync();
        }

        public IQuery<T> Paginate(int page, int count)
        {
            _query = _query.Skip((page - 1) * count).Take(count);
            return this;
        }

        public IQuery<T> Where(Expression<Func<T, bool>> predicate)
        {
            _query = _query.Where(predicate);
            return this;
        }

        public IQuery<T> Where(string predicate)
        {
            _query = _query.Where(predicate);
            return this;
        }
    }
}