﻿namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestFunctions()
        {
            foreach (var fn in Functors.Keys)
            {
                var function = new Function(fn);
                var isStatic = fn.IsStatic();
                var paramArray = fn.ParamArray();
                var paramTypesCount = fn.ParamCount() + (isStatic ? 0 : 1);
                var operandsCount = paramTypesCount + (paramArray ? 2 : 0);
                Assert.IsNotNull(function);
                // Arity?
                Assert.AreEqual(expected: fn, actual: function.Fn);
                Assert.AreEqual(expected: isStatic, actual: function.IsStatic);
                Assert.AreEqual(expected: paramArray, actual: function.ParamArray);
                Assert.AreEqual(expected: paramTypesCount, actual: function.ParameterTypes.Count());
                Assert.AreEqual(expected: Rank.Unary, actual: function.Rank);
                Assert.AreEqual(expected: fn.ResultType(), actual: function.ResultType);
                AddTestValues(function);
                Assert.AreEqual(expected: operandsCount, actual: function.Operands.Count);
                TestParse(function);
                var result = function.Result;
            }
        }

        [TestMethod]
        [DataRow("Compare(\"Abc\", \"Def\")", -1, -1)]
        [DataRow("\"Abc\" Compare \"Def\"", -1, -1)]
        [DataRow("Concat(\"A\", \"B\", \"C\", \"D\", \"E\")", "ABCDE")]
        public void TestFunction(string text, object sense, object nonsense = null)
        {
            var term = new Parser().Parse(text, caseSensitive: true);
            Assert.AreEqual(expected: sense, actual: term.Result);
            if (nonsense != null)
            {
                term = new Parser().Parse(text, caseSensitive: false);
                Assert.AreEqual(expected: nonsense, actual: term.Result);
            }
        }
    }
}
