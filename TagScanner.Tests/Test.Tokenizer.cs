namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        [DataRow("Compare(Album Title, \"Sgt Pepper\")", "Compare", "(", "Album Title", ",", "\"Sgt Pepper\"", ")")]
        [DataRow("Concat_2(Artists (joined), Composers (joined))", "Concat_2", "(", "Artists (joined)", ",", "Composers (joined)", ")")]
        [DataRow("Concat_3(\"123\", \"456\", \"789\")", "Concat_3", "(", "\"123\"", ",", "\"456\"", ",", "\"789\"", ")")]
        [DataRow("Concat_4(\"123\", \"456\", \"789\", \"abc\")", "Concat_4", "(", "\"123\"", ",", "\"456\"", ",", "\"789\"", ",", "\"abc\"", ")")]
        [DataRow("Artists (joined).Contains(\"Beat\")", "Artists (joined)", ".", "Contains", "(", "\"Beat\"", ")")]
        [DataRow("Performers (joined).EndsWith(\"les\")", "Performers (joined)", ".", "EndsWith", "(", "\"les\"", ")")]
        [DataRow("(123).Equals(456)", "(", "123", ")", ".", "Equals", "(", "456", ")")]
        public void TestTokenizeFunctions(string text, params string[] expected)
        {
            var actual = Tokenizer.GetTokens(text);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
