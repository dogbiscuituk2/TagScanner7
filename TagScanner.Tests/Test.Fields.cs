namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestFields()
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
    }
}
