using System.Linq.Expressions;

namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void CheckFields()
        {
            foreach (var tag in Tags.AllTags)
            {
                var term = new Field(tag.Name);
                Assert.IsNotNull(term);
                Assert.AreEqual(expected: tag.Name, actual: term.TagName);
                Assert.AreEqual(expected: Rank.Unary, actual: term.Rank);
                Assert.AreEqual(expected: tag.Name.Type(), actual: term.ResultType);
                Assert.AreEqual(expected: $"{tag.DisplayName}", actual: term.ToString());
                Assert.AreEqual(expected: $"T.{tag.Name}", actual: term.Expression.ToString());
            }
        }

        [TestMethod]
        public void CheckFunctions()
        {
            foreach (var key in Core.Methods.Keys)
            {
                var term = new Function(key);
                Assert.IsNotNull(term);
                Assert.AreEqual(expected: Rank.Unary, actual: term.Rank);
                if (term.Method.IsStatic)
                    Assert.AreEqual(expected: key, actual: term.ToString().Substring(0, key.Length));
            }
        }

        [TestMethod]
        public void CheckOperations()
        {
            foreach (var key in Core.Operators.Keys)
            {
                var opInfo = Core.Operators[key];
                var term = new Operation(key);
                Assert.IsNotNull(term);
                Assert.AreEqual(expected: key, actual: term.Op);
                // String concatenation, using the + operator, gets converted internally to Concat method invocation.
                // Therefore, the expected ExpressionType in this case is Call, instead of Add.
                var expType = key == Op.Concatenate ? ExpressionType.Call : opInfo.ExpType;
                Assert.AreEqual(expected: expType, actual: term.Expression.NodeType);
                Assert.AreEqual(expected: opInfo.Rank, actual: term.Rank);
                Assert.AreEqual(expected: opInfo.ResultType, actual: term.ResultType);
            }
        }
    }
}
