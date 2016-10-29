using System;
using System.Collections.Generic;
using Auxo.Core;

namespace Auxo.Unit.Core
{
    public class FakeContainer : IContainer
    {
        public readonly IDictionary<Type, object> _instances = new Dictionary<Type, object>();
        
        public object GetService(Type type) => _instances[type];

        public T GetService<T>() where T: class => (T) this.GetService(typeof(T));
    }
}