namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    [TestClass]
    public class LinqTests
    {
        [TestMethod]
        public void LinqTest()
        {
            var text = "List where(duration > [0:3:0])";
            //var text = "Min(1+2, 3+4)";
            var parser = new Parser();
            var term = parser.Parse(text, caseSensitive: true);
            return;
        }
    }
}
