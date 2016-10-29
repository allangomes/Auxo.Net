using System.Collections.Generic;

namespace Auxo.Messages
{
    public class MessageHandler : IMessageHandler<Message>
    {
        private readonly IList<Message> _notifications = new List<Message>();

        public void Handle(Message message)
        {
            _notifications.Add(message);
        }

        public IList<Message> Messages()
        {
            return _notifications;
        }
        
        public bool HasMessages()
        {
            return _notifications.Count > 0;
        }
    }
}