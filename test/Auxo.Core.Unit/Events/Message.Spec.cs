using Auxo.Events;
using Auxo.IoC;
using Auxo.Unit.IoC;
using NUnit.Framework;

namespace Auxo.Core.Unit.Events
{
    [TestFixture]
    public class Message_Raise
    {
        [Test]
        public void When_Raise_Append_Handle()
        {
            FakeContainer.Create().Add<IHandle<MessageTest>>(new Handle<MessageTest>());
            Message.Raise(new MessageTest("TEST_CASE", "TEST MESSAGE"));
            Assert.AreEqual("MessageTest", Locator.Service<IHandle<MessageTest>>().Key);
            Assert.True(Locator.Service<IHandle<MessageTest>>().Any());
        }
    }
}