namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestFields()
        {
            foreach (var tag in Tags.Keys)
            {
                var tagInfo = tag.GetInfo();
                var term = new Field(tag);
                Assert.IsNotNull(term);
                Assert.AreEqual(expected: tagInfo.Name, actual: term.Tag.ToString());
                Assert.AreEqual(expected: Rank.Unary, actual: term.Rank);
                Assert.AreEqual(expected: tagInfo.Type, actual: term.ResultType);
                Assert.AreEqual(expected: $"{tagInfo.DisplayName}", actual: term.ToString());
                Assert.AreEqual(expected: $"T.{tagInfo.Name}", actual: term.Expression.ToString());
            }
        }
    }
}
