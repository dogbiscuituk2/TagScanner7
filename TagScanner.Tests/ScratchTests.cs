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
            var source = "X := \"I love you\", X contains \"love\"";
            //var source = "X = 1, Title contains \"love\"";
            var parser = new Parser();
            var term = parser.Parse(source, caseSensitive: true);
            var answer = term.ToString();
            var result = term.Result;

            return;
        }
    }
}
