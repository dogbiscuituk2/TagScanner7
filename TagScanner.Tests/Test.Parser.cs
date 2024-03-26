namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TagScanner.Terms;

    public partial class Test
    {
        [TestMethod]
        [DataRow("Compare(Album Title, \"Sgt Pepper\")", "Compare", "(", "Album Title", ",", "\"Sgt Pepper\"", ")")]
        public void TestParseFunctions(string text, params string[] expected)
        {
            var parser = new Parser(text);
            var actual = parser.AllTokens();
            Assert.IsTrue(actual.SequenceEqual(expected));
        }
    }
}
