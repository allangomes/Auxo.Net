using Auxo.Models;

namespace Auxo.Unit.Core
{
    public class FakeUserSetting : IUserSetting
    {
        public string LocaleCode { get; set; }

        public FakeUserSetting(string localeCode)
        {
            LocaleCode = localeCode;
        }
    }
}