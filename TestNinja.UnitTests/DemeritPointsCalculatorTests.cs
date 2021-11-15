using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _calculator;
        [SetUp]
        public void SetUp()
        {
            _calculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(310)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowsArgumentOutOfRangeException(int value)
        {
            Assert.That(() => _calculator.CalculateDemeritPoints(value), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(60, 0)]
        [TestCase(80, 3)]
        public void CalculateDemeritPoints_WhenCalled_DemeritPoints(int value, int expectedResult)
        {
            var result = _calculator.CalculateDemeritPoints(value);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
