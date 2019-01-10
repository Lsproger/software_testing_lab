using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle.TestCases
{
    [TestFixture]
    public class TriangleTestCases
    {
        [TestCase]
        public void NegativeSideSize()
        {
            Assert.AreEqual(false, Program.IsTriangleExist(-10, 10, 5));
        }

        [TestCase]
        public void EqualSidesSize()
        {
            Assert.AreEqual(true, Program.IsTriangleExist(10, 10, 10));
        }

        [TestCase]
        public void DegeneratedTriangle()
        {
            Assert.AreEqual(true, Program.IsTriangleExist(10, 10, 20));
        }

        [TestCase]
        public void EqualSidesSizeMaxDouble()
        {
            Assert.AreEqual(true, Program.IsTriangleExist(
                Double.MaxValue, Double.MaxValue, Double.MaxValue));
        }

        [TestCase]
        public void DegeneratedTriangleMaxDouble1()
        {
            Assert.AreEqual(true, Program.IsTriangleExist(
                Double.MaxValue, Double.MaxValue, Double.MaxValue * 2));
        }

        [TestCase]
        public void DegeneratedTriangleMaxDouble2()
        {
            Assert.AreEqual(true, Program.IsTriangleExist(
                Double.MaxValue * 2, Double.MaxValue, Double.MaxValue));
        }

        [TestCase]
        public void NotExistingTriangle()
        {
            Assert.AreEqual(false, Program.IsTriangleExist(10, 20, 100));
        }

        [TestCase]
        public void NotExistingTriangleMaxDouble()
        {
            Assert.AreEqual(true, Program.IsTriangleExist(
                Double.MaxValue, Double.MaxValue * 2 , Double.MaxValue * 100));
        }

        [TestCase]
        public void NotNumberUnboxedValue()
        {
            object x = new object();
            x = "Not number";
            Assert.AreEqual(false, Program.IsTriangleExist((Double)x, 5, 5));
        }

        [TestCase]
        public void ZeroLengthSizeSides()
        {
            Assert.AreEqual(false, Program.IsTriangleExist(0, 0, 0));
        }

    }
}
