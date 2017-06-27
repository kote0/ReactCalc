using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReactCalc;

namespace TestCalc
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSum()
        {
            var calc = new Calc();
            var x = calc.Execute("+", new[] { 1d, 2d });

            Assert.AreEqual(x,3);
        }
        [TestMethod]
        public void TestDivide()
        {
            var calc = new Calc();
            var x = calc.Action("/", 2, 2);

            Assert.AreEqual(x, "1");
        }
        [TestMethod]
        public void TestPow()
        {
            var calc = new Calc();
            var x = calc.Action("^", 2,2);

            Assert.AreEqual(x, "4");
        }
    }
}
