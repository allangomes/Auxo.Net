using Auxo.Models;
using NUnit.Framework;

namespace Auxo.Core.Unit.Entity_TestCase
{
    [TestFixture]
    public class Entity_ImplicitOperator
    {
        [Test]
        public void When_Variable_Null_Return_False()
        {
            Entity model = null;
            Assert.False(model);
        }

        [Test]
        public void When_Variable_Assigned_Return_True()
        {
            Entity model = new Entity();
            Assert.True(model);
        }
    }
}