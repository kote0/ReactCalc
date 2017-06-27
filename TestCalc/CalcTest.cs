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
            var x = calc.Execute(1, new[] { 1d, 2d });

            Assert.AreEqual(x,3);
        }
        [TestMethod]
        public void TestDivide()
        {
            var calc = new Calc();
            var x = calc.Execute("/", new[] { 4.0, 2.0 });
            Assert.AreEqual(x, 2);
            Assert.AreEqual(calc.Execute(3, new[] { 6.0, 2.0 }), 3);

        }
        [TestMethod]
        public void TestArithmetic()
        {
            var calc = new Calc();
            Assert.AreEqual(calc.Execute("arithmetic", new[] { 4.0, 4.0 }), 4);
        }
        [TestMethod]
        public void TestMul()
        {
            var calc = new Calc();
            Assert.AreEqual(calc.Execute("*", new[] { 4.0, 4.0 }), 16);
        }
        [TestMethod]
        public void TestSub()
        {
            var calc = new Calc();
            Assert.AreEqual(calc.Execute("-", new[] { 4.0, 4.0 }), 0);
        }
    }
}
