using System;
using NUnit.Framework;


namespace FancyCalc
{
    [TestFixture]
    public class FancyCalculatorTests
    {

        [Test]
        public void AddTest()
        {
            FancyCalcEnguine calc = new FancyCalcEnguine();
            double expected = 4;
            double actual = calc.Add(2, 2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SubtractTest()
        {
            var calc = new FancyCalcEnguine();
            double expected = 0;
            double actual = calc.Subtract(1, 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DivisionTest()
        {
            var calc = new FancyCalcEnguine();
            double expected = 9;
            double actual = calc.Division(27, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 3, ExpectedResult = 9)]
        [TestCase(1, 0, ExpectedResult = 0)]
        public double MultiplyTest(int a, int b)
        {
            var calc = new FancyCalcEnguine();
            return calc.Multiply(a, b);
        }


        [TestCase("3 + 3", ExpectedResult = 6)]
        [TestCase("2+3", ExpectedResult = 5)]
        [TestCase("6/3", ExpectedResult = 2)]
        [TestCase("2*3", ExpectedResult = 6)]
        [TestCase("2-3", ExpectedResult = -1)]
        public double CalculateTest(string expression)
        {
            var calc = new FancyCalcEnguine();
            return calc.Culculate(expression);
        }
    }
}
