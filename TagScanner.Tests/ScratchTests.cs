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
            var term = parser.Parse("X := 1", caseSensitive: false);
            var foo = term.GetResult(parser.State);
            return;
        }
    }
}
