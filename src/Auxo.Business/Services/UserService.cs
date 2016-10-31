using System;
using System.Threading.Tasks;
using Auxo.Data;
using Auxo.Models;

namespace Auxo.Business.Services
{
    public class UserService<T> : CrudService<T>, IUserService<T>
        where T : Entity, IUser
    {
        private readonly IRepository<T> _repository;
        public UserService(IRepository<T> repository) : base(repository)
        {
            _repository = repository;
        }

        public override bool Validate(T model) => true;

        public T Authenticate(string pass, string password)
        {
            var user = _repository.Query()
                .Include(u => u.Password)
                .Where(u => u.Email == pass || u.Login == pass)
                .FetchAsync().Result[0];
            if (user.Password == password)
                return user;
            return null;
        }

        protected virtual void Dispose(bool disposing) => GC.SuppressFinalize(this);

        public void Dispose() => Dispose(true);
    }
}