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
    public class EmployeeControllerTests
    {
        private EmployeeController _controller;
        private Mock<IEmployeeStorage> _storage;

        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IEmployeeStorage>();
            _controller = new EmployeeController(_storage.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            _controller.DeleteEmployee(1);
            _storage.Verify(s => s.Delete(1));
        }

        [Test]
        public void DeleteEmployee_WhenCalled_ReturnRedirectResult()
        {
            var result = _controller.DeleteEmployee(1);
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}
