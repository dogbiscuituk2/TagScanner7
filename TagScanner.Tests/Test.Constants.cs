namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        [DataRow(typeof(bool), false, "False")]
        [DataRow(typeof(bool), true, "True")]
        [DataRow(typeof(byte), (byte)127, "127")]
        [DataRow(typeof(char), 'c', "c")]
        [DataRow(typeof(double), 123.45D, "123.45")]
        [DataRow(typeof(float), 123.45F, "123.45")]
        [DataRow(typeof(int), 2147483647, "2147483647")]
        [DataRow(typeof(long), 9223372036854775807L, "9223372036854775807")]
        [DataRow(typeof(sbyte), (sbyte)127, "127")]
        [DataRow(typeof(short), (short)32767, "32767")]
        [DataRow(typeof(string), "Hello World", "\"Hello World\"")]
        [DataRow(typeof(uint), 4294967295U, "4294967295")]
        [DataRow(typeof(ulong), 18446744073709551615UL, "18446744073709551615")]
        [DataRow(typeof(ushort), (ushort)65535, "65535")]
        public void TestConstant(Type type, object value, string expression)
        {
            var constant = new Constant(value);
            Assert.AreEqual(expected: expression, actual: constant.Expression.ToString());
            Assert.AreEqual(expected: Rank.Unary, actual: constant.Rank);
            Assert.AreEqual(expected: type, actual: constant.ResultType);
            Assert.AreEqual(expected: value, actual: constant.Value);
            TestTerm(constant);
        }

        [TestMethod]
        public void TestDateTime()
        {
            var now = DateTime.Now;
            TestConstant(typeof(DateTime), now, now.ToString());
        }

        [TestMethod]
        public void TestDecimal()
        {
            var money = 123.45M;
            TestConstant(typeof(decimal), money, "123.45");
        }

        [TestMethod]
        public void TestTimeSpan()
        {
            var lap = new TimeSpan(12, 34, 56, 789);
            TestConstant(typeof(TimeSpan), lap, lap.ToString());
        }
    }
}