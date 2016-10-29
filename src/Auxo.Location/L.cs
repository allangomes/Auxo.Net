using Auxo.Core;

namespace Auxo.Location
{
    public static class L
    {
        public static string T(string key) 
        {
            var userConfig = Locator.Service<IUserConfiguration>();
            return Locales.Get(userConfig.LocaleCode)[key];
        }
        public static bool T(string key, out string value) 
        {
            value = T(key);
            return value != null;
        }
    }
}