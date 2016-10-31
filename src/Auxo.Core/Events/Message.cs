using Auxo.Exceptions;
using Auxo.IoC;

namespace Auxo.Events
{
    public class Message
    {
        public static void Raise<T>(T message) where T : Message
        {
            if (Locator.Container != null)
                Locator.Service<IHandle<T>>().Handle(message);
            else
                throw new ContainerNotRegistered();
        }   
    }
}