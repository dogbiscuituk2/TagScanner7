namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TagScanner.Terms;

    [TestClass]
    public class MonadTests
    {
        [ClassInitialize] public static void ClassInitialize(TestContext _) { }
        [TestInitialize] public void TestInitialize() { Core.ResetDefaults(); }
        [TestCleanup] public void TestCleanup() { }
        [ClassCleanup] public static void ClassCleanup() { }

        [TestMethod]
        public void MonadTest02()
        {
            var term = new Operation(Operator.Not, new Constant(true));
            Assert.AreEqual(expected: Operator.Not, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "!true", actual: term.ToCode());
            Assert.AreEqual(expected: "not true", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "Not(True)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void MonadTest03()
        {
            var term = new Operation(Operator.Not, new Constant(false));
            Assert.AreEqual(expected: Operator.Not, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "!false", actual: term.ToCode());
            Assert.AreEqual(expected: "not false", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "Not(False)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void MonadTest04()
        {
            var term = new Operation(Operator.Positive, new Constant(1234567890));
            Assert.AreEqual(expected: Operator.Positive, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(int), actual: term.ResultType);
            Assert.AreEqual(expected: "1234567890", actual: term.ToCode());
            Assert.AreEqual(expected: "1234567890", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "+1234567890", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void MonadTest05()
        {
            var term = new Operation(Operator.Negative, new Constant(1234567890));
            Assert.AreEqual(expected: Operator.Negative, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(int), actual: term.ResultType);
            Assert.AreEqual(expected: "- 1234567890", actual: term.ToCode());
            Assert.AreEqual(expected: "- 1234567890", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "-1234567890", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void MonadTest06()
        {
            var term = new Operation(Operator.Negative, new Constant(-1234567890));
            Assert.AreEqual(expected: Operator.Negative, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(int), actual: term.ResultType);
            Assert.AreEqual(expected: "- -1234567890", actual: term.ToCode());
            Assert.AreEqual(expected: "- -1234567890", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "--1234567890", actual: term.Expression.ToString());
        }
    }
}
