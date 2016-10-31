using System.Collections.Generic;
using Auxo.Extensions;

namespace Auxo.Globalization
{
    public static class Locales
    {
        private static readonly IDictionary<string, Locale> _locales = new Dictionary<string, Locale>();

        public static void Set(string path, params string[] locales) => locales.Each(locale => _locales.AddOrSet(locale, new Locale($"{path}/{locale}.json")));

        public static Locale Get(string locale) => _locales[locale];
    }
}