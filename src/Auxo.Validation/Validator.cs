namespace Auxo.Validation
{
    using FluentValidation;
    
    public class Validator<T>: AbstractValidator<T>
    {
        public new bool Validate(T instance)
        {
            var result = base.Validate(instance);
            foreach (var error in result.Errors)
                ValidationError.Raise(error.PropertyName, error.ErrorMessage);
            return result.IsValid;
        }
    }
}