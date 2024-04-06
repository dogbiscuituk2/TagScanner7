namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestFunctions()
        {
            foreach (var key in Functions.Keys)
            {
                var function = new Function(key);
                Assert.IsNotNull(function);
                Assert.AreEqual(expected: Rank.Unary, actual: function.Rank);
                if (function.IsStatic)
                    Assert.AreEqual(expected: key, actual: function.ToString().Substring(0, key.Length));
                TestTerm(function);
            }
        }
    }
}
