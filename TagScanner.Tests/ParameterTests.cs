namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    [TestClass]
    public class DefaultTests : BaseTests
    {
        [TestMethod]
        public void TestDefaults()
        {
            foreach (var type in Types.Values)
            {
                var term = new Default(type);
                Assert.IsNotNull(term);
                Assert.AreEqual(expected: Rank.Unary, actual: term.Rank);
                Assert.AreEqual(expected: type, actual: term.ResultType);
                TestParse(term);
            }
        }
    }
}
