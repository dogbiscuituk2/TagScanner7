namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestOperations()
        {
            foreach (var op in Operators.Keys.Where(p => p != 0 && p != Op.Let && p != Op.Dot))
            {
                var operation = new Operation(op);
                var infinitary = op.IsInfinitary();
                var unary = op.IsUnary();
                var associativity = op.GetAssociativity();
                var associates = associativity != 0;
                var operandsCount = unary ? 1 : associates ? 4 : 2;
                Assert.IsNotNull(operation);
                Assert.AreEqual(expected: associates, actual: operation.Associates);
                Assert.AreEqual(expected: associativity, actual: operation.Associativity);
                Assert.AreEqual(expected: op, actual: operation.Op);
                Assert.AreEqual(expected: unary ? 1 : 2, actual: operation.ParameterTypes.Count());
                Assert.AreEqual(expected: op.GetRank(), actual: operation.Rank);
                Assert.AreEqual(expected: op.ResultType(), actual: operation.ResultType);
                AddTestValues(operation);
                Assert.AreEqual(expected: operandsCount, actual: operation.Operands.Count);
                TestParse(operation);
            }
        }

        #region Logical Operators

        [DataRow("false & false", false)]
        [DataRow("False & True", false)]
        [DataRow("truE & falsE", false)]
        [DataRow("TRUE & TRUE", true)]

        [DataRow("false && false", false)]
        [DataRow("False && True", false)]
        [DataRow("truE && falsE", false)]
        [DataRow("TRUE && TRUE", true)]

        [DataRow("false and false", false)]
        [DataRow("False And True", false)]
        [DataRow("truE anD falsE", false)]
        [DataRow("TRUE AND TRUE", true)]

        [DataRow("false | false", false)]
        [DataRow("False | True", true)]
        [DataRow("truE | falsE", true)]
        [DataRow("TRUE | TRUE", true)]

        [DataRow("false || false", false)]
        [DataRow("False || True", true)]
        [DataRow("truE || falsE", true)]
        [DataRow("TRUE || TRUE", true)]

        [DataRow("false or false", false)]
        [DataRow("False Or True", true)]
        [DataRow("truE oR falsE", true)]
        [DataRow("TRUE OR TRUE", true)]

        [DataRow("false ^ false", false)]
        [DataRow("False ^ True", true)]
        [DataRow("truE ^ falsE", true)]
        [DataRow("TRUE ^ TRUE", false)]

        [DataRow("false ^ false", false)]
        [DataRow("False ^ True", true)]
        [DataRow("truE ^ falsE", true)]
        [DataRow("TRUE ^ TRUE", false)]

        [DataRow("false xor false", false)]
        [DataRow("False Xor True", true)]
        [DataRow("truE xoR falsE", true)]
        [DataRow("TRUE XOR TRUE", false)]

        #endregion
        #region Equality | Relational Operations

        [DataRow("2 = 2", true)]
        [DataRow("2 = 2.0", true)]
        [DataRow("2.0 = 2", true)]
        [DataRow("2.5 = 2.5", true)]
        [DataRow("\"Abc\" = \"abc\"", false, true)]
        [DataRow("\"123\" = 123", false)]

        [DataRow("2 != 2", false)]
        [DataRow("2 != 2.0", false)]
        [DataRow("2.0 != 2", false)]
        [DataRow("2.5 != 2.5", false)]
        [DataRow("\"Abc\" != \"abc\"", true, false)]
        [DataRow("\"123\" != 123", true)]

        [DataRow("2 < 3", true)]
        [DataRow("2 < 3.0", true)]
        [DataRow("4.0 < 3", false)]
        [DataRow("3.5 < 2.5", false)]

        [DataRow("2 <= 3", true)]
        [DataRow("2 <= 3.0", true)]
        [DataRow("4.0 <= 3", false)]
        [DataRow("3.5 <= 2.5", false)]

        [DataRow("2 >= 3", false)]
        [DataRow("2 >= 3.0", false)]
        [DataRow("4.0 >= 3", true)]
        [DataRow("3.5 >= 2.5", true)]

        [DataRow("2 > 3", false)]
        [DataRow("2 > 3.0", false)]
        [DataRow("4.0 > 3", true)]
        [DataRow("3.5 > 2.5", true)]

        #endregion
        #region Concatenation

        [DataRow("\"1\" + \"2\" + \"3\" + \"4\" + \"5\"", "12345")]

        #endregion
        #region Arithmetic Operations

        [DataRow("2 + 3", 5)]
        [DataRow("2 + 3.5", 5.5)]
        [DataRow("3.5 + 2", 5.5)]
        [DataRow("3.5 + 2.5", 6D)]
        [DataRow("12 - 3", 9)]
        [DataRow("12 - 3.5", 8.5)]
        [DataRow("3.5 - 12", -8.5)]
        [DataRow("3.5 - 12.5", -9D)]
        [DataRow("2 * 3", 6)]
        [DataRow("2 * 3", 6)]
        [DataRow("3 * 2", 6)]
        [DataRow("3 * 2", 6)]
        [DataRow("12 / 3", 4)]
        [DataRow("12 / 3", 4)]
        [DataRow("3 / 12", 0)]
        [DataRow("3 / 12", 0)]
        [DataRow("12 % 3", 0)]
        [DataRow("12 % 3", 0)]
        [DataRow("3 % 12", 3)]
        [DataRow("3 % 12", 3)]

        #endregion
        #region Unary Operations

        [DataRow("+123", 123)]
        [DataRow("+123.0", 123D)]
        [DataRow("+ 123", 123)]
        [DataRow("+ 123.0", 123D)]
        [DataRow("-123", -123)]
        [DataRow("-123.0", -123D)]
        [DataRow("- 123", -123)]
        [DataRow("- 123.0", -123D)]
        [DataRow("----123", 123)]
        [DataRow("----123.0", 123D)]
        [DataRow("!true", false)]
        [DataRow("! false", true)]
        [DataRow("not false", true)]
        [DataRow("NOT! False", false)]

        #endregion
        #region Associativity

        [DataRow("true and true and true", true)]
        [DataRow("true And true AND false", false)]
        [DataRow("true & false & true", false)]
        [DataRow("false && true && true", false)]

        [DataRow("true or true or true", true)]
        [DataRow("true Or true OR false", true)]
        [DataRow("true | false | true", true)]
        [DataRow("false || true || true", true)]

        [DataRow("true xor true xor true", true)]
        [DataRow("true Xor true XOR false", false)]
        [DataRow("true ^ false ^ true", false)]

        [DataRow("2 = 1+1 = 2", true)]
        [DataRow("2 != 1 != 2", true)]

        [DataRow("2 < 3 < 5", true)]
        [DataRow("2 < 3 < 1", false)]
        [DataRow("2 <= 3 <= 5", true)]
        [DataRow("2 <= 3 <= 1", false)]
        [DataRow("5 > 3 > 2", true)]
        [DataRow("5 > 3 > 3", false)]
        [DataRow("5 >= 3 >= 3", true)]
        [DataRow("2 >= 3 >= 1", false)]

        [DataRow("(\"a\" + \"b\") + \"c\" + (\"d\" + \"e\")", "abcde")]

        [DataRow("2 + 3 + 5", 10)]
        [DataRow("2 + (3 + 5)", 10)]
        [DataRow("(2 + 3) + 5", 10)]

        [DataRow("2 - 3 - 5", -6)]
        [DataRow("2 - (3 - 5)", 4)]
        [DataRow("(2 - 3) - 5", -6)]

        [DataRow("2 * 3 * 5", 30)]
        [DataRow("2 * (3 * 5)", 30)]
        [DataRow("(2 * 3) * 5", 30)]

        [DataRow("2 / 3 / 5", 0)]
        [DataRow("2 / (3 / 5)", null)]
        [DataRow("(2 / 3) / 5", 0)]

        [DataRow("65 % 6 % 3", 2)]
        [DataRow("65 % (5 % 3)", 1)]
        [DataRow("(65 % 11) % 5", 0)]

        #endregion
        #region Distributivity

        [DataRow("2 * 3 + 5", 11)]
        [DataRow("2 * (3 + 5)", 16)]
        [DataRow("2 + 3 * 5", 17)]
        [DataRow("(2 + 3) * 5", 25)]

        [DataRow("2 * 3 - 5", 1)]
        [DataRow("2 * (3 - 5)", -4)]
        [DataRow("2 - 3 * 5", -13)]
        [DataRow("(2 - 3) * 5", -5)]

        #endregion

        [TestMethod]
        public void TestOperationResult(string text, object sense, object nonsense = null) =>
            TestResult(text, sense, nonsense);

        /*
        [DataRow("X := 123", 123)]
        [TestMethod]
        public void ScratchTestOperationResult(string text, object sense, object nonsense = null) =>
            TestResult(text, sense, nonsense);
        */
    }
}
