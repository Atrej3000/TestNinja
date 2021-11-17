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
    public class FizzBuzzTests
    {
        

        [Test]
        [TestCase(1, "1")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        public void GetOutput_WhenCalled_ReturnAppropriateStringFizzBuzz(int value, string expectedResult)
        {
            var result = FizzBuzz.GetOutput(value);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
