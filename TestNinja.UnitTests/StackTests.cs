using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;
        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        [TestCase(null)]
        public void Push_PassNullObject_ThrowsArgumentNullException(string value)
        {
            Assert.That(() => _stack.Push(value), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase("test", 1)]
        public void Push_WhenCalled_AddNewItem(string value, int expectedResult)
        {
            _stack.Push(value);

            var result = _stack.Count;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Pop_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("test", "test")]
        public void Pop_WhenCalled_RemoveTopElement(string value, string expectedResult)
        {
            _stack.Push(value);

            var result = _stack.Pop();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("test", 1)]
        public void Pop_WhenCalled_RemoveTopElement(string value, int expectedResult)
        {
            _stack.Push(value);
            _stack.Push(value);

            _stack.Pop();
            var result = _stack.Count;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Peek_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("test1", "test2", "test2")]
        public void Peek_WhenCalled_ReturnTopElement(string firstValue, string secondValue, string expectedResult)
        {
            _stack.Push(firstValue);
            _stack.Push(secondValue);

            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("test1", "test2", 2)]
        public void Peek_WhenCalled_DoesNotRemoveTopElement(string firstValue, string secondValue, int expectedResult)
        {
            _stack.Push(firstValue);
            _stack.Push(secondValue);

            _stack.Peek();
            var result = _stack.Count;


            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
