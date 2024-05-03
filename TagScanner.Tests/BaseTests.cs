namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Terms;

    public class BaseTests
    {
        #region Protected Methods

        protected void AddTestValues(TermList termList)
        {
            var operands = termList.Operands;
            var operandsCount = operands.Count;
            var paramTypes = termList.ParameterTypes.ToList();
            var paramsCount = paramTypes.Count;
            for (var index = operandsCount; index < paramsCount; index++)
            {
                var paramType = paramTypes[index];
                if (paramType.IsArray)
                    paramType = paramType.GetElementType();
                var term = GetTestValue(paramType);
                operands.Add(term);
                if (index == paramsCount - 1 && termList.IsInfinitary)
                    operands.AddRange(new[] { term, term });
            }
        }

        protected Term GetTestValue(Type type) =>
            type == typeof(bool) ? true :
            type == typeof(char) ? 'A' :
            type == typeof(DateTime) ? DateTimeForTest :
            type == typeof(decimal) ? decimal.MaxValue / 4 :
            type == typeof(double) ? double.MaxValue / 4 :
            type == typeof(float) ? float.MaxValue / 4 :
            type == typeof(int) ? int.MaxValue / 4 :
            type == typeof(long) ? long.MaxValue / 4 :
            type == typeof(object) ? "object" :
            type == typeof(RegexOptions) ? 1 :
            type == typeof(string) ? "string" :
            type == typeof(TimeSpan) ? TimeSpanForTest :
            type == typeof(uint) ? uint.MaxValue / 4 :
            type == typeof(ulong) ? ulong.MaxValue / 4 :
            (Term)0;

        protected void TestParse(string original, string sense) => TestParse(original, sense, sense);

        protected void TestParse(string original, string sense, string nonsense)
        {
            var expected = sense;
            var caseSensitive = true;
            do
            {
                if (expected == null)
                    expected = original;
                var term = new Parser().Parse(original, caseSensitive);
                var actual = term.ToString();
                Assert.AreEqual(expected, actual);
                expected = nonsense;
                caseSensitive = !caseSensitive;
            }
            while (!caseSensitive);
        }

        protected void TestParse(Term term)
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

        protected void TestParseRoundTrip(Term term)
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

        protected void TestResult(string text, object sense) => TestResult(text, sense, sense);

        protected void TestResult(string text, object sense, object nonsense)
        {
            var parser = new Parser();

            var term = parser.Parse(text, caseSensitive: true);
            Assert.AreEqual(expected: sense, actual: term.GetResult(parser.State));
            term = parser.Parse(text, caseSensitive: false);
            Assert.AreEqual(expected: nonsense, actual: term.GetResult(parser.State));

            text = $"X := {text}";

            term = parser.Parse(text, caseSensitive: true);
            Assert.AreEqual(expected: sense, actual: term.GetResult(parser.State));
            term = parser.Parse(text, caseSensitive: false);
            Assert.AreEqual(expected: nonsense, actual: term.GetResult(parser.State));

        }

        #endregion

        #region Private Fields

        private DateTime DateTimeForTest = new DateTime(1920, 11, 30, 12, 34, 56, 789);
        private TimeSpan TimeSpanForTest = new TimeSpan(12, 34, 56, 789);

        #endregion
    }
}
