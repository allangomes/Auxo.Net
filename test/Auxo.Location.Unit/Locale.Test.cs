using System.IO;
using NUnit.Framework;

namespace Auxo.Location.Unit
{
    [TestFixture]
    public class Locale_Test
    {
        [Test]
        public void When_File_Not_Exists()
        {
            Assert.Throws<FileNotFoundException>(delegate { new Locale("locales/not_exists.json"); });
        }

        [Test]
        public void When_Key_Exists_Return_Value()
        {
            var l = new Locale("locales/en.json");
            Assert.AreEqual("Not Empty", l["validations.not_empty"]);
        }

        [Test]
        public void When_Key_Not_Exists_Return_Null()
        {
            var l = new Locale("locales/en.json");
            Assert.Null(l["not_exists_key"]);
        }
    }
}