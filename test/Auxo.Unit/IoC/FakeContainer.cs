using System;
using System.Collections.Generic;
using Auxo.IoC;

namespace Auxo.Unit.IoC
{
    public class FakeContainer : IContainer
    {
        public readonly IDictionary<Type, object> _instances = new Dictionary<Type, object>();

        public FakeContainer()
        {
            Locator.Container = this;
        }
        
        public object GetService(Type type) => _instances[type];

        public T GetService<T>() where T: class => (T) this.GetService(typeof(T));

        public void Add<T>(T instance) where T: class => _instances.Add(typeof(T), instance);

        public static FakeContainer Create()
        {
            return new FakeContainer();
        }
    }
}