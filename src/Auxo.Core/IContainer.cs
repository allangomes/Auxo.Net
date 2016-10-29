using System;

namespace Auxo.Core
{
    public interface IContainer
    {
        object GetService(Type type);
        T GetService<T>() where T : class;
    }
}