using System.Collections.Generic;
using Auxo.Core.Extensions;

namespace Auxo.Messages.Extensions
{
    public static class ListExtensions
    {
        public static void Raise<T>(this IEnumerable<T> messages)
            where T: Message
        {
            messages.Each(msg => Message.Raise(msg));
        }
    }
}