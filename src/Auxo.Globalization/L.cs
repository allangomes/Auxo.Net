using Auxo.IoC;
using Auxo.Models;

namespace Auxo.Globalization
{
    public static class L
    {
        public static string T(string key) 
        {
            var userConfig = Locator.Service<IUserSetting>();
            return Locales.Get(userConfig.LocaleCode)[key];
        }
        public static bool T(string key, out string value) 
        {
            value = T(key);
            return value != null;
        }
    }
}