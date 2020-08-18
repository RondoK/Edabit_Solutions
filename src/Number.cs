using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Number
    {
        public int[] Digits { get; }
        private int? _number;

        /// <summary>
        /// number should be >= 0
        /// </summary>
        /// <param name="number"> </param>
        public static Number Create(int number)
        {
            return new Number(number);
        }

        public int GetNumber()
        {
            if (_number == null)
                _number = Digits.DigitsToInt();
            return _number.Value;
        }

        public bool IsPalindrome()
        {
            return Digits.SequenceEqual(Digits.Reverse());
        }

        public bool IsPalindromeOrDescendantIs()
        {
            if (IsPalindrome())
                return true;

            var descendant = GetDescendant();
            return descendant != null &&
                   descendant.Digits.Length > 1 &&
                   descendant.IsPalindromeOrDescendantIs();
        }

        /// <summary>
        /// Null if value doesnt't have even number of digits
        /// </summary>
        /// <returns></returns>
        private Number GetDescendant()
        {
            if (Digits.Length > 2 &&
                Digits.Length % 2 == 0)
                return new Number(CreateDescendant(Digits));
            else
                return null;
        }

        /// <summary>
        /// Empty if no descendants
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<Number> GetDescendants()
        {
            var list = new List<Number>();
            var currentNumber = this;
            do
            {
                currentNumber = currentNumber.GetDescendant();
                if (currentNumber == null)
                    break;

                list.Add(currentNumber);
            } while (true);

            return list;
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

        private Number(int number)
        {
            if (number < 0)
                throw new Exception("number should be > 0");
            _number = number;
            Digits = number.ToDigits();
        }

        private Number(params int[] digits)
        {
            Digits = digits;
        }

        public override bool Equals(object obj)
        {
            return obj is Number element && element.Digits.SequenceEqual(Digits);
        }

        public override int GetHashCode()
        {
            return GetNumber().GetHashCode();
        }
    }

    internal static class Extension
    {
        public static IEnumerable<int> ToDigits(this string str)
        {
            return str.Select(c => c - '0');
        }

        public static int DigitsToInt(this IEnumerable<int> digits)
        {
            return int.Parse(string.Concat(digits));
        }
        public static int[] ToDigits(this int number)
        {
            return number.ToString().ToDigits().ToArray();
        }
        public static int[] ToDigits(this int[] numbers)
        {
            return numbers.SelectMany(n => n.ToString().ToDigits()).ToArray();
        }
    }
}