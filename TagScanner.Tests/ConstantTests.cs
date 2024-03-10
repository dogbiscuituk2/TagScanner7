namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TagScanner.Terms;

    [TestClass]
    public class ConstantTests
    {
        [ClassInitialize] public static void ClassInitialize(TestContext _) { }
        [TestInitialize] public void TestInitialize() { Core.ResetDefaults(); }
        [TestCleanup] public void TestCleanup() { }
        [ClassCleanup] public static void ClassCleanup() { }

        [TestMethod]
        public void ConstantBool()
        {
            var term = new Constant(true);
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: true, actual: term.Value);
            Assert.AreEqual(expected: "true", actual: term.ToCode());
            Assert.AreEqual(expected: "true", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "True", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConstantChar()
        {
            var term = new Constant('A');
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(char), actual: term.ResultType);
            Assert.AreEqual(expected: 'A', actual: term.Value);
            Assert.AreEqual(expected: "'A'", actual: term.ToCode());
            Assert.AreEqual(expected: "'A'", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "A", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConstantDouble()
        {
            var term = new Constant(1.0);
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: 1.0, actual: term.Value);
            Assert.AreEqual(expected: "1", actual: term.ToCode());
            Assert.AreEqual(expected: "1", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "1", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConstantFalse()
        {
            var term = Constant.False;
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: false, actual: term.Value);
            Assert.AreEqual(expected: "false", actual: term.ToCode());
            Assert.AreEqual(expected: "false", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "False", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConstantFloat()
        {
            var term = new Constant((float)1);
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(float), actual: term.ResultType);
            Assert.AreEqual(expected: 1.0f, actual: term.Value);
            Assert.AreEqual(expected: "1", actual: term.ToCode());
            Assert.AreEqual(expected: "1", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "1", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConstantInt()
        {
            var term = new Constant(1234567890);
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(int), actual: term.ResultType);
            Assert.AreEqual(expected: 1234567890, actual: term.Value);
            Assert.AreEqual(expected: "1234567890", actual: term.ToCode());
            Assert.AreEqual(expected: "1234567890", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "1234567890", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConstantLong()
        {
            var term = new Constant(9876543210);
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(long), actual: term.ResultType);
            Assert.AreEqual(expected: 9876543210, actual: term.Value);
            Assert.AreEqual(expected: "9876543210", actual: term.ToCode());
            Assert.AreEqual(expected: "9876543210", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "9876543210", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConstantString()
        {
            var term = new Constant("Abc");
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(string), actual: term.ResultType);
            Assert.AreEqual(expected: "Abc", actual: term.Value);
            Assert.AreEqual(expected: "\"Abc\"", actual: term.ToCode());
            Assert.AreEqual(expected: "\"Abc\"", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "\"Abc\"", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConstantTrue()
        {
            var term = Constant.True;
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: true, actual: term.Value);
            Assert.AreEqual(expected: "true", actual: term.ToCode());
            Assert.AreEqual(expected: "true", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "True", actual: term.Expression.ToString());
        }
    }
}
