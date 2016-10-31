using System.Collections.Generic;
using System.Linq;

namespace Auxo.Events
{
    public class Handle<T> : IHandle<T>
        where T : Message
    {
        public virtual string Key => typeof(T).Name;

        protected readonly IList<T> _messages = new List<T>();

        public virtual bool Any()
        {
            return _messages.Any();
        }

        public virtual object Data()
        {
            return _messages;
        }

        public virtual IList<T> Messages()
        {
            return _messages;
        }

        void IHandle<T>.Handle(T message)
        {
            _messages.Add(message);
        }
    }
}