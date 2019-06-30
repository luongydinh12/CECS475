using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculator57;

namespace MyCalculator57.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        [TestCategory("Add")]
        [Ignore]
        public void AddSimple57()
        {
            Calculator calculator57 = new Calculator();
            int sum57 = calculator57.Add57(1, 2);
            Assert.AreEqual(3, sum57);
        }

        [TestMethod]
        [TestCategory("Divide")]
        public void DivideSimple57()
        {
            Calculator calculator57 = new Calculator();
            int quotient57 = calculator57.Divide57(10, 5);
            Assert.AreEqual(2, quotient57);
        }

        [TestMethod]
        [TestCategory("Divide")]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero57()
        {
            Calculator calculator57 = new Calculator();
            calculator57.Divide57(10, 0);
        }

    }
}
