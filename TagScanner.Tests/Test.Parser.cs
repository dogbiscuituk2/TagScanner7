namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TagScanner.Terms;

    public partial class Test
    {
        [TestMethod]
        [DataRow("Compare(Album, \"Sgt Pepper\")", "Compare", "(", "Album", ",", "\"Sgt Pepper\"", ")")]
        public void TestParseFunctions(string text, params string[] expected)
        {
            var parser = new Parser(text);
            var actual = parser.AllTokens();
            Assert.IsTrue(actual.SequenceEqual(expected));
        }
    }
}
