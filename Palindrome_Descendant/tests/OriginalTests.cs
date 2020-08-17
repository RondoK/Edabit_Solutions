using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Palindrome_Descendant.src;

namespace Palindrome_Descendant.tests
{
	[TestFixture]
    public class OriginalTests
    {
        [Test]
        [TestCase(11211230, ExpectedResult = false , Ignore = "I don't agree it should be false , 11211230 -> 2333 -> 56 -> 11")]
        [TestCase(13001120, ExpectedResult = true)]
        [TestCase(23336014, ExpectedResult = true)]
        [TestCase(11, ExpectedResult = true)]
        [TestCase(1122, ExpectedResult = false)]
        [TestCase(332233, ExpectedResult = true)]
        [TestCase(10210112, ExpectedResult = true)]
        [TestCase(9735, ExpectedResult = false)]
        [TestCase(97358817, ExpectedResult = false)]
        public static bool PalindromeDescendant(int num)
        {
            Console.WriteLine($"Input: {num}");
            return Program.PalindromeDescendant(num);
        }
    }
}
