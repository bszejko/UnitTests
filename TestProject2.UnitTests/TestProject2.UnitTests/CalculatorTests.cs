using NUnit.Framework;
using TestProject2;

namespace TestProject2.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_WhenCalled_ReturnsSum()
        {
            var result = _calculator.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Subtract_WhenCalled_ReturnsDifference()
        {
            var result = _calculator.Subtract(2, 1);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Multiply_WhenCalled_ReturnsProduct()
        {
            var result = _calculator.Multiply(2, 3);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Divide_DivideByZero_ThrowsDivideByZeroException()
        {
            Assert.That(() => _calculator.Divide(1, 0), Throws.Exception.TypeOf<DivideByZeroException>());
        }

        [Test]
        public void IsEven_WhenCalledWithEvenNumber_ReturnsTrue()
        {
            var result = _calculator.IsEven(2);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsEven_WhenCalledWithOddNumber_ReturnsFalse()
        {
            var result = _calculator.IsEven(3);

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsPrime_WhenCalledWithPrimeNumber_ReturnsTrue()
        {
            var result = _calculator.IsPrime(5);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsPrime_WhenCalledWithNonPrimeNumber_ReturnsFalse()
        {
            var result = _calculator.IsPrime(4);

            Assert.That(result, Is.False);
        }
    }
}
