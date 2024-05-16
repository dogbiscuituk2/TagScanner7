namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    [TestClass]
    public class ScratchTests : BaseTests
    {
        //[TestMethod]
        public void ScratchTest()
        {
            var before = "if (title contains \"Love\", 1, 2)";
            var parser = new Parser();
            var term = parser.Parse(before, caseSensitive: false);
            var after = term.ToString();
            Assert.AreEqual(expected: before, actual: after);
        }
    }
}
