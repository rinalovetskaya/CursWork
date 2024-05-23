using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestsClass;

namespace FirstUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsOnlyDigits_ReturnsTrue()
        {
            string input = "12345";
            bool result = TextClass.IsOnlyDigits(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOnlyDigits_ReturnsFalse()
        {
            string input = "z12345";
            bool result = TextClass.IsOnlyDigits(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCyrillic_ReturnsTrue()
        {
            string cyrillicText = "Привет";
            bool result = TextClass.IsCyrillic(cyrillicText);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsCyrillic_ReturnsFalse()
        {
            string nonCyrillicText = "Hello";
            bool result = TextClass.IsCyrillic(nonCyrillicText);
            Assert.IsFalse(result);
        }

    }
}
