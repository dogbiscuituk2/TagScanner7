namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TagScanner.Models;
    using TagScanner.Terms;

    [TestClass]
    public class FieldTests
    {
        [ClassInitialize] public static void ClassInitialize(TestContext _) { }
        [TestInitialize] public void TestInitialize() { Core.ResetDefaults(); }
        [TestCleanup] public void TestCleanup() { }
        [ClassCleanup] public static void ClassCleanup() { }

        [TestMethod]
        public void FieldTest01()
        {
            foreach (var tag in Tags.AllTags)
            {
                var tagName = tag.Name;
                var term = new Field(tagName);
                Assert.AreEqual(expected: tagName, actual: term.TagName);
                Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
                Assert.AreEqual(expected: tagName.Type(), actual: term.ResultType);
                Assert.AreEqual(expected: $"T.{tagName}", actual: term.ToCode());
                Assert.AreEqual(expected: $"{tag.DisplayName}", actual: term.ToFriendlyText());
                Assert.AreEqual(expected: $"T.{tagName}", actual: term.Expression.ToString());
            }
        }

        [TestMethod]
        public void FieldTest02()
        {
            Core.ParamName = "Work";
            foreach (var tag in Tags.AllTags)
            {
                var tagName = tag.Name;
                var term = new Field(tagName);
                Assert.AreEqual(expected: tagName, actual: term.TagName);
                Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
                Assert.AreEqual(expected: tagName.Type(), actual: term.ResultType);
                Assert.AreEqual(expected: $"Work.{tagName}", actual: term.ToCode());
                Assert.AreEqual(expected: $"{tag.DisplayName}", actual: term.ToFriendlyText());
                Assert.AreEqual(expected: $"T.{tagName}", actual: term.Expression.ToString());
            }
        }
    }
}
