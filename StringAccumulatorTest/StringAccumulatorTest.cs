using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringAccumulatorTest
{
    [TestClass]
    public class StringAccumulatorTest
    {
        [TestMethod]
        public void TestAccumulatorEmptyString()
        {
            StringAccumulator.StringAccumulator stringAccumulator = new StringAccumulator.StringAccumulator();
            Assert.AreEqual(0, stringAccumulator.Add(""));
        }

        [TestMethod]
        public void TestAccumulatorSingleNumber()
        {
            StringAccumulator.StringAccumulator stringAccumulator = new StringAccumulator.StringAccumulator();
            Assert.AreEqual(1, stringAccumulator.Add("1"));
        }

        [TestMethod]
        public void TestAccumulator()
        {
            StringAccumulator.StringAccumulator stringAccumulator = new StringAccumulator.StringAccumulator();
            Assert.AreEqual(3, stringAccumulator.Add("1,2"));
        }

        [TestMethod]
        public void TestAccumulatorWithEmbeddedNewLine()
        {
            StringAccumulator.StringAccumulator stringAccumulator = new StringAccumulator.StringAccumulator();
            Assert.AreEqual(6, stringAccumulator.Add("1\n2,3"));
        }

        [TestMethod]
        public void TestAccumulatorWithNewDelimiters()
        {
            StringAccumulator.StringAccumulator stringAccumulator = new StringAccumulator.StringAccumulator();
            Assert.AreEqual(3, stringAccumulator.Add("//;\n1;2"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Negatives not allowed")]
        public void TestAccumulatorWithNegativeNumbers()
        {
            StringAccumulator.StringAccumulator stringAccumulator = new StringAccumulator.StringAccumulator();
            stringAccumulator.Add("1\n2,3,-1002,-4302,99");
        }
    }
}
