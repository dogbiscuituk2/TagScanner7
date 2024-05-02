namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    public partial class Test
    {
        private void TestParse(Term term)
        {
            TestParseRoundTrip(term);
            if (term is TermList termList)
                for (var index = 0; index < termList.Operands.Count; index++)
                {
                    term = termList.Operands[index];
                    var start = termList.Start(index);
                    var length = term.Length;
                    var termToString = term.ToString();
                    var termListToString = termList.ToString();
                    Assert.AreEqual(expected: termToString, actual: termListToString.Substring(start, length));
                    var range = termList.CharacterRanges[2 * index + 1];
                    Assert.AreEqual(expected: start, actual: range.First);
                    Assert.AreEqual(expected: length, actual: range.Length);
                    TestParse(term);
                }
        }

        private void TestParseRoundTrip(Term term)
        {
            var parser = new Parser();
            // Case sensitive
            string
                expected = parser.Parse(term?.ToString(), caseSensitive: true).ToString(),
                actual = parser.Parse(expected, caseSensitive: true)?.ToString();
            Assert.AreEqual(expected, actual);
            // Ignore case
            expected = parser.Parse(term?.ToString(), caseSensitive: false)?.ToString();
            actual = parser.Parse(expected, caseSensitive: false)?.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
