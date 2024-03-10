namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TagScanner.Terms;

    [TestClass]
    public class StringTests
    {
        [ClassInitialize] public static void ClassInitialize(TestContext _) { }
        [TestInitialize] public void TestInitialize() { Core.ResetDefaults(); }
        [TestCleanup] public void TestCleanup() { }
        [ClassCleanup] public static void ClassCleanup() { }

        private static readonly Constant Beatles = new Constant("The Beatles");

        [TestMethod]
        public void TestClone()
        {
            var term = new Function("Clone()", Beatles);
            Assert.AreEqual(expected: 1, actual: term.Arity);
            Assert.AreEqual(expected: "\"The Beatles\".Clone()", actual: term.Expression.ToString());
            Assert.AreEqual(expected: Precedence.Unary, actual: term.Precedence);
            Assert.AreEqual(expected: typeof(object), actual: term.ResultType);
            Assert.AreEqual(expected: "Clone()", actual: term.Signature);
            Assert.AreEqual(expected: "\"The Beatles\".Clone()", actual: term.ToCode());
            Assert.AreEqual(expected: "\"The Beatles\".Clone()", actual: term.ToFriendlyText());
            Assert.AreEqual(expected: "\"The Beatles\".Clone()", actual: term.Expression.ToString());
        }
    }
}