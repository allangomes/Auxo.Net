using Auxo.Core;
using Auxo.Messages;
using Auxo.Unit.Core;

namespace Auxo.Unit.Messages
{
    public static class FakeLocator
    {
        public static IContainer CreateContainer()
        {
            var container = new FakeContainer();
            container._instances.Add(typeof(IMessageHandler<Message>), new MessageHandler());
            return container;   
        }

        public static void Register()
        {
            Locator.Container = Locator.Container ?? CreateContainer();           
        }
    }
}