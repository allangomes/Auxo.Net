using FluentValidation;
using Auxo.Messages;

namespace Auxo.Validation
{
    public class Validator<T>: AbstractValidator<T>
    {
        public new bool Validate(T instance)
        {
            var result = base.Validate(instance);
            foreach (var error in result.Errors)
                Message.Raise(new Message("Validation_Error", error.ErrorMessage));
            return result.IsValid;
        }
    }
}