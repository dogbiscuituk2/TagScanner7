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
            foreach (var op in Operators.Keys.Where(p => p.IsVisible()))
            {
                var operation = new Operation(op);
                var unary = op.IsUnary();
                var paramArray = op.ParamArray();
                var operandsCount = unary ? 1 : paramArray ? 4 : 2;
                Assert.IsNotNull(operation);
                Assert.AreEqual(expected: op.GetAssociativity(), actual: operation.Associativity);
                Assert.AreEqual(expected: op, actual: operation.Op);
                Assert.AreEqual(expected: paramArray, actual: operation.ParamArray);
                Assert.AreEqual(expected: unary ? 1 : 2, actual: operation.ParameterTypes.Count());
                Assert.AreEqual(expected: op.GetRank(), actual: operation.Rank);
                Assert.AreEqual(expected: op.ResultType(), actual: operation.ResultType);
                AddTestValues(operation);
                Assert.AreEqual(expected: operandsCount, actual: operation.Operands.Count);

                if (op != Op.Comma)

                TestParse(operation);
            }
        }
        #region TermList

        //[DataRow("1, 2, 3", "")]

        #endregion
        #region Relational Operations

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

        #endregion
        #region Distributivity

        [DataRow("2 * 3 + 5", 11)]
        [DataRow("2 * (3 + 5)", 16)]
        [DataRow("2 + 3 * 5", 17)]
        [DataRow("(2 + 3) * 5", 25)]

        #endregion

        [TestMethod]
        public void TestOperationResult(string text, object sense, object nonsense = null) =>
            TestResult(text, sense, nonsense);

        //[DataRow("1, 2, 3", "")]
        //[TestMethod]
        public void ScratchTestOperationResult(string text, object sense, object nonsense = null) =>
            TestResult(text, sense, nonsense);
    }
}
