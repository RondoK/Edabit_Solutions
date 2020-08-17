using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindrome_Descendant.src
{
    public class Element
    {
        public int[] Digits;

        public Element(int number)
        {
            if (number < 0)
                throw new Exception("number should be > 0");
            Digits = number.ToDigits();
        }

        private Element(params int[] digits)
        {
            Digits = digits;
        }

        public bool IsPalindrome()
        {
            return Digits.SequenceEqual(Digits.Reverse());
        }

        public bool IsPalindromeOrDescendantAre()
        {
            if (IsPalindrome())
                return true;

            var descendant = GetDescendant();
            return descendant != null &&
                   descendant.Digits.Length > 1 &&
                   descendant.IsPalindromeOrDescendantAre();
        }

        /// <summary>
        /// Null if value doesnt't have even number of digits
        /// </summary>
        /// <returns></returns>
        public Element GetDescendant()
        {
            return Digits.Length % 2 == 1 ? null : new Element(CreateDescendant(Digits));
        }

        private static int[] CreateDescendant(params int[] digits)
        {
            var sums = new int[digits.Length / 2];
            for (int resultIndex = 0, strIndex = 0; strIndex < digits.Length; strIndex += 2, resultIndex++)
            {
                sums[resultIndex] = digits[strIndex] + digits[strIndex + 1];
            }

            return sums.ToDigits();
        }

        public override bool Equals(object obj)
        {
            return obj is Element element && element.Digits.SequenceEqual(Digits);
        }
    }

    internal static class Extension
    {
        public static int[] ToDigits(this int number)
        {
            return number.ToString().ToDigits().ToArray();
        }
        public static IEnumerable<int> ToDigits(this string str)
        {
            return str.Select(c => c - '0');
        }

        public static int[] ToDigits(this int[] numbers)
        {
            return numbers.SelectMany(n => n.ToString().ToDigits()).ToArray();
        }
    }
}