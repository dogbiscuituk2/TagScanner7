namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using System.Linq;
    using Terms;

    public partial class Test
    {
        public void TestTerm(Term term)
        {
            TestRoundTrip(term);
            if (!(term is TermList termList)) return;
            for (var index = 0; index < termList.Operands.Count; index++)
            {
                var start = termList.Start(index);
                var subTerm = termList.Operands[index];
                var length = subTerm.Length;
                Assert.AreEqual(expected: subTerm.ToString(), actual: termList.ToString().Substring(start, length));
                var range = termList.CharacterRanges[2 * index + 1];
                Assert.AreEqual(expected: start, actual: range.First);
                Assert.AreEqual(expected: length, actual: range.Length);
                TestTerm(subTerm);
            }
        }

        public void TestRoundTrip(Term term)
        {
            var before = term?.ToString();
            term = new Parser().Parse(before);
            var after = term?.ToString();
            Assert.AreEqual(expected: before, actual: after);
        }

        [TestMethod]
        public void TestParser()
        {
            var parser = new Parser();
            var text = "Compare(\"1\", \"2\")";
            var term = parser.Parse(text, caseSensitive: false);
            System.Diagnostics.Debug.WriteLine(term.Expression.ToString());
        }
    }
}
