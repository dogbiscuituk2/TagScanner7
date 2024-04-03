namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Globalization;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        [DataRow(typeof(bool), false, "False")]
        [DataRow(typeof(bool), true, "True")]
        [DataRow(typeof(byte), (byte)0xFF, "255")]
        [DataRow(typeof(char), 'c', "c")]
        [DataRow(typeof(double), 123.45D, "123.45")]
        [DataRow(typeof(float), 123.45F, "123.45")]
        [DataRow(typeof(int), 0x7FFFFFFF, "2147483647")]
        [DataRow(typeof(long), 0x7FFFFFFFFFFFFFFFL, "9223372036854775807")]
        [DataRow(typeof(sbyte), (sbyte)0x7F, "127")]
        [DataRow(typeof(short), (short)0x7FFF, "32767")]
        [DataRow(typeof(string), "Hello World", "\"Hello World\"")]
        [DataRow(typeof(uint), 0xFFFFFFFFU, "4294967295")]
        [DataRow(typeof(ulong), 0xFFFFFFFFFFFFFFFFUL, "18446744073709551615")]
        [DataRow(typeof(ushort), (ushort)0xFFFF, "65535")]
        public void TestConstant(Type type, object value, string expression)
        {
            var constant = new Constant<int>(0);
            Assert.AreEqual(expected: expression, actual: constant.Expression.ToString());
            Assert.AreEqual(expected: Rank.Unary, actual: constant.Rank);
            Assert.AreEqual(expected: type, actual: constant.ResultType);
            Assert.AreEqual(expected: value, actual: constant.Value);
            TestTerm(constant);
        }

        [TestMethod]
        public void TestConstants()
        {
            TestTerm(Term.Empty);
            TestTerm(Term.False);
            TestTerm(Term.Nothing);
            TestTerm(Term.True);
            TestTerm(Term.Zero);
        }

        [TestMethod]
        public void TestDateTime()
        {
            var now = DateTime.Now;
            TestConstant(typeof(DateTime), now, now.ToString(CultureInfo.CurrentCulture));
        }

        [TestMethod]
        public void TestDecimal()
        {
            const decimal money = 123.45M;
            TestConstant(typeof(decimal), money, "123.45");
        }

        [TestMethod]
        public void TestInteger()
        {
            const int integer = 123;
            TestConstant(typeof(int), integer, "123");
        }

        [TestMethod]
        public void TestTimeSpan()
        {
            var lap = new TimeSpan(12, 34, 56, 789);
            TestConstant(typeof(TimeSpan), lap, lap.ToString());
        }
    }
}