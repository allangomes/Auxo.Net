using NUnit.Framework;
using FluentValidation;
using Auxo.Core;
using Auxo.Messages;
using Auxo.Unit.Core;

namespace Auxo.Validation.Unit
{
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class CustomerValidator : Validator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(model => model.Name).NotEmpty().Length(5, 100);
            RuleFor(model => model.Age).InclusiveBetween(18, 150);
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

            var fakeContainer = new FakeContainer();
            fakeContainer._instances.Add(typeof(IMessageHandler<Message>), new MessageHandler()); 
            Locator.Container = fakeContainer;

            Assert.False(validator.Validate(customer));
            var messages = Locator.Service<IMessageHandler<Message>>();
            Assert.True(messages.HasMessages());
        }
    }
}