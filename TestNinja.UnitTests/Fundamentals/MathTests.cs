using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(2, 2, 4)]
        [TestCase(2, 3, 5)]

        public void Add_WhenCalled_ReturnTheSumOfArguments(int firstValue, int secondValue, int expectedResult)
        {
            int result = _math.Add(firstValue, secondValue);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(3, 2, 3)]
        [TestCase(1, 3, 3)]
        [TestCase(3, 3, 3)]

        public void Max_WhenCalled_ReturnTheGreaterArgument(int firstValue, int secondValue, int expectedResult)
        {
            int result = _math.Max(firstValue, secondValue);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(5, new[] { 1, 3, 5 })]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumberUpToLimit(int limit, IEnumerable<int> expectedResult)
        {
            var result = _math.GetOddNumbers(limit);

            Assert.That(result, Is.EquivalentTo(expectedResult));
            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]

        public void GetOddNumbers_LimitIsEqualOrLessThanZero_ReturnEmptyArray(int limit)
        {
            var result = _math.GetOddNumbers(limit);

            Assert.That(result, Is.Empty);
        }
    }
}
