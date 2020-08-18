using System;
using Domain;
using NUnit.Framework;

namespace UnitTests.Number_
{
    [TestFixture]
    public class Number_Less_Than_Zero
    {
        [Test]
        public static void Create_Trows_Exception()
        {
            Assert.Throws<Exception>(()=>Number.Create(-1));
        }
    }
}
