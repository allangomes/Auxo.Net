using System;

namespace Auxo.Business
{
    public interface IUserService<T> : ICrudService<T>, IDisposable
    {
        T Authenticate(string user, string password);
    }
}