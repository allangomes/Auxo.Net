using System;
using Auxo.Data;
using Auxo.Unit;
using NUnit.Framework;

namespace Auxo.EFCore.Unit
{
    [TestFixture]
    public class Repository_HappyWay
    {
        private IDataContext _ctx;
        private IRepository<Customer> _repo;

        [SetUp]
        public void SetUp()
        {
            _ctx = new DatabaseContextTest();
            _repo = new Repository<Customer>(_ctx);
        }

        [TestCase(0), Order(0)]
        public void Check_If_Count_Is(int expected)
        {
            var records = _repo.Query().FetchAsync().Result;
            Assert.NotNull(records);
            Assert.AreEqual(expected, records.Count);
        }

        [Test, Order(1)]
        public void Check_Insert()
        {
            var customer = new Customer { Name = "Allan", BirthDate = new DateTime(1992, 03, 01) };
            //Assert.Throws<Exception>(() => _repo.Update(customer));
            _repo.Insert(customer);
        }

        [Test, Order(2)]
        public void Check_If_Count_Is_One() => Check_If_Count_Is(1);

        [Test, Order(3)]
        public void Check_Get()
        {
            var customer = _repo.GetAsync(c => c.Name == "Allan").Result;
            Assert.NotNull(customer);
            Assert.AreEqual("Allan", customer.Name);
            Assert.AreEqual(new DateTime(1992, 03, 01), customer.BirthDate);
        }

        [Test, Order(4)]
        public void Check_Update()
        {
            var records = _repo.Query().FetchAsync().Result;
            Assert.NotNull(records);
            Assert.AreEqual(1, records.Count);

            var customer = _repo.GetAsync(c => c.Name == "Allan").Result;
            Assert.NotNull(customer);
            customer.Name = "Allan Gomes";
            //Assert.Catch(() => _repo.Insert(customer));
            _repo.Update(customer);
        }

        [Test, Order(5)]
        public void Check_Delete()
        {
            var customer = _repo.GetAsync(c => c.Name == "Allan Gomes").Result;
            Assert.NotNull(customer);
            _repo.Delete(customer);
        }

        [Test, Order(6)]
        public void Check_If_Count_Is_Zero_Again() => Check_If_Count_Is(0);
    }
}