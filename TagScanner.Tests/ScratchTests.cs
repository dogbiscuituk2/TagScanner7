namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    [TestClass]
    public class ScratchTests : BaseTests
    {
        [TestMethod]
        public void ScratchTest()
        {
            var before = "Album Artists (sorted) + Album Artists + Album Artists (sorted)";
            var parser = new Parser();
            var term = parser.Parse(before, caseSensitive: false);
            var after = term.ToString();
            Assert.AreEqual(expected: before, actual: after);

            return;
        }
    }
}
