namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestTermLists()
        {
            var termList = new TermList(1, 2.5, "3", true, false, new Conditional(true, 4, 5));
            Assert.AreEqual(expected: "1, 2.5D, \"3\", true, false, If(true, 4, 5)", actual: termList.ToString());
        }

        private void AddTestValues(TermList termList)
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
                var term = GetTestValue(paramType);
                operands.Add(term);
                if (index == paramsCount - 1 && termList.IsInfinitary)
                    operands.AddRange(new[] { term, term });
            }
        }

        private DateTime DateTimeForTest = new DateTime(1920, 11, 30, 12, 34, 56, 789);
        private TimeSpan TimeSpanForTest = new TimeSpan(12, 34, 56, 789);

        private Term GetTestValue(Type type) =>
            type == typeof(bool) ? true :
            type == typeof(char) ? 'A' :
            type == typeof(DateTime) ? DateTimeForTest :
            type == typeof(double) ? 3.1415D :
            type == typeof(int) ? 123456789 :
            type == typeof(long) ? 9876543210L :
            type == typeof(object) ? "object" :
            type == typeof(RegexOptions) ? 1 :
            type == typeof(string) ? "string" :
            type == typeof(TimeSpan) ? TimeSpanForTest :
            (Term)0;
    }
}