namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using TagScanner.Terms;

    public partial class Test
    {
        [TestMethod]
        [DataRow("false", typeof(Constant), typeof(bool))]
        [DataRow("true", typeof(Constant), typeof(bool))]
        [DataRow("'x'", typeof(Constant), typeof(char))]
        [DataRow("123456789", typeof(Constant), typeof(int))]
        [DataRow("123456789U", typeof(Constant), typeof(uint))]
        [DataRow("1234567890123456789L", typeof(Constant), typeof(long))]
        [DataRow("1234567890123456789UL", typeof(Constant), typeof(ulong))]
        [DataRow("12345.67F", typeof(Constant), typeof(float))]
        [DataRow("12345.67M", typeof(Constant), typeof(decimal))]
        [DataRow("12345.67D", typeof(Constant), typeof(double))]
        [DataRow("12345.67", typeof(Constant), typeof(double), "12345.67D")]
        public void TestParse(string text, Type termType, Type resultType, string expectedText = null)
        {
            var term = new Parser().Parse(text);
            Assert.AreEqual(expected: termType, actual: term.GetType());
            Assert.AreEqual(expected: resultType, actual: term.ResultType);
            Assert.AreEqual(expected: expectedText ?? text, actual: term.ToString());
        }

        [TestMethod]
        public void TestParseFields()
        {
            foreach (var tag in Tags.Keys)
            {
                var field = new Parser().Parse(tag.DisplayName());
                Assert.AreEqual(expected: typeof(Field), actual: field.GetType());
                Assert.AreEqual(expected: tag.Type(), actual: field.ResultType);
                Assert.AreEqual(expected: tag.DisplayName(), actual: field.ToString());
            }
        }
    }
}
