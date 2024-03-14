namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using System;
    using System.Linq;

    public partial class Test
    {
        private static readonly Type[] sortableTypes = new Type[] { typeof(DateTime), typeof(double), typeof(int), typeof(long), typeof(string), typeof(TimeSpan) };

        [TestMethod]
        public void TestTags()
        {
            foreach (var tag in Tags.AllTags)
            {
                var property = typeof(IWork).GetProperty(tag.Name);
                Assert.IsNotNull(property);
                bool
                    canRead = true,
                    canSort = tag.Type.BaseType == typeof(Enum) || sortableTypes.Contains(tag.Type),
                    canWrite = property.SetMethod != null;
                var column = tag.Column;
                Assert.IsNotNull(property);
                //var foo = column.
                Assert.AreEqual(expected: canRead, actual: tag.CanRead);
                Assert.AreEqual(expected: canSort, actual: tag.CanSort);
                Assert.AreEqual(expected: canWrite, actual: tag.CanWrite);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tag.Category));
                Assert.IsFalse(string.IsNullOrWhiteSpace(tag.Details));
                Assert.IsFalse(string.IsNullOrWhiteSpace(tag.DisplayName));
                Assert.AreNotEqual(notExpected: canWrite, actual: tag.ReadOnly);
                Assert.AreEqual(expected: property.PropertyType, actual: tag.Type);

//                var foo = tag.Column
            }
        }
    }
}
