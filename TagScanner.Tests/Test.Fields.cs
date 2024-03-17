namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Models;
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

        [TestMethod]
        [DataRow(Tag.AlbumArtists, new[] { "John", "Paul", "George", "Ringo" })]
        public void TestFieldValues(Tag tag, object expected)
        {
            var works = Works.Where(p => !string.IsNullOrWhiteSpace(p.GetPropertyValue(tag)?.ToString()));
            Assert.AreEqual(expected: 1, actual: works.Count());
            var actual = works.First().GetPropertyValue(tag);
            if (actual.GetType().IsArray)
                Assert.IsTrue(((string[])actual).SequenceEqual((string[])expected));
            else
                Assert.AreEqual(expected, actual);
        }
    }
}
