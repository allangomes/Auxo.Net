using System.Collections.Generic;
using Auxo.Extensions;
using NUnit.Framework;

namespace Auxo.Core.Unit.Extensions
{
    [TestFixture]
    public class DictionaryExtension_AddOrSet
    {
        [Test]
        public void When_Not_Exists_Must_Be_Added() 
        {
            var dic = new Dictionary<string, string>();
            Assert.AreEqual(0, dic.Count);
            DictionaryExtension.AddOrSet(dic, "key", "value");
            Assert.AreEqual(1, dic.Count);
            Assert.AreEqual("value", dic["key"]);
        }

        [Test]
        public void When_Exists_Must_Be_Updated() 
        {
            var dic = new Dictionary<string, string> 
            { 
                { "key", "value" }
            };
            Assert.AreEqual(1, dic.Count);
            DictionaryExtension.AddOrSet(dic, "key", "value modified");
            Assert.AreEqual(1, dic.Count);
            Assert.AreEqual("value modified", dic["key"]);
        }
    }
}