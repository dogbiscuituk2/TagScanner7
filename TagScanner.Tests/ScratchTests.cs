namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Terms;

    [TestClass]
    public class ScratchTests : BaseTests
    {
        [DataRow("Title.Contains(\"love\")", 0, 2)]
        [TestMethod]
        public void ScratchTest01()
        {
            var parser = new Parser();
            
            var text = "A :=\"lo\", B := \"ve\", Title contains(A + B)";
            var term = parser.Parse(text, caseSensitive: false);

            var tracks1 = term.Filter(Test.Tracks).ToArray();

            var predicate = term.Predicate;

            var tracks2 = Test.Tracks.Where(p => predicate(null, p)).ToArray();

            return;
        }
    }
}
