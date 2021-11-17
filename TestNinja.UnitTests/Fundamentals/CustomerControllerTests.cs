using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _customerController;
        [SetUp]
        public void SetUp()
        {
            _customerController = new CustomerController();
        }

        [Test]
        [TestCase(0, typeof(NotFound))]
        [TestCase(1, typeof(Ok))]
        public void GetCustomer_WhenCalled_ReturnsExpectedType(int id, Type expectedResult)
        {
            var result = _customerController.GetCustomer(id);

            Assert.That(result, Is.TypeOf(expectedResult));
        }
    }
}
