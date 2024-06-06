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
            var text = "a := 1, b := 1, a + b == 2 ? \"Andy\" : \"Bill\"";
            var term = Parser.Parse(text, caseSensitive: false);
            var result = term.Result;
            Assert.AreEqual(expected: "Andy", actual: result);
        }
    }
}
