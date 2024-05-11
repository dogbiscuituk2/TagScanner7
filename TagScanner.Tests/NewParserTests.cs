namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Terms;

    [TestClass]
    public class NewParserTests
    {
        [DataRow("false", "false", typeof(bool))]
        [DataRow("True", "true", typeof(bool))]
        [DataRow("123", "123", typeof(int))]
        [DataRow("123L", "123L", typeof(long))]
        [DataRow("123u", "123U", typeof(uint))]
        [DataRow("123uL", "123UL", typeof(ulong))]
        [DataRow("123LU", "123UL", typeof(ulong))]
        [DataRow("123.45", "123.45D", typeof(double))]
        [DataRow("123.45d", "123.45D", typeof(double))]
        [DataRow("123.45f", "123.45F", typeof(float))]
        [DataRow("123.45M", "123.45M", typeof(decimal))]
        [DataRow("'A'", "'A'", typeof(char))]
        [DataRow("\"Abc\"", "\"Abc\"", typeof(string))]
        [TestMethod]
        public void TestConstants(string input, string expected, Type type)
        {
            var parser = new Parser();
            var term = parser.Parse(input, caseSensitive: false);
            var actual = term.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected: type, actual: term.ResultType);
            Assert.AreEqual(expected: $"Constant<{type.Say()}>", actual: term.GetType().Say());
            return;
        }
    }
}
