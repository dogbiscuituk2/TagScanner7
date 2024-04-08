namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestFunctions()
        {
            foreach (var fn in Functors.Keys)
            {
                var function = new Function(fn);
                Assert.IsNotNull(function);
                Assert.AreEqual(expected: Rank.Unary, actual: function.Rank);
                TestTerm(function);
            }
        }

        [TestMethod]
        public void TestFunctionLength()
        {
            var fn = Fn.Length;
            var function = new Function(fn);
            Assert.IsNotNull(function);
            Assert.AreEqual(expected: Rank.Unary, actual: function.Rank);
            TestTerm(function);
        }
    }
}
