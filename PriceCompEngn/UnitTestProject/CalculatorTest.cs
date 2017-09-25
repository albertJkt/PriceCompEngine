using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Is2Plus2Equal4()
        {
            //Arrane
            var Calculator = new Calculator();
            //Act
            var sum = Calculator.Sum(2, 2);
            //Assert
            Assert.AreEqual(4, sum);

        }
    }
}


/// 3 dalys testo
/// A. Access / Arrange
/// B. Act
/// C. Assert