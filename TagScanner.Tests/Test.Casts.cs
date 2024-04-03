namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestCasts()
        {
            foreach (var type in Cast.Types)
            {
                var cast = new Cast(type);
                Assert.IsNotNull(cast);
                Assert.AreEqual(expected: 1, actual: cast.Arity);
                Assert.AreEqual(expected: type, actual: cast.ResultType);
                Assert.AreEqual(expected: Rank.Unary, actual: cast.Rank);
                Assert.AreEqual(expected: type, actual: cast.ResultType);
                TestTerm(cast);
            }
        }
    }
}
