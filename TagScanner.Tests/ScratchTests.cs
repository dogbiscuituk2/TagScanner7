namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TagScanner.Utils;
    using Terms;

    [TestClass]
    public class ScratchTests : BaseTests
    {
        [TestMethod]
        public void ScratchTest()
        {
            var sample = "oneTwo";
            var output = "ThreeFour";
            var result = sample.PreserveCase(output);
            return;
        }
    }
}
