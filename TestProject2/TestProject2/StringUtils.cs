using System;
using System.Linq;

namespace TestProject2
{
    public class StringUtils
    {
        public string Reverse(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            return new string(input.Reverse().ToArray());
        }

        public bool IsPalindrome(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            var reversed = new string(input.Reverse().ToArray());
            return string.Equals(input, reversed, StringComparison.OrdinalIgnoreCase);
        }

        public int CountVowels(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            return input.Count(c => "aeiouAEIOU".Contains(c));
        }

        public string ToTitleCase(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
    }
}
