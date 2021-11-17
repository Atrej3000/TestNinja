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
    public class HtmlFormatterTests
    {
        private HtmlFormatter _htmlFormatter;
        [SetUp]
        public void SetUp()
        {
            _htmlFormatter = new HtmlFormatter();
        }
        [Test]
        [TestCase("<strong>", "abc", "</strong>")]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement(string startWith, string contains, string endWith)
        {
            var result = _htmlFormatter.FormatAsBold(contains);

            Assert.That(result, Does.StartWith(startWith));
            Assert.That(result, Does.Contain(contains));
            Assert.That(result, Does.EndWith(endWith));
        }
    }
}
