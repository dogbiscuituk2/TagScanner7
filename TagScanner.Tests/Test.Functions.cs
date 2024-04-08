namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestFunctions()
        {
            foreach (var key in Functions.Keys)
            {
                var function = new Function(key);
                Assert.IsNotNull(function);
                Assert.AreEqual(expected: Rank.Unary, actual: function.Rank);
                if (function.IsStatic)
                    Assert.AreEqual(expected: key, actual: function.ToString().Substring(0, key.Length));
                TestTerm(function);
            }
        }

        [TestMethod]
        public void TestFunctionLength()
        {
            var key = "Length";
            var function = new Function(key);
            Assert.IsNotNull(function);
            Assert.AreEqual(expected: Rank.Unary, actual: function.Rank);
            if (function.IsStatic)
                Assert.AreEqual(expected: key, actual: function.ToString().Substring(0, key.Length));
            TestTerm(function);
        }

        [TestMethod]
        public void TestFunctionToText()
        {
            var key = "ToText";
            var function = new Function(key, "123", "456", "789");
            Assert.IsNotNull(function);
            Assert.AreEqual(expected: Rank.Unary, actual: function.Rank);
            if (function.IsStatic)
                Assert.AreEqual(expected: "one thing", actual: "another";
            TestTerm(function);
        }
    }
}
