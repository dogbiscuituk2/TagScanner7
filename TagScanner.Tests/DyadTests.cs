namespace TagScanner.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TagScanner.Models;
    using TagScanner.Terms;

    [TestClass]
    public class DyadTests
    {
        [ClassInitialize] public static void ClassInitialize(TestContext _) { }
        [TestInitialize] public void TestInitialize() { Core.ResetDefaults(); }
        [TestCleanup] public void TestCleanup() { }
        [ClassCleanup] public static void ClassCleanup() { }

        private readonly Constant
            True = new Constant(true), False = new Constant(false),
            One = new Constant(1), Two = new Constant(2), Three = new Constant(3), Four = new Constant(4),
            OneL = new Constant(1L), TwoL = new Constant(2L), ThreeL = new Constant(3L), FourL = new Constant(4L),
            OneD = new Constant(1.0), TwoD = new Constant(2.0), ThreeD = new Constant(3.0), FourD = new Constant(4.0),
            Beatles = new Constant("The Beatles"),
            SgtPepper = new Constant("Sgt. Pepper's Lonely Hearts Club Band");

        [TestMethod]
        public void DyadTest01()
        {
            var term = new Conjunction(True, False);
            Assert.AreEqual(expected: Operator.And, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.ConditionalAND, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "true && false", actual: term.ToCode());
            Assert.AreEqual(expected: "true and false", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(True AndAlso False)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest02()
        {
            var term = new Disjunction(True, False);
            Assert.AreEqual(expected: Operator.Or, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.ConditionalOR, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "true || false", actual: term.ToCode());
            Assert.AreEqual(expected: "true or false", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(True OrElse False)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest03()
        {
            var term = new Operation(True, Operator.Xor, False);
            Assert.AreEqual(expected: Operator.Xor, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.BitwiseXOR, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "true ^ false", actual: term.ToCode());
            Assert.AreEqual(expected: "true xor false", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(True ^ False)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest04()
        {
            var term = new Sum(One, Two);
            Assert.AreEqual(expected: Operator.Add, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Additive, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(int), actual: term.ResultType);
            Assert.AreEqual(expected: "1 + 2", actual: term.ToCode());
            Assert.AreEqual(expected: "1 + 2", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(1 + 2)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest05()
        {
            var term = new Difference(Three, TwoL);
            Assert.AreEqual(expected: Operator.Subtract, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Additive, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(long), actual: term.ResultType);
            Assert.AreEqual(expected: "3 - 2", actual: term.ToCode());
            Assert.AreEqual(expected: "3 - 2", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(Convert(3) - 2)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest06()
        {
            var term = new Product(Two, FourD);
            Assert.AreEqual(expected: Operator.Multiply, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Multiplicative, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "2 * 4", actual: term.ToCode());
            Assert.AreEqual(expected: "2 × 4", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(Convert(2) * 4)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest07()
        {
            var term = new Quotient(FourL, TwoD);
            Assert.AreEqual(expected: Operator.Divide, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Multiplicative, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "4 / 2", actual: term.ToCode());
            Assert.AreEqual(expected: "4 ÷ 2", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(Convert(4) / 2)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest08()
        {
            Operation
                left = new Sum(OneL, Two),
                right = new Difference(ThreeL, OneD),
                term = new Product(left, right);
            Assert.AreEqual(expected: Operator.Multiply, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Multiplicative, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(double), actual: term.ResultType);
            Assert.AreEqual(expected: "(1 + 2) * (3 - 1)", actual: term.ToCode());
            Assert.AreEqual(expected: "(1 + 2) × (3 - 1)", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(Convert((1 + Convert(2))) * (Convert(3) - 1))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest09()
        {
            var term = new Concatenation(new Constant("123"), new Constant("456"), new Constant("789"));
            Assert.AreEqual(expected: Operator.Add, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Additive, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(string), actual: term.ResultType);
            Assert.AreEqual(expected: "\"123\" + \"456\" + \"789\"", actual: term.ToCode());
            Assert.AreEqual(expected: "\"123\" + \"456\" + \"789\"", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "Concat(\"123\", \"456\", \"789\")", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest10()
        {
            var term = new Operation(new Sum(One, OneD), Operator.EqualTo, Two);
            Assert.AreEqual(expected: Operator.EqualTo, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Equality, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "1 + 1 == 2", actual: term.ToCode());
            Assert.AreEqual(expected: "1 + 1 = 2", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "((Convert(1) + 1) == Convert(2))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest11()
        {
            var term = new Operation(ThreeD, Operator.NotEqualTo, Four);
            Assert.AreEqual(expected: Operator.NotEqualTo, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Equality, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "3 != 4", actual: term.ToCode());
            Assert.AreEqual(expected: "3 ≠ 4", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(3 != Convert(4))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest12()
        {
            var term = new Operation(One, Operator.LessThan, Two);
            Assert.AreEqual(expected: Operator.LessThan, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Relational, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "1 < 2", actual: term.ToCode());
            Assert.AreEqual(expected: "1 < 2", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(1 < 2)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest13()
        {
            var term = new Operation(Two, Operator.GreaterThan, One);
            Assert.AreEqual(expected: Operator.GreaterThan, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Relational, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "2 > 1", actual: term.ToCode());
            Assert.AreEqual(expected: "2 > 1", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(2 > 1)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest14()
        {
            var term = new Operation(One, Operator.NotGreaterThan, Two);
            Assert.AreEqual(expected: Operator.NotGreaterThan, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Relational, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "1 <= 2", actual: term.ToCode());
            Assert.AreEqual(expected: "1 ≤ 2", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(1 <= 2)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest15()
        {
            var term = new Operation(Two, Operator.NotLessThan, One);
            Assert.AreEqual(expected: Operator.NotLessThan, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Relational, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "2 >= 1", actual: term.ToCode());
            Assert.AreEqual(expected: "2 ≥ 1", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(2 >= 1)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest16()
        {
            var term = new Operation(new Field(Tags.JoinedPerformers), Operator.EqualTo, Beatles);
            Assert.AreEqual(expected: Operator.EqualTo, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Equality, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "T.JoinedPerformers == \"The Beatles\"", actual: term.ToCode());
            Assert.AreEqual(expected: "Performers (joined) = \"The Beatles\"", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(T.JoinedPerformers == \"The Beatles\")", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest17()
        {
            var term = new Operation(new Field(Tags.Album), Operator.NotEqualTo, SgtPepper);
            Assert.AreEqual(expected: Operator.NotEqualTo, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Equality, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "T.Album != \"Sgt. Pepper's Lonely Hearts Club Band\"", actual: term.ToCode());
            Assert.AreEqual(expected: "Album Title ≠ \"Sgt. Pepper's Lonely Hearts Club Band\"", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(T.Album != \"Sgt. Pepper's Lonely Hearts Club Band\")", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest18()
        {
            var term = new Operation(new Field(Tags.Year), Operator.NotGreaterThan, new Constant(1970));
            Assert.AreEqual(expected: Operator.NotGreaterThan, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Relational, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "T.Year <= 1970", actual: term.ToCode());
            Assert.AreEqual(expected: "Year ≤ 1970", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(T.Year <= 1970)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest19()
        {
            var term = new Operation(new Field(Tags.Decade), Operator.EqualTo, new Constant("1960s"));
            Assert.AreEqual(expected: Operator.EqualTo, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Equality, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "T.Decade == \"1960s\"", actual: term.ToCode());
            Assert.AreEqual(expected: "Decade = \"1960s\"", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(T.Decade == \"1960s\")", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest20()
        {
            var term = new Operation(new Field(Tags.FileSize), Operator.LessThan, new Constant(3000000));
            Assert.AreEqual(expected: Operator.LessThan, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Relational, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "T.FileSize < 3000000", actual: term.ToCode());
            Assert.AreEqual(expected: "File Size < 3000000", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(T.FileSize < Convert(3000000))", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest21()
        {
            var term = new Operation(new Field(Tags.Duration), Operator.NotLessThan, new Constant(new TimeSpan(0, 3, 0)));
            Assert.AreEqual(expected: Operator.NotLessThan, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Relational, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "T.Duration >= TimeSpan.Parse(\"00:03:00\")", actual: term.ToCode());
            Assert.AreEqual(expected: "Duration ≥ TimeSpan.Parse(\"00:03:00\")", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(T.Duration >= 00:03:00)", actual: term.Expression.ToString());
        }

        [TestMethod]
        public void DyadTest22()
        {
            var term = new Operation(new Field(Tags.FileCreationTime), Operator.NotLessThan, new Constant(new DateTime(1960, 1, 31)));
            Assert.AreEqual(expected: Operator.NotLessThan, actual: term.Operator);
            Assert.AreEqual(expected: Precedence.Relational, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(bool), actual: term.ResultType);
            Assert.AreEqual(expected: "T.FileCreationTime >= DateTime.Parse(\"31/01/1960 00:00:00\")", actual: term.ToCode());
            Assert.AreEqual(expected: "File Created ≥ DateTime.Parse(\"31/01/1960 00:00:00\")", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "(T.FileCreationTime >= 31/01/1960 00:00:00)", actual: term.Expression.ToString());
        }
    }
}
