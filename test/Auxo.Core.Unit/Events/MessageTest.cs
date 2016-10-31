using Auxo.Events;

namespace Auxo.Core.Unit.Events
{
    public class MessageTest : Message
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public MessageTest(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}