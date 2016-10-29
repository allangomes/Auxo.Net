using System.Collections.Generic;

namespace Auxo.Core.Extensions
{
    public static class DictionaryExtension
    {
        public static void AddOrSet<TK, TV>(this IDictionary<TK, TV> self, TK key, TV value) 
        {
            if (self.ContainsKey(key))
                self[key] = value;
            else
                self.Add(key, value);
        }
    }
}