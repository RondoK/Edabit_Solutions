using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using Domain;

namespace UnitTests.Number_
{
    [TestFixtureSource("Fixtures")]
    public class Number_
    {
        private Number element;
        private bool isPalindrome;
        private bool isPalindromeOrDescendantIs;

        public Number_(int number, bool isPalindrome, bool isPalindromeOrDescendantIs)
        {
            element = Number.Create(number);
            this.isPalindrome = isPalindrome;
            this.isPalindromeOrDescendantIs = isPalindromeOrDescendantIs;
        }

        [Test]
        public void IsPalindrome()
        {
            element.IsPalindrome()
                    .Should().Be(isPalindrome);
        }

        [Test]
        public void IsPalindromeOrDescendantIs()
        {
            element.IsPalindromeOrDescendantIs()
                    .Should().Be(isPalindromeOrDescendantIs);
        }

        static IEnumerable Fixtures
        {
            get
            {
                yield return Test(0, true, true);
                yield return Test(3, true, true);
                yield return Test(11, true, true);
                yield return Test(12, false, false);
                yield return Test(111, true, true);
                yield return Test(1122, false, false);
                yield return Test(2121, false, true);
                yield return Test(5601, false, true);
                yield return Test(6556, true, true);
            }
        }

        private static TestFixtureData Test(int number, bool isPalindrome, bool isPalindromeOrDescendant, string name = null)
        {
            var data = new TestFixtureData(number, isPalindrome, isPalindromeOrDescendant);

            if (name != null)
                data.TestName = name;
            else
                data.SetArgDisplayNames(number.ToString());

            return data;
        }
    }
}
