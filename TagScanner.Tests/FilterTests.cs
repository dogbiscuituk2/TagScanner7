namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Terms;

    [TestClass]
    public class FilterTests : BaseTests
    {
        [DataRow("Title.Contains(\"love\")", 0, 2)]
        [TestMethod]
        public void TestFilters(string text, int sense, int nonsense) => TestCases(text,
            (Term p) => p.Filter(Test.Tracks).Count(),
            sense, nonsense);
    }
}
