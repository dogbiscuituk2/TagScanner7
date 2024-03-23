namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestCasts()
        {
            foreach (var type in Cast.NewTypes)
            {
                var cast = new Cast(type);
                Assert.IsNotNull(cast);
                Assert.AreEqual(expected: Rank.Unary, actual: cast.Rank);
                TestTerm(cast);
            }
        }
    }
}
