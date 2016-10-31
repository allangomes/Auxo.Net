using System;
using System.Collections.Generic;
using Auxo.Events;

namespace Auxo.Extensions
{
    public static class EnumerableExtension
    {
        public static void Each<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var item in self)
                action(item);
        }

        public static void Raise<T>(this IEnumerable<T> messages)
            where T: Message
        {
            messages.Each(msg => Message.Raise(msg));
        }
    }
}