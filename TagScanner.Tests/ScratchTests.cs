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
            var before = "cat := Join(\", \", \"One\", \"Two\", \"Three\")";
            var parser = new Parser();
            var term = parser.Parse(before, caseSensitive: false);
            var after = term.ToString();
            //Assert.AreEqual(expected: before, actual: after);

            var result = term.Result;
            return;
        }
    }
}
