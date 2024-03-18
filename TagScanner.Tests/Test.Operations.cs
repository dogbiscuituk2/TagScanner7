using TagScanner.Models;

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
                var operation = new Operation(op);
                Assert.IsNotNull(operation);
                Assert.AreEqual(expected: op, actual: operation.Op);
                // Internally, concatenation with operator+ invokes the Concat method.
                // So, the expected ExpressionType in this case is Call, instead of Add.
                var nodeType = op == Op.Concatenate ? ExpressionType.Call : opInfo.ExpType;
                Assert.AreEqual(expected: nodeType, actual: operation.Expression.NodeType);
                Assert.AreEqual(expected: opInfo.Rank, actual: operation.Rank);
                Assert.AreEqual(expected: opInfo.ResultType, actual: operation.ResultType);
            }
            Term
                conditional = new Conditional(Tag.IsClassical, "Beethoven", "The Beatles"),
                equalTo = new Operation(Tag.Artists, '=', "The Beatles"),
                notEqualTo = new Operation(Tag.Artists, "!=", "The Beatles"),
                equalTo3 = new Operation('=', Tag.Artists, Tag.Performers, "The Beatles"),
                andOrOr = (equalTo | notEqualTo) & (notEqualTo | equalTo3),
                orAndAnd = (equalTo & notEqualTo) | (notEqualTo & equalTo3),
                orXorXor = (equalTo ^ notEqualTo) | (notEqualTo ^ equalTo3),
                xorOrOr = (equalTo | notEqualTo) ^ (notEqualTo | equalTo3);
            TestTerm(conditional);
            TestTerm(equalTo);
            TestTerm(notEqualTo);
            TestTerm(equalTo3);
            TestTerm(andOrOr);
            TestTerm(orAndAnd);
            TestTerm(orXorXor);
            TestTerm(xorOrOr);
            TestTerm(new Operation('<', 1, 2, 3, 4, 5));
            TestTerm(new Operation("<=", 1, 2, 3, 4, 5));
            TestTerm(new Operation(">=", 5, 4, 3, 2, 1));
            TestTerm(new Operation(">", 5, 4, 3, 2, 1));
            TestTerm(new Concatenation("123", "456", "789"));
            Term
                onePlusTwoPlusThree = new Sum(1, 2, 3),
                fourMinusFive = new Difference(4, 5),
                sixTimesSevenTimesEight = new Product(6, 7, 8),
                nineTenths = new Quotient(9, 10);
            TestTerm(onePlusTwoPlusThree);
            TestTerm(fourMinusFive);
            TestTerm(sixTimesSevenTimesEight);
            TestTerm(nineTenths);
            TestTerm(onePlusTwoPlusThree.MultiplyBy(fourMinusFive).DivideBy(sixTimesSevenTimesEight).Subtract(nineTenths));
            TestTerm(new Operation('+', 123));
            TestTerm(new Operation('-', 123));
            TestTerm(new Operation('!', equalTo));
        }

        public void TestTerm(Term term)
        {
            System.Diagnostics.Debug.WriteLine(term);
            if (!(term is Umptad umptad)) return;
            for (var index = 0; index < umptad.Operands.Count; index++)
            {
                var start = umptad.Start(index);
                var subTerm = umptad.Operands[index];
                var length = subTerm.Length;
                var expected = subTerm.ToString();
                var actual = umptad.ToString().Substring(start, length);
                Assert.AreEqual(expected, actual);
                TestTerm(subTerm);
            }
        }
    }
}
