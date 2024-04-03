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
            Assert.AreEqual(expected: expression, actual: constant.Expression.ToString());
            Assert.AreEqual(expected: Rank.Unary, actual: constant.Rank);
            TestTerm(constant);
        }

        [TestMethod]
        public void TestConstants()
        {
            TestConstant(Term.Empty, "\"\"");
            TestConstant(Term.False, "False");
            TestConstant(Term.Nothing, "null");
            TestConstant(Term.True, "True");
            TestConstant(Term.Zero, "0");
            TestConstant(new Constant<bool>(false), "False");
            TestConstant(new Constant<bool>(true), "True");
            TestConstant(new Constant<byte>(255), "255");
            TestConstant(new Constant<char>('c'), "c");
            TestConstant(new Constant<double>(123.45D), "123.45");
            TestConstant(new Constant<float>(123.45F), "123.45");
            TestConstant(new Constant<int>(0x7FFFFFFF), "2147483647");
            TestConstant(new Constant<long>(0x7FFFFFFFFFFFFFFFL), "9223372036854775807");
            TestConstant(new Constant<sbyte>(0x7F), "127");
            TestConstant(new Constant<short>(0x7FFF), "32767");
            TestConstant(new Constant<string>("Hello World!"), "\"Hello World!\"");
            TestConstant(new Constant<uint>(0xFFFFFFFFU), "4294967295");
            TestConstant(new Constant<ulong>(0xFFFFFFFFFFFFFFFFUL), "18446744073709551615");
            TestConstant(new Constant<ushort>(0xFFFF), "65535");
        }

        [TestMethod]
        public void TestDateTime()
        {
            var now = DateTime.Now;
            TestConstant(new Constant<DateTime>(now), now.ToString(CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestDecimal()
        {
            const decimal money = 123.45M;
            TestConstant(new Constant<decimal>(money), "123.45");
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