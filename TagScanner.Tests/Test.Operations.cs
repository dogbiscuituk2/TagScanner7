namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq.Expressions;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestOperations()
        {
            foreach (var op in Operators.Keys)
            {
                var opInfo = op.OpInfo();
                var term = new Operation(op);
                Assert.IsNotNull(term);
                Assert.AreEqual(expected: op, actual: term.Op);
                // Internally, concatenation with operator+ invokes the Concat method.
                // So, the expected ExpressionType in this case is Call, instead of Add.
                var nodeType = op == Op.Concatenate ? ExpressionType.Call : opInfo.ExpType;
                Assert.AreEqual(expected: nodeType, actual: term.Expression.NodeType);
                Assert.AreEqual(expected: opInfo.Rank, actual: term.Rank);
                Assert.AreEqual(expected: opInfo.ResultType, actual: term.ResultType);
            }
        }
    }
}
