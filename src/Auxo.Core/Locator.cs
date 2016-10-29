using System;

namespace Auxo.Core
{
    public static class Locator
    {
        public static IContainer Container;
        public static object Service(Type type) => Container?.GetService(type);
        public static T Service<T>() where T: class => Container?.GetService<T>();
    }
}