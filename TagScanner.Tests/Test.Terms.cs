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
            var before = term?.ToString();
            var after = new Parser().Parse(before, caseSensitive: true)?.ToString();
            Assert.AreEqual(expected: before, actual: after);
            // Ignore case
            before = new Parser().Parse(before, caseSensitive: false)?.ToString();
            after = new Parser().Parse(before, caseSensitive: false)?.ToString();
            Assert.AreEqual(expected: before, actual: after);
        }
    }
}
