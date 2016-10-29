using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Auxo.Data
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _set;
        public Repository(IDataContext context)
        {
            _context = (DataContext) context;
            _set = _context.Set<T>();
        }

        public IQuery<T> Query() => new Query<T>(_set);

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate) => _set.SingleAsync(predicate);

        public void Insert(T model) 
        {
            if (_context.Entry(model).State == EntityState.Detached)
            {
                _set.Add(model);
                _context.SaveChanges();
            }
        }

        public void Update(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(T model)
        {
            _set.Remove(model);
            _context.SaveChanges();
        }
    }
}