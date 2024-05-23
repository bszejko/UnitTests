using NUnit.Framework;
using NUnit.Framework.Internal;
using TestProject2;

namespace TestProject2.UnitTests
{
    [TestFixture]
    public class StringUtilsTests
    {
        private StringUtils _stringUtils;

        [SetUp]
        public void SetUp()
        {
            _stringUtils = new StringUtils();
        }

        [Test]
        public void Reverse_WhenCalled_ReturnsReversedString()
        {
            var result = _stringUtils.Reverse("abc");

            Assert.That(result, Is.EqualTo("cba"));
        }

        [Test]
        public void Reverse_InputIsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => _stringUtils.Reverse(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void IsPalindrome_PalindromeString_ReturnsTrue()
        {
            var result = _stringUtils.IsPalindrome("Madam");

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsPalindrome_NonPalindromeString_ReturnsFalse()
        {
            var result = _stringUtils.IsPalindrome("Hello");

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsPalindrome_InputIsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => _stringUtils.IsPalindrome(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void CountVowels_WhenCalled_ReturnsVowelCount()
        {
            var result = _stringUtils.CountVowels("Hello");

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void CountVowels_InputIsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => _stringUtils.CountVowels(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ToTitleCase_WhenCalled_ReturnsTitleCaseString()
        {
            var result = _stringUtils.ToTitleCase("hello world");

            Assert.That(result, Is.EqualTo("Hello World"));
        }

        [Test]
        public void ToTitleCase_InputIsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => _stringUtils.ToTitleCase(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }
}
