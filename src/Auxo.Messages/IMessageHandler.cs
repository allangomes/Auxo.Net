using System.Collections.Generic;

namespace Auxo.Messages
{
    public interface IMessageHandler<T> 
        where T : Message
    {
        void Handle(T args);
        bool HasMessages();
        IList<Message> Messages();
    }
}