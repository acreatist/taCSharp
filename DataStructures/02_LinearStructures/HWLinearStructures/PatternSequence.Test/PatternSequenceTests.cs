using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PatternSequence.Test
{
    [TestClass]
    public class PatternSequenceTests
    {
        [TestMethod]
        public void TestWithN2()
        {
            string expected = "2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6";
            List<int> sequence = PatternSeuqence.PatternSequence.RunPattern(13, 2);

            string actual = PatternSeuqence.PatternSequence.SequenceToString(sequence);

            Assert.AreEqual(expected, actual);
        }
    }
}
