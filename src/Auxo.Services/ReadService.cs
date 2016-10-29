using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Auxo.Core;
using Auxo.Data;

namespace Auxo.Services
{
    public class ReadService<T> : IReadService<T>
        where T : Entity
    {
        public static Func<object, Expression<Func<T, bool>>> Key = (key) => e => e.Id == Guid.Parse((string) key);
        private readonly IRepository<T> _repository;

        public ReadService(IRepository<T> repository)
        {
            _repository = repository;
        } 

        public Task<T> this[object key] => _repository.GetAsync(Key(key)); 

        public IQuery<T> Query() => _repository.Query();
    }
}