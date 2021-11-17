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
    public class ErrorLoggerTests
    {
        private ErrorLogger _errorlogger;
        [SetUp]
        public void SetUp()
        {
            _errorlogger = new ErrorLogger();
        }
        [Test]
        [TestCase("test", "test")]
        public void Log_WhenCalled_ChangeLastErrorProperty(string value, string expectedResult)
        {
            _errorlogger.Log(value);
            var result = _errorlogger.LastError;

            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string value)
        {
            Assert.That(() => _errorlogger.Log(value), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase("test")]
        public void Log_WhenCalled_RaiseErrorLoggedEvent(string value)
        {
            var id = Guid.Empty;
            _errorlogger.ErrorLogged += (sender, args) => { id = args; };

            _errorlogger.Log(value);

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
