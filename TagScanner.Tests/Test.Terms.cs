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
                    Assert.AreEqual(expected: term.ToString(), actual: termList.ToString().Substring(start, length));
                    var range = termList.CharacterRanges[2 * index + 1];
                    Assert.AreEqual(expected: start, actual: range.First);
                    Assert.AreEqual(expected: length, actual: range.Length);
                    TestParse(term);
                }
        }

        private void TestParseRoundTrip(Term term)
        {
            // Case sensitive
            string
                expected = new Parser().Parse(term?.ToString(), caseSensitive: true).ToString(),
                actual = new Parser().Parse(expected, caseSensitive: true)?.ToString();
            Assert.AreEqual(expected, actual);
            // Ignore case
            expected = new Parser().Parse(term?.ToString(), caseSensitive: false)?.ToString();
            actual = new Parser().Parse(expected, caseSensitive: false)?.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
