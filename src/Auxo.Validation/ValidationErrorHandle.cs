using System.Linq;
using Auxo.Events;

namespace Auxo.Validation
{
    public class ValidationErrorHandle : Handle<ValidationError>
    {
        public override object Data() => _messages.ToDictionary(e => e.Property, e => e.Description);
    }
}