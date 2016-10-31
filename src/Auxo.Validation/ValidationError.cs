using Auxo.Events;

namespace Auxo.Validation
{
    public class ValidationError : Message
    {
        public string Property { get; set; }
        public string Description { get; set; }

        public static void Raise(string property, string description)
        {
            Message.Raise(new ValidationError { Property = property, Description = description });
        }
    }
}