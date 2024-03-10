namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TagScanner.Terms;

    [TestClass]
    public class OperationTests
    {
        [ClassInitialize] public static void ClassInitialize(TestContext _) { }
        [TestInitialize] public void TestInitialize() { Core.ResetDefaults(); }
        [TestCleanup] public void TestCleanup() { }
        [ClassCleanup] public static void ClassCleanup() { }

        private readonly Constant
            True = Constant.True, False = Constant.False,
            One = new Constant(1), Two = new Constant(2), Three = new Constant(3), Four = new Constant(4),
            OneL = new Constant(1L), TwoL = new Constant(2L), ThreeL = new Constant(3L), FourL = new Constant(4L),
            OneF = new Constant(1.0f), TwoF = new Constant(2.0f), ThreeF = new Constant(3.0f), FourF = new Constant(4.0f),
            OneD = new Constant(1.0), TwoD = new Constant(2.0), ThreeD = new Constant(3.0), FourD = new Constant(4.0);

        [TestMethod]
        public void OperationTest01()
        {
            var term = new Conjunction(True, True, False);
            Assert.AreEqual(expected: Operator.And, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.ConditionalAND, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "true && true && false", actual: term.ToCode());
            Assert.AreEqual(expected: "true and true and false", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((True AndAlso True) AndAlso False)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest02()
        {
            var term = new Disjunction(True, True, False);
            Assert.AreEqual(expected: Operator.Or, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.ConditionalOR, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "true || true || false", actual: term.ToCode());
            Assert.AreEqual(expected: "true or true or false", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((True OrElse True) OrElse False)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest03()
        {
            var term = new Operation(Operator.Xor, True, True, False);
            Assert.AreEqual(expected: Operator.Xor, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.BitwiseXOR, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "true ^ true ^ false", actual: term.ToCode());
            Assert.AreEqual(expected: "true xor true xor false", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((True ^ True) ^ False)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest04()
        {
            var term = new Sum(One, Two, Three);
            Assert.AreEqual(expected: Operator.Add, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Additive, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(int), actual: term.ResultType);
            Assert.AreEqual(expected: "1 + 2 + 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 + 2 + 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((1 + 2) + 3)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest05()
        {
            var term = new Sum(OneL, Two, Three);
            Assert.AreEqual(expected: Operator.Add, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Additive, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(long), actual: term.ResultType);
            Assert.AreEqual(expected: "1 + 2 + 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 + 2 + 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((1 + Convert(2)) + Convert(3))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest06()
        {
            var term = new Sum(One, TwoF, Three);
            Assert.AreEqual(expected: Operator.Add, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Additive, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(float), actual: term.ResultType);
            Assert.AreEqual(expected: "1 + 2 + 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 + 2 + 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((Convert(1) + 2) + Convert(3))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest07()
        {
            var term = new Sum(One, Two, ThreeD);
            Assert.AreEqual(expected: Operator.Add, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Additive, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "1 + 2 + 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 + 2 + 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(Convert((1 + 2)) + 3)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest08()
        {
            var term = new Difference(One, Two, Three);
            Assert.AreEqual(expected: Operator.Subtract, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Additive, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(int), actual: term.ResultType);
            Assert.AreEqual(expected: "1 - 2 - 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 - 2 - 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((1 - 2) - 3)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest09()
        {
            var term = new Difference(OneL, Two, Three);
            Assert.AreEqual(expected: Operator.Subtract, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Additive, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(long), actual: term.ResultType);
            Assert.AreEqual(expected: "1 - 2 - 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 - 2 - 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((1 - Convert(2)) - Convert(3))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest10()
        {
            var term = new Difference(One, TwoF, Three);
            Assert.AreEqual(expected: Operator.Subtract, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Additive, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(float), actual: term.ResultType);
            Assert.AreEqual(expected: "1 - 2 - 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 - 2 - 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((Convert(1) - 2) - Convert(3))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest11()
        {
            var term = new Difference(One, Two, ThreeD);
            Assert.AreEqual(expected: Operator.Subtract, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Additive, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "1 - 2 - 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 - 2 - 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(Convert((1 - 2)) - 3)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest12()
        {
            var term = new Product(One, Two, Three);
            Assert.AreEqual(expected: Operator.Multiply, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Multiplicative, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(int), actual: term.ResultType);
            Assert.AreEqual(expected: "1 * 2 * 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 × 2 × 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((1 * 2) * 3)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest13()
        {
            var term = new Product(OneL, Two, Three);
            Assert.AreEqual(expected: Operator.Multiply, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Multiplicative, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(long), actual: term.ResultType);
            Assert.AreEqual(expected: "1 * 2 * 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 × 2 × 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((1 * Convert(2)) * Convert(3))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest14()
        {
            var term = new Product(One, TwoF, Three);
            Assert.AreEqual(expected: Operator.Multiply, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Multiplicative, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(float), actual: term.ResultType);
            Assert.AreEqual(expected: "1 * 2 * 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 × 2 × 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((Convert(1) * 2) * Convert(3))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest15()
        {
            var term = new Product(One, Two, ThreeD);
            Assert.AreEqual(expected: Operator.Multiply, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Multiplicative, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "1 * 2 * 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 × 2 × 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(Convert((1 * 2)) * 3)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest16()
        {
            var term = new Quotient(One, Two, Three);
            Assert.AreEqual(expected: Operator.Divide, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Multiplicative, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(int), actual: term.ResultType);
            Assert.AreEqual(expected: "1 / 2 / 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 ÷ 2 ÷ 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((1 / 2) / 3)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest17()
        {
            var term = new Quotient(OneL, Two, Three);
            Assert.AreEqual(expected: Operator.Divide, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Multiplicative, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(long), actual: term.ResultType);
            Assert.AreEqual(expected: "1 / 2 / 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 ÷ 2 ÷ 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((1 / Convert(2)) / Convert(3))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest18()
        {
            var term = new Quotient(One, TwoF, Three);
            Assert.AreEqual(expected: Operator.Divide, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Multiplicative, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(float), actual: term.ResultType);
            Assert.AreEqual(expected: "1 / 2 / 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 ÷ 2 ÷ 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((Convert(1) / 2) / Convert(3))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void OperationTest19()
        {
            var term = new Quotient(One, Two, ThreeD);
            Assert.AreEqual(expected: Operator.Divide, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Multiplicative, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "1 / 2 / 3", actual: term.ToCode());
            Assert.AreEqual(expected: "1 ÷ 2 ÷ 3", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(Convert((1 / 2)) / 3)", actual: term.Expression.ToString());
        }
    }
}