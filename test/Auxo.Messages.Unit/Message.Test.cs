using Auxo.Core;
using Auxo.Unit.Messages;
using NUnit.Framework;

namespace Auxo.Messages.Unit
{
    [TestFixture]
    public class Message_Constructor
    {
        [Test]
        public void When_Called_Set_Properties()
        {
            var message = new Message("key", "value");
            Assert.AreEqual("key", message.Kind);
            Assert.AreEqual("value", message.Value);
        }
    }

    [TestFixture]
    public class Message_Raise
    {
        [Test]
        public void When_Raise_Append_Handle()
        {
            FakeLocator.Register();
            Message.Raise(new Message("TEST_CASE", "TEST MESSAGE"));
            Assert.True(Locator.Service<IMessageHandler<Message>>().HasMessages());
        }
    }
}