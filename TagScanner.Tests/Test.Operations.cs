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
                // Arity?
                Assert.AreEqual(expected: op.Associates(), actual: operation.IsAssociative);
                Assert.AreEqual(expected: op, actual: operation.Op);
                Assert.AreEqual(expected: paramArray, actual: operation.ParamArray);
                Assert.AreEqual(expected: unary ? 1 : 2, actual: operation.ParameterTypes.Count());
                Assert.AreEqual(expected: op.GetRank(), actual: operation.Rank);
                Assert.AreEqual(expected: op.ResultType(), actual: operation.ResultType);
                AddTestValues(operation);
                Assert.AreEqual(expected: operandsCount, actual: operation.Operands.Count);
                TestParse(operation);
            }
        }
    }
}
