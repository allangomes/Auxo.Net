using Auxo.Models;
using Auxo.Data;
using System;

namespace Auxo.Business.Services
{
    public class CrudService<T> : ReadService<T>, ICrudService<T>
        where T: Entity
    {
        private readonly IRepository<T> _repository;
        public CrudService(IRepository<T> repository) : base(repository)
        {
            _repository = repository;
        }

        public virtual bool Validate(T model) => false;

        public T New() => Activator.CreateInstance<T>();

        public virtual void Insert(T model)
        {
            if (Validate(model))
                _repository.Insert(model);
        }

        public virtual void Update(T model)
        {
            if (Validate(model))
                _repository.Update(model);
        }

        public virtual void Delete(T model) => _repository.Delete(model);
    }
}