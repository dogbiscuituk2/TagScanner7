namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Parsing;
    using Terms;

    public class BaseTests
    {
        #region Protected Methods

        protected void AddTestValues(Compound compound)
        {
            var operands = compound.Operands;
            var operandsCount = operands.Count;
            var types = compound.OperandTypes.ToList();
            var typesCount = types.Count;
            for (var index = operandsCount; index < typesCount; index++)
            {
                var type = types[index];
                if (type.IsArray)
                    type = type.GetElementType();
                var term = GetTestValue(type);
                operands.Add(term);
                if (index == typesCount - 1 && compound.IsInfinitary)
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
                var term = Parser.Parse(original, caseSensitive);
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
            if (term is Compound compound)
                for (var index = 0; index < compound.Operands.Count; index++)
                {
                    term = compound.Operands[index];
                    var start = compound.Start(index);
                    var length = term.Length;
                    var termString = term.ToString();
                    var compoundString = compound.ToString();
                    Assert.AreEqual(expected: termString, actual: compoundString.Substring(start, length));
                    var range = compound.CharacterRanges[2 * index + 1];
                    Assert.AreEqual(expected: start, actual: range.First);
                    Assert.AreEqual(expected: length, actual: range.Length);
                    TestParse(term);
                }
        }

        protected void TestParseRoundTrip(Term term)
        {
            // Case sensitive
            string
                expected = Parser.Parse(term?.ToString(), caseSensitive: true).ToString(),
                actual = Parser.Parse(expected, caseSensitive: true)?.ToString();
            Assert.AreEqual(expected, actual);
            // Ignore case
            expected = Parser.Parse(term?.ToString(), caseSensitive: false)?.ToString();
            actual = Parser.Parse(expected, caseSensitive: false)?.ToString();
            Assert.AreEqual(expected, actual);
        }

        protected void TestResult(string text, object sense) => TestResult(text, sense, sense);

        protected void TestResult(string text, object sense, object nonsense)
        {
            var term = Parser.Parse(text, caseSensitive: true);
            Assert.AreEqual(expected: sense, actual: term.Result);
            term = Parser.Parse(text, caseSensitive: false);
            Assert.AreEqual(expected: nonsense, actual: term.Result);

            text = $"X := {text}";

            term = Parser.Parse(text, caseSensitive: true);
            Assert.AreEqual(expected: sense, actual: term.Result);
            term = Parser.Parse(text, caseSensitive: false);
            Assert.AreEqual(expected: nonsense, actual: term.Result);

            text = $"Y := {text}";

            term = Parser.Parse(text, caseSensitive: true);
            Assert.AreEqual(expected: sense, actual: term.Result);
            term = Parser.Parse(text, caseSensitive: false);
            Assert.AreEqual(expected: nonsense, actual: term.Result);
        }

        #endregion

        protected void TestCases(string text, Func<Term, object> func, object sense, object nonsense)
        {
            Term term;
            var caseSensitive = true;
            var expected = sense;
            do
            {
                term = Parser.Parse(text, caseSensitive);
                var actual = func.Invoke(term);
                Assert.AreEqual(expected, actual);
                expected = nonsense;
                caseSensitive = !caseSensitive;
            }
            while (!caseSensitive);
        }

        #region Private Fields

        private readonly DateTime DateTimeForTest = new DateTime(1920, 11, 30, 12, 34, 56, 789);
        private readonly TimeSpan TimeSpanForTest = new TimeSpan(12, 34, 56, 789);

        #endregion
    }
}
