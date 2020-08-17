using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Palindrome_Descendant.src;

namespace Palindrome_Descendant.tests
{
    [TestFixture]
    public class SingleDigitElement
    {
        private Element element;

        [SetUp]
        public void Setup()
        {
            element = new Element(5);
        }

        [Test]
        public void IsPalindrome_True()
        {
            var result = element.IsPalindrome();
            Assert.True(result);
        } 

        [Test]
        public void GetDescendant_Null()
        {
            var descendant = element.GetDescendant();
            Assert.IsNull(descendant);
        } 
    }
}
