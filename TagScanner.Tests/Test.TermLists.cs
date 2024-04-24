namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System;
    using Terms;
    using System.Text.RegularExpressions;

    public partial class Test
    {
        [TestMethod]
        public void TestTermLists()
        {
            var termList = new TermList(1, '2', "3", true, false, new Conditional(true, 4, 5));
            Assert.AreEqual(expected: "1, '2', \"3\", true, false, If(true, 4, 5)", actual: termList.ToString());
        }

        private void AddDefaultValues(TermList termList)
        {
            var operands = termList.Operands;
            var operandsCount = operands.Count;
            var paramTypes = termList.ParameterTypes.ToList();
            var paramsCount = paramTypes.Count;
            for (var index = operandsCount; index < paramsCount; index++)
            {
                var paramType = paramTypes[index];
                if (paramType.IsArray)
                    paramType = paramType.GetElementType();
                var term = GetTestterm(paramType);
                operands.Add(term);
                if (index == paramsCount - 1 && termList.ParamArray)
                    operands.AddRange(new[] { term, term });
            }
        }

        private Term GetTestterm(Type type) =>
            type == typeof(bool) ? true :
            type == typeof(char) ? 'A' :
            type == typeof(double) ? 3.14D :
            type == typeof(int) ? 123 :
            type == typeof(object) ||
            type == typeof(string) ? (Term)"abc" :
            type == typeof(RegexOptions) ? 1 :
            throw new NotImplementedException();
    }
}