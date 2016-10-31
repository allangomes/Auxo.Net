using System;

namespace Auxo.IoC
{
    public interface IContainer
    {
        object GetService(Type type);
        T GetService<T>() where T : class;
    }
}