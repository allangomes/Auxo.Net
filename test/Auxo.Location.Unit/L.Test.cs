using System;
using System.Collections.Generic;
using Auxo.Core;
using Auxo.Unit.Core;
using NUnit.Framework;

namespace Auxo.Location.Unit
{
    [TestFixture]
    public class L_Test
    {
        public FakeContainer CreateContainerWithConfig(string lang)
        {
            var fakeContainer = new FakeContainer();
            fakeContainer._instances.Add(typeof(IUserConfiguration), new FakeUserConfiguration(lang));
            return fakeContainer;
        }

        [Test]
        public void When_Container_Is_Null()
        {
            Locales.Set("locales", "en");
            Locator.Container = null;
            Assert.Throws<NullReferenceException>(() => L.T("validations.not_empty"));
        }

        [Test]
        public void When_Container_Assigned_But_Service_Not_Registered()
        {
            Locales.Set("locales", "en");
            Locator.Container = new FakeContainer();
            Assert.Throws<KeyNotFoundException>(() => L.T("validations.not_empty"));
        }

        [Test]
        public void When_Config_User_Localized_But_Without_Locale_Code()
        {
            Locales.Set("locales", "en");
            Locator.Container = CreateContainerWithConfig("");
            Assert.Throws<KeyNotFoundException>(() => L.T("validations.not_empty"));
        }

        [Test]
        public void When_Config_User_Localized_With_Locale_Code()
        {
            Locales.Set("locales", "en");
            Locator.Container = CreateContainerWithConfig("en");
            Assert.AreEqual("Not Empty", L.T("validations.not_empty"));
        }
    }
}