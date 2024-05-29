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
            var sample = "123 OneTwo";
            var output = "123 threeFour";
            var result = sample.PreserveCase(output);
            return;
        }
    }
}
