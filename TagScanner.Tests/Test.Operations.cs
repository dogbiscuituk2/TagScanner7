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
            foreach (var key in Core.Operators.Keys)
            {
                var opInfo = Core.Operators[key];
                var term = new Operation(key);
                Assert.IsNotNull(term);
                Assert.AreEqual(expected: key, actual: term.Op);
                // Internally, concatenation with operator+ invokes the Concat method.
                // So, the expected ExpressionType in this case is Call, instead of Add.
                var expType = key == Op.Concatenate ? ExpressionType.Call : opInfo.ExpType;
                Assert.AreEqual(expected: expType, actual: term.Expression.NodeType);
                Assert.AreEqual(expected: opInfo.Rank, actual: term.Rank);
                Assert.AreEqual(expected: opInfo.ResultType, actual: term.ResultType);
            }
        }
    }
}
