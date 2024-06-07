namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    [TestClass]
    public class ScratchTests : BaseTests
    {
        //[DataRow("a := 1, b := 1, a + b == 2 ? \"Andy\" : \"Bill\"", "Andy")]
        //[DataRow("a := 1, b := 1, a + b == 3 ? \"Andy\" : \"Bill\"", "Bill")]
        [DataRow("x := 1; (x = 1 ? \"one\" : x = 2 ? \"two\" : \"three\")", "one")]
        [TestMethod]
        public void ScratchTest(string text, object expected)
        {
            var x = 1;
            var foo= x == 1 ? "one" : x == 2 ? "two" : "three";

            var term = Parser.Parse(text, caseSensitive: false);
            var actual = term.Result;
            Assert.AreEqual(expected, actual);
        }
    }
}
