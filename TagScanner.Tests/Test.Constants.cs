namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Globalization;
    using Terms;

    public partial class Test
    {
        public void TestConstant(Term constant, string expression)
        {
            Assert.AreEqual(expected: Rank.Unary, actual: constant.Rank);
            Assert.AreEqual(expected: expression, actual: constant.Expression.ToString());
            TestParse(constant);
        }

        [TestMethod]
        public void TestConstants()
        {
            TestConstant(Term.Empty, "\"\"");
            TestConstant(Term.False, "False");
            TestConstant(Term.True, "True");
            TestConstant(Term.Zero, "0");
            TestConstant(new Constant<bool>(false), "False");
            TestConstant(new Constant<bool>(true), "True");
            TestConstant(new Constant<char>('c'), "c");
            TestConstant(new Constant<double>(123.45D), "123.45");
            TestConstant(new Constant<int>(0x7FFFFFFF), "2147483647");
            TestConstant(new Constant<long>(0x7FFFFFFFFFFFFFFFL), "9223372036854775807");
            TestConstant(new Constant<string>("Hello World!"), "\"Hello World!\"");
        }

        [TestMethod]
        public void TestDateTime()
        {
            var now = DateTime.Now;
            TestConstant(new Constant<DateTime>(now), now.ToString(CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestInteger()
        {
            const int integer = 123;
            TestConstant(new Constant<int>(integer), "123");
        }

        [TestMethod]
        public void TestTimeSpan()
        {
            var lap = new TimeSpan(12, 34, 56, 789);
            TestConstant(new Constant<TimeSpan>(lap), lap.ToString());
        }
    }
}