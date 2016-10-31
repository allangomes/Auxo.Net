using System;
using Auxo.Business.Services;
using Auxo.Data;
using Auxo.Unit.Models;
using Auxo.Validation;
using FluentValidation;

namespace Auxo.Business.Unit.Services
{
    public class CustomerService : CrudService<Customer>
    {
        public override bool Validate(Customer model)
        {
            var v = new Validator<Customer>();
            v.CascadeMode = CascadeMode.StopOnFirstFailure;
            v.RuleFor(c => c.Name).NotEmpty().Length(5, 100);
            v.RuleFor(c => c.BirthDate).GreaterThanOrEqualTo(DateTime.Today.AddYears(-150)).LessThanOrEqualTo(DateTime.Today.AddYears(-18));
            return v.Validate(model);
        } 

        public CustomerService(IRepository<Customer> repository) : base(repository)
        {
        }
    }
}