namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    [TestClass]
    public class BlockTests : BaseTests
    {
        [TestMethod]
        public void TestBlocks()
        {
            var block = new Block(1, 2.5, "3", true, false, new Conditional(true, 4, 5));
            Assert.AreEqual(expected: "1; 2.5D; \"3\"; true; false; If(true, 4, 5)", actual: block.ToString());
            Assert.AreEqual(expected: 4, actual: block.Result);
        }
    }
}