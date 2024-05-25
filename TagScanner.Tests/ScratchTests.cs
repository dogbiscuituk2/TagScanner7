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
            var original = "Album Artists (sorted) + Album Artists + Album Artists (sorted)";
            var term1 = Parser.Parse(original, caseSensitive: false);
            var before = term1.ToString();
            var term2 = Parser.Parse(before, caseSensitive: false);
            var after = term2.ToString();
            Assert.AreEqual(expected: before, actual: after);

            return;
        }
    }
}
