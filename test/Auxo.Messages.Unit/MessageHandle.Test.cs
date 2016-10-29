using NUnit.Framework;

namespace Auxo.Messages.Unit
{
    [TestFixture]
    public class MessageHandle_Handle
    {
        [Test]
        public void When_Register_Result_HasMessage()
        {
            var handle = new MessageHandler();
            handle.Handle(new Message("TEST_CASE", "TEST_MESSAGE"));
            Assert.True(handle.HasMessages());
        }
    }
}