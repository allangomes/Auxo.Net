using Auxo.Core;

namespace Auxo.Messages
{
    public class Message
    {
        public string Kind { get; private set; }
        public string Value { get; private set; }
        
        public Message(string kind, string value)
        {
            Kind = kind;
            Value = value;
        }

        public static void Raise<T>(T message) where T : Message
        {
            if (Locator.Container != null)
            {
                var obj = Locator.Service<IMessageHandler<T>>();
                ((IMessageHandler<T>) obj).Handle(message);
            }
        }   
    }
}