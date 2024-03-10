namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TagScanner.Terms;

    [TestClass]
    public class TriadTests
    {
        [ClassInitialize] public static void ClassInitialize(TestContext _) { }
        [TestInitialize] public void TestInitialize() { Core.ResetDefaults(); }
        [TestCleanup] public void TestCleanup() { }
        [ClassCleanup] public static void ClassCleanup() { }

        private readonly Constant
            True = Constant.True,
            False = Constant.False,
            One = new Constant(1),
            Two = new Constant(2L),
            Three = new Constant(3.0f),
            Four = new Constant(4.0);

        [TestMethod]
        public void ConditionalTest01()
        {
            var term = new Conditional(True, One, One);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(int), actual: term.ResultType);
            Assert.AreEqual(expected: "true ? 1 : 1", actual: term.ToCode());
            Assert.AreEqual(expected: "if true then 1 else 1", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(True, 1, 1)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest02()
        {
            var term = new Conditional(False, One, Two);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(long), actual: term.ResultType);
            Assert.AreEqual(expected: "false ? 1 : 2", actual: term.ToCode());
            Assert.AreEqual(expected: "if false then 1 else 2", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(False, Convert(1), 2)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest03()
        {
            var term = new Conditional(True, One, Three);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(float), actual: term.ResultType);
            Assert.AreEqual(expected: "true ? 1 : 3", actual: term.ToCode());
            Assert.AreEqual(expected: "if true then 1 else 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(True, Convert(1), 3)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest04()
        {
            var term = new Conditional(True, One, Four);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "true ? 1 : 4", actual: term.ToCode());
            Assert.AreEqual(expected: "if true then 1 else 4", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(True, Convert(1), 4)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest05()
        {
            var term = new Conditional(True, Two, One);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(long), actual: term.ResultType);
            Assert.AreEqual(expected: "true ? 2 : 1", actual: term.ToCode());
            Assert.AreEqual(expected: "if true then 2 else 1", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(True, 2, Convert(1))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest06()
        {
            var term = new Conditional(False, Two, Two);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(long), actual: term.ResultType);
            Assert.AreEqual(expected: "false ? 2 : 2", actual: term.ToCode());
            Assert.AreEqual(expected: "if false then 2 else 2", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(False, 2, 2)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest07()
        {
            var term = new Conditional(True, Two, Three);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(float), actual: term.ResultType);
            Assert.AreEqual(expected: "true ? 2 : 3", actual: term.ToCode());
            Assert.AreEqual(expected: "if true then 2 else 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(True, Convert(2), 3)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest08()
        {
            var term = new Conditional(False, Two, Four);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "false ? 2 : 4", actual: term.ToCode());
            Assert.AreEqual(expected: "if false then 2 else 4", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(False, Convert(2), 4)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest09()
        {
            var term = new Conditional(True, Three, One);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(float), actual: term.ResultType);
            Assert.AreEqual(expected: "true ? 3 : 1", actual: term.ToCode());
            Assert.AreEqual(expected: "if true then 3 else 1", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(True, 3, Convert(1))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest10()
        {
            var term = new Conditional(False, Three, Two);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(float), actual: term.ResultType);
            Assert.AreEqual(expected: "false ? 3 : 2", actual: term.ToCode());
            Assert.AreEqual(expected: "if false then 3 else 2", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(False, 3, Convert(2))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest11()
        {
            var term = new Conditional(True, Three, Three);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(float), actual: term.ResultType);
            Assert.AreEqual(expected: "true ? 3 : 3", actual: term.ToCode());
            Assert.AreEqual(expected: "if true then 3 else 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(True, 3, 3)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest12()
        {
            var term = new Conditional(False, Three, Four);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "false ? 3 : 4", actual: term.ToCode());
            Assert.AreEqual(expected: "if false then 3 else 4", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(False, Convert(3), 4)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest13()
        {
            var term = new Conditional(True, Four, One);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "true ? 4 : 1", actual: term.ToCode());
            Assert.AreEqual(expected: "if true then 4 else 1", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(True, 4, Convert(1))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest14()
        {
            var term = new Conditional(False, Four, Two);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "false ? 4 : 2", actual: term.ToCode());
            Assert.AreEqual(expected: "if false then 4 else 2", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(False, 4, Convert(2))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest15()
        {
            var term = new Conditional(True, Four, Three);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "true ? 4 : 3", actual: term.ToCode());
            Assert.AreEqual(expected: "if true then 4 else 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(True, 4, Convert(3))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest16()
        {
            var term = new Conditional(False, Four, Four);
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "false ? 4 : 4", actual: term.ToCode());
            Assert.AreEqual(expected: "if false then 4 else 4", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(False, 4, 4)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void ConditionalTest17()
        {
            var term = new Conditional(True, new Conditional(False, One, Two), new Conditional(False, Three, Four));
            Assert.AreEqual(expected: Operator.Conditional, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Conditional, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "true ? false ? 1 : 2 : false ? 3 : 4", actual: term.ToCode());
            Assert.AreEqual(expected: "if true then if false then 1 else 2 else if false then 3 else 4", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "IIF(True, Convert(IIF(False, Convert(1), 2)), IIF(False, Convert(3), 4))", actual: term.Expression.ToString());
        }
    }
}
