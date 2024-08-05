namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Parsing;
    using Terms;

    [TestClass]
    public class ConstantTests : BaseTests
    {
        [DataRow("false", "false", typeof(bool))]
        [DataRow("True", "true", typeof(bool))]
        [DataRow("'A'", "'A'", typeof(char))]
        [DataRow("'\''", "'\''", typeof(char))]
        [DataRow("'\t'", "'\t'", typeof(char))]
        [DataRow("'\n'", "'\n'", typeof(char))]
        [DataRow("'\r'", "'\r'", typeof(char))]
        [DataRow("[1975-2-8]", "[1975-02-08]", typeof(DateTime))]
        [DataRow("[1975-2-8 1:2]", "[1975-02-08 01:02:00]", typeof(DateTime))]
        [DataRow("[1975-2-8 1:2:3]", "[1975-02-08 01:02:03]", typeof(DateTime))]
        [DataRow("[1975-2-8 1:2:3.4]", "[1975-02-08 01:02:03.400]", typeof(DateTime))]
        [DataRow("[1975-2-8 1:2:3.456]", "[1975-02-08 01:02:03.456]", typeof(DateTime))]
        [DataRow("123.45M", "123.45M", typeof(decimal))]
        [DataRow("123.45", "123.45D", typeof(double))]
        [DataRow("123.45d", "123.45D", typeof(double))]
        [DataRow("123.45f", "123.45F", typeof(float))]
        [DataRow("123", "123", typeof(int))]
        [DataRow("123L", "123L", typeof(long))]
        [DataRow("\"Hello World!\"", "\"Hello World!\"", typeof(string))]
        [DataRow("\"\t\"", "\"\t\"", typeof(string))]
        [DataRow("\"\n\"", "\"\n\"", typeof(string))]
        [DataRow("\"\r\"", "\"\r\"", typeof(string))]
        [DataRow("[1:2]", "[01:02:00]", typeof(TimeSpan))]
        [DataRow("[1:2:3]", "[01:02:03]", typeof(TimeSpan))]
        [DataRow("[12:34:56.789]", "[12:34:56.789]", typeof(TimeSpan))]
        [DataRow("123u", "123U", typeof(uint))]
        [DataRow("123uL", "123UL", typeof(ulong))]
        [DataRow("123LU", "123UL", typeof(ulong))]
        [TestMethod]
        public void TestConstants(string input, string expected, Type type)
        {
            foreach (var caseSensitive in new[] { false, true }) // Test with caseSensitive = false, then true.
                foreach (var addParens in new[] { false, true }) // Test first the raw text, and then (((text))).
                {
                    var text = addParens ? $"((({input})))" : input;
                    var term = Parser.Parse(text, caseSensitive);
                    var actual = term.ToString();
                    Assert.AreEqual(expected, actual);
                    Assert.AreEqual(expected: type, actual: term.ResultType);
                    Assert.AreEqual(expected: $"Constant<{type.Say()}>", actual: term.GetType().Say());
                }
        }
    }
}
