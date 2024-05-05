namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq.Expressions;
    using Terms;

    [TestClass]
    public class ScratchTests : BaseTests
    {
        [TestMethod]
        public void ScratchTest01()
        {
            var source = "X = 1, Title contains \"love\"";
            var parser = new Parser();
            var term = parser.Parse(source, caseSensitive: false);
            var result = term.ToString();
            return;
        }
    }
}
