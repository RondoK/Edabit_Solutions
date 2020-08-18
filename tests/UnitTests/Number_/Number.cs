using System.Collections;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Domain;

namespace UnitTests.Number_
{
    [TestFixtureSource("Fixtures")]
    public class Number_
    {
        private Domain.Number element;
        private bool isPalindrome;
        private bool isPalindromeOrDescendantIs;
        private int[] descendants;

        public Number_(int number, bool isPalindrome, bool isPalindromeOrDescendantIs, int[] descendants)
        {
            element = Domain.Number.Create(number);
            this.isPalindrome = isPalindrome;
            this.isPalindromeOrDescendantIs = isPalindromeOrDescendantIs;
            this.descendants = descendants;
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

        [Test]
        public void GetDescendants()
        {
            var result = element.GetDescendants();
            CollectionAssert.AreEqual(descendants, result.Select(x => x.GetNumber()));
        }

        static IEnumerable Fixtures
        {
            get
            {
                yield return Test(0, true, true, new int[] { });
                yield return Test(3, true, true, new int[] { });
                yield return Test(11, true, true, new int[] { });
                yield return Test(12, false, false, new int[] { });
                yield return Test(111, true, true, new int[] { });
                yield return Test(1122, false, false, new[] { 24 });
                yield return Test(2121, false, true, new[] { 33 });
                yield return Test(5601, false, true, new[] { 111 });
                yield return Test(6556, true, true, new[] { 1111 , 22 });
                yield return Test(7556, false, false, new[] { 1211 , 32 });
            }
        }

        private static TestFixtureData Test(int number, bool isPalindrome, bool isPalindromeOrDescendant, int[] descendants, string name = null)
        {
            var data = new TestFixtureData(number, isPalindrome, isPalindromeOrDescendant, descendants);

            if (name != null)
                data.TestName = name;
            else
                data.SetArgDisplayNames(number.ToString());

            return data;
        }
    }
}
