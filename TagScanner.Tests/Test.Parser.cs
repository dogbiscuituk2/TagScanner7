namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestParseCasts()
        {
            foreach (var type in Types.TypeValues)
            {
                var expectedText = $"({type.Say()})123";
                var cast = new Parser().Parse(expectedText);
                Assert.IsInstanceOfType(cast, typeof(Cast));
                Assert.AreEqual(expected: expectedText, actual: cast.ToString());
            }
        }

        [TestMethod]
        [DataRow("false", typeof(Constant<bool>), typeof(bool))]
        [DataRow("true", typeof(Constant<bool>), typeof(bool))]
        [DataRow("'x'", typeof(Constant<char>), typeof(char))]
        [DataRow("123456789", typeof(Constant<int>), typeof(int))]
        [DataRow("123456789U", typeof(Constant<uint>), typeof(uint))]
        [DataRow("1234567890123456789L", typeof(Constant<long>), typeof(long))]
        [DataRow("1234567890123456789UL", typeof(Constant<ulong>), typeof(ulong))]
        [DataRow("12345.67F", typeof(Constant<float>), typeof(float))]
        [DataRow("12345.67M", typeof(Constant<decimal>), typeof(decimal))]
        [DataRow("12345.67D", typeof(Constant<double>), typeof(double))]
        [DataRow("12345.67", typeof(Constant<double>), typeof(double), "12345.67D")]
        [DataRow("[1958-11-23]", typeof(Constant<DateTime>), typeof(DateTime))]
        [DataRow("[1958-1-2 1:2:3]", typeof(Constant<DateTime>), typeof(DateTime), "[1958-01-02 01:02:03]")]
        [DataRow("[1958-11-23 1:23]", typeof(Constant<DateTime>), typeof(DateTime), "[1958-11-23 01:23:00]")]
        [DataRow("[1958-11-23 12:34:56.789]", typeof(Constant<DateTime>), typeof(DateTime))]
        [DataRow("[11.22:33:44.555]", typeof(Constant<TimeSpan>), typeof(TimeSpan))]
        [DataRow("[1.2:3:4]", typeof(Constant<TimeSpan>), typeof(TimeSpan), "[1.02:03:04]")]
        [DataRow("[12:34:56]", typeof(Constant<TimeSpan>), typeof(TimeSpan))]
        [DataRow("[12:34:56.789]", typeof(Constant<TimeSpan>), typeof(TimeSpan))]
        public void TestParseConstants(string text, Type termType, Type resultType, string expectedText = null)
        {
            var constant = new Parser().Parse(text);
            Assert.AreEqual(expected: termType, actual: constant.GetType());
            Assert.AreEqual(expected: resultType, actual: constant.ResultType);
            Assert.AreEqual(expected: expectedText ?? text, actual: constant.ToString());
        }

        [TestMethod]
        public void TestParseFields()
        {
            foreach (var tag in Tags.Keys)
            {
                var field = new Parser().Parse(tag.DisplayName());
                Assert.IsInstanceOfType(field, typeof(Field));
                Assert.AreEqual(expected: tag.Type(), actual: field.ResultType);
                Assert.AreEqual(expected: tag.DisplayName(), actual: field.ToString());
            }
        }

        [TestMethod]
        public void TestParseStaticFunctions()
        {
            foreach (var key in Methods.Keys.Where(p => p.IsStatic()))
            {
                var expectedText = $"{key}(1, 2)";
                var function = new Parser().Parse(expectedText);
                Assert.IsInstanceOfType(function, typeof(Function));
                Assert.AreEqual(expected: expectedText, actual: function.ToString());
            }
        }
    }
}
