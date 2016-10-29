using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Auxo.Location.Unit
{
    [TestFixture]
    public class Locales_Test
    {
        [Test]
        public void When_File_Not_Exists()
        {
            Assert.Throws<FileNotFoundException>(delegate { Locales.Set("locales", "en", "pt-br"); });
            Assert.Throws<KeyNotFoundException>(delegate { Locales.Get("pt-br"); });
        }

        [Test]
        public void When_File_Exists()
        {
            Locales.Set("locales", "en");
            Assert.NotNull(Locales.Get("en"));
        }
    }
}