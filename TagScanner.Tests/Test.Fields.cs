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
                var term = new Field(tag);
                Assert.IsNotNull(term);
                Assert.AreEqual(expected: tag.DisplayName(), actual: term.ToString());
                Assert.AreEqual(expected: tag.Name(), actual: term.Tag.ToString());
                Assert.AreEqual(expected: Rank.Unary, actual: term.Rank);
                Assert.AreEqual(expected: tag.Type(), actual: term.ResultType);
                Assert.AreEqual(expected: $"{Term.Work.Name}.{tag.Name()}", actual: term.Expression.ToString());
            }
        }
    }
}
