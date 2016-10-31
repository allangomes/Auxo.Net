using NUnit.Framework;
using FluentValidation;
using Auxo.Unit.Models;
using Auxo.Core.Extensions;
using Auxo.Unit.IoC;
using Auxo.Events;
using Auxo.IoC;

namespace Auxo.Validation.Unit
{
    public class CustomerValidator : Validator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(model => model.Name).NotEmpty().Length(5, 100);
            RuleFor(model => model.BirthDate).InclusiveBetween((-150).Years(), (-18).Years());
        }
    }

    [TestFixture]
    public class Validator_Validate
    {
        [Test]
        public void When_Invalid_Raise_Messages()
        {
            var validator = new CustomerValidator();
            var customer = new Customer();

            FakeContainer.Create().Add<IHandle<ValidationError>>(new ValidationErrorHandle());

            Assert.False(validator.Validate(customer));
            var handle = Locator.Service<IHandle<ValidationError>>();
            Assert.True(handle.Any());
        }
    }
}