using System;
using Auxo.Business.Unit.Services;
using Auxo.Data;
using Auxo.Events;
using Auxo.Unit.IoC;
using Auxo.Unit.Models;
using Auxo.Validation;
using Moq;
using NUnit.Framework;

namespace Auxo.Business.Unit
{   
    public class CrudService_Test
    {
        protected Mock<IRepository<Customer>> _repo;
        protected CustomerService _service;

        [SetUp]
        public void SetUp()
        { 
            _repo = new Mock<IRepository<Customer>>();
            _service = new CustomerService(_repo.Object); 
        }
    }

    [TestFixture]
    public class CrudService_Insert : CrudService_Test
    {
        [Test]
        public void When_Invalid_Model_No_Call_Repository()
        {
            FakeContainer.Create().Add<IHandle<ValidationError>>(new Handle<ValidationError>());
            var customer = new Customer { Name = "AG", BirthDate = DateTime.Today.AddYears(-3) };
            _service.Insert(customer);
            _repo.Verify(r => r.Insert(customer), Times.Never);
        }

        [Test]
        public void When_Valid_Model_Call_Repository()
        {
            var customer = new Customer { Name = "Allan Gomes", BirthDate = new DateTime(1992, 03, 01) };
            _service.Insert(customer);
            _repo.Verify(r => r.Insert(customer), Times.Once);
        }
    }

    [TestFixture]
    public class CrudService_Update : CrudService_Test
    {
        [Test]
        public void When_Invalid_Model_No_Call_Repository()
        {
            var customer = new Customer { Name = "AG", BirthDate = DateTime.Today.AddYears(-3) };
            _service.Update(customer);
            _repo.Verify(r => r.Update(customer), Times.Never);
        }

        [Test]
        public void When_Valid_Model_Call_Repository()
        {
            var customer = new Customer { Name = "Allan Gomes", BirthDate = new DateTime(1992, 03, 01) };
            _service.Update(customer);
            _repo.Verify(r => r.Update(customer), Times.Once);
        }
    }

    [TestFixture]
    public class CrudService_Delete : CrudService_Test
    {
        [Test]
        public void When_Valid_Call_Repository()
        {
            var customer = new Customer();
            _service.Delete(customer);
            _repo.Verify(r => r.Delete(customer), Times.Once);
        }
    }
}