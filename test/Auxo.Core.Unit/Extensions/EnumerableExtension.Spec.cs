using System.Collections.Generic;
using Auxo.Extensions;
using NUnit.Framework;

namespace Auxo.Core.Unit.Extensions
{
    [TestFixture]
    public class EnumerableExtension_Each
    {
        [Test]
        public void When_Called_Must_Execute_Each_Item()
        {
            var list = new List<string> {
                "value1", "value2"
            };
            var joined = "";
            EnumerableExtension.Each(list, item => joined += item);
            Assert.AreEqual("value1value2", joined);
        }
    }
}