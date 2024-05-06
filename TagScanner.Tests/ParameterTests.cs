﻿namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    [TestClass]
    public class ParameterTests : BaseTests
    {
        [TestMethod]
        public void TestParameters()
        {
            foreach (var type in Types.Values)
            {
                var parameter = new Parameter(type);
                Assert.IsNotNull(parameter);
                Assert.AreEqual(expected: Rank.Unary, actual: parameter.Rank);
                Assert.AreEqual(expected: type, actual: parameter.ResultType);
                TestParse(parameter);
            }
        }
    }
}