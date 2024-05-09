namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    [TestClass]
    public class ScratchTests : BaseTests
    {
        [TestMethod]
        public void ScratchTest01()
        {
            var parser = new Parser();
            var text1 = "Album";
            var term1 = parser.Parse(text1, caseSensitive: true);
            var text2 = "$Album";
            var term2 = parser.Parse(text2, caseSensitive: true);
            return;
        }
    }
}
