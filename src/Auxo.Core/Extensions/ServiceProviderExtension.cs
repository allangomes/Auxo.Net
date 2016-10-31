using System;

namespace Auxo.Core.Extensions
{
    public static class ServiceProviderExtension
    {
        public static T GetService<T>(this IServiceProvider services) => (T) services.GetService(typeof(T));
    }
}