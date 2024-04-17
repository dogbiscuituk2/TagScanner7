namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using Models;
    using Terms;

    public partial class Test
    {
        private static readonly Type[] SortableTypes = { typeof(DateTime), typeof(double), typeof(int), typeof(long), typeof(string), typeof(TimeSpan) };

        [TestMethod]
        public void TestTags()
        {
            foreach (var tag in Tags.Keys)
            {
                var property = typeof(ITrack).GetProperty(tag.Name());
                Assert.IsNotNull(property);
                bool
                    canSort = tag.Type().BaseType == typeof(Enum) || SortableTypes.Contains(tag.Type()),
                    canWrite = property.SetMethod != null;
                var column = tag.Column();
                Assert.IsNotNull(column);
                var columnType = tag.Type() == typeof(bool) ? ColumnType.CheckBox : ColumnType.Text;
                Assert.AreEqual(expected: true, actual: tag.CanRead());
                Assert.AreEqual(expected: canSort, actual: tag.CanSort());
                Assert.AreEqual(expected: canWrite, actual: tag.CanWrite());
                Assert.IsFalse(string.IsNullOrWhiteSpace(tag.Category()));
                Assert.AreNotEqual(notExpected: Alignment.Default, actual: column.Alignment); // All defaults resolved?
                Assert.AreEqual(expected: columnType, actual: column.Type);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tag.Details()));
                Assert.IsFalse(string.IsNullOrWhiteSpace(tag.DisplayName()));
                Assert.AreNotEqual(notExpected: canWrite, actual: tag.ReadOnly());
                Assert.AreEqual(expected: property.PropertyType, actual: tag.Type());
            }
        }
    }
}
