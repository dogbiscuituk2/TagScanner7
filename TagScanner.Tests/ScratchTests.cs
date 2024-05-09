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
            var text = "List";
            var term = parser.Parse(text, caseSensitive: true);
            return;
        }
    }
}
