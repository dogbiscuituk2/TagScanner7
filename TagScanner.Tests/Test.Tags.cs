namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using Models;
    using Terms;

    public partial class Test
    {
        private static readonly Type[] SortableTypes = new Type[] { typeof(DateTime), typeof(double), typeof(int), typeof(long), typeof(string), typeof(TimeSpan) };

        [TestMethod]
        public void TestTags()
        {
            foreach (var tagInfo in Core.Tags.Values)
            {
                var property = typeof(IWork).GetProperty(tagInfo.Name);
                Assert.IsNotNull(property);
                bool
                    canSort = tagInfo.Type.BaseType == typeof(Enum) || SortableTypes.Contains(tagInfo.Type),
                    canWrite = property.SetMethod != null;
                var column = tagInfo.Column;
                Assert.IsNotNull(column);
                var columnType = tagInfo.Type == typeof(bool) ? ColumnType.CheckBox : ColumnType.Text;
                Assert.AreEqual(expected: true, actual: tagInfo.CanRead);
                Assert.AreEqual(expected: canSort, actual: tagInfo.CanSort);
                Assert.AreEqual(expected: canWrite, actual: tagInfo.CanWrite);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tagInfo.Category));
                Assert.AreNotEqual(notExpected: Alignment.Default, actual: column.Alignment); // All defaults resolved?
                Assert.AreEqual(expected: columnType, actual: column.Type);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tagInfo.Details));
                Assert.IsFalse(string.IsNullOrWhiteSpace(tagInfo.DisplayName));
                Assert.AreNotEqual(notExpected: canWrite, actual: tagInfo.ReadOnly);
                Assert.AreEqual(expected: property.PropertyType, actual: tagInfo.Type);
            }
        }
    }
}
