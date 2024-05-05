namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Globalization;
    using Terms;

    [TestClass]
    public class ConstantTests : BaseTests
    {
        [TestMethod]
        public void TestConstants()
        {
            TestConstant(Term.Empty, "\"\"");
            TestConstant(Term.False, "False");
            TestConstant(Term.True, "True");
            TestConstant(Term.Zero, "0");

            var now = DateTime.Now;
            var lap = new TimeSpan(12, 34, 56, 789);

            // bool
            TestConstant(new Constant<bool>(false), "False");
            TestConstant(false, "False");
            TestConstant(new Constant<bool>(true), "True");
            TestConstant(true, "True");
            // char
            TestConstant(new Constant<char>('c'), "c");
            TestConstant('c', "c");
            // DateTime
            TestConstant(new Constant<DateTime>(now), now.ToString(CultureInfo.CurrentCulture));
            TestConstant(now, now.ToString(CultureInfo.CurrentCulture));
            // decimal
            TestConstant(new Constant<decimal>(123.45M), "123.45");
            TestConstant(123.45M, "123.45");
            // double
            TestConstant(new Constant<double>(123.45), "123.45");
            TestConstant(123.45, "123.45");
            TestConstant(new Constant<double>(123.45D), "123.45");
            TestConstant(123.45D, "123.45");
            // int
            TestConstant(new Constant<int>(int.MaxValue), $"{int.MaxValue}");
            TestConstant(int.MaxValue, $"{int.MaxValue}");
            TestConstant(new Constant<int>(0x7FFFFFFF), "2147483647");
            TestConstant(0x7FFFFFFF, "2147483647");
            // long
            TestConstant(new Constant<long>(long.MaxValue), $"{long.MaxValue}");
            TestConstant(long.MaxValue, $"{long.MaxValue}");
            TestConstant(new Constant<long>(0x7FFFFFFFFFFFFFFFL), "9223372036854775807");
            TestConstant(0x7FFFFFFFFFFFFFFFL, "9223372036854775807");
            // string
            TestConstant(new Constant<string>("Hello World!"), "\"Hello World!\"");
            TestConstant("Hello World!", "\"Hello World!\"");
            // TimeSpan
            TestConstant(new Constant<TimeSpan>(lap), lap.ToString());
            TestConstant(lap, lap.ToString());
        }

        private void TestConstant(Term constant, string expression)
        {
            Assert.AreEqual(expected: Rank.Unary, actual: constant.Rank);
            Assert.AreEqual(expected: expression, actual: constant.Expression?.ToString());
            TestParse(constant);
        }
    }
}
