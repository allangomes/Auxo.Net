using System;
using Auxo.Extensions;
using NUnit.Framework;

namespace Auxo.Core.Unit.Extensions
{
    [TestFixture]
    public class GuidExtension_IsEmpty
    {
        [Test]
        public void When_Empty_Return_True()
        {
            Guid id;
            Assert.True(id.IsEmpty());
        }
        
        [Test]
        public void When_Not_Empty_Return_False()
        {
            Guid id = Guid.NewGuid();
            Assert.False(id.IsEmpty());
        }
    }
}