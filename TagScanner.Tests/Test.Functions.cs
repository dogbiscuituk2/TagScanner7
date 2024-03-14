namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestFunctions()
        {
            foreach (var key in Core.Methods.Keys)
            {
                var term = new Function(key);
                Assert.IsNotNull(term);
                Assert.AreEqual(expected: Rank.Unary, actual: term.Rank);
                if (term.Method.IsStatic)
                    Assert.AreEqual(expected: key, actual: term.ToString().Substring(0, key.Length));
            }
        }
    }
}
