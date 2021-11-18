using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        private Mock<IStorage> _storage;
        private OrderService _service;
        private Order _order;
        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IStorage>();
            _service = new OrderService(_storage.Object);
            _order = new Order();
        }
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {            
            _service.PlaceOrder(_order);

            _storage.Verify(x => x.Store(_order));
        }
    }
}
