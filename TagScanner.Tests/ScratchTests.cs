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
            var source = "Declaration := \"I love you!\", Declaration.IndexOf \"love\"";
            var parser = new Parser();
            var term = parser.Parse(source, caseSensitive: true);
            var answer = term.ToString();
            var result = term.Result;

            return;
        }
    }
}
