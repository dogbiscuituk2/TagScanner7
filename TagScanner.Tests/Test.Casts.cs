namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestCasts()
        {
            foreach (var type in Types.TypeValues)
            {
                var cast = new Cast(type);
                Assert.IsNotNull(cast);
                // Arity?
                Assert.AreEqual(expected: Rank.Unary, actual: cast.Rank);
                Assert.AreEqual(expected: type, actual: cast.ResultType);
                AddTestValues(cast);
                Assert.AreEqual(expected: 1, actual: cast.Operands.Count);
                TestTerm(cast);
            }
        }
    }
}
