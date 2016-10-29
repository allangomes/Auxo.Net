using Auxo.Core;

namespace Auxo.Unit.Core
{
    public class FakeUserConfiguration : IUserConfiguration
    {
        public string LocaleCode { get; set; }

        public FakeUserConfiguration(string localeCode)
        {
            LocaleCode = localeCode;
        }
    }
}