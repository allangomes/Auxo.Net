using System.Collections.Generic;

namespace Auxo.Events
{
    public interface IHandle<T> 
        where T : Message
    {
        string Key { get; }
        object Data();
        void Handle(T args);
        bool Any();
        IList<T> Messages();
    }
}