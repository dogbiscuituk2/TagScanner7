namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestTermLists()
        {
            var termList = new TermList(1, '2', "3", true, false, new Conditional(true, 4, 5));
            Assert.AreEqual(expected: "1, '2', \"3\", true, false, true ? 4 : 5", actual: termList.ToString());
        }
    }
}