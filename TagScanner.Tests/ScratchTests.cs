namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Terms;

    [TestClass]
    public class ScratchTests : BaseTests
    {
        [DataRow("a := 1, b := 1, a + b == 2 ? \"Andy\" : \"Bill\"", "Andy")]
        [DataRow("a := 1, b := 1, a + b == 3 ? \"Andy\" : \"Bill\"", "Bill")]
        [DataRow("x := 1; x = 1 ? \"one\" : x = 2 ? \"two\" : \"three\"", "one")]
        [DataRow("x := 2; x = 1 ? \"one\" : x = 2 ? \"two\" : \"three\"", "two")]
        [DataRow("x := 3; x = 1 ? \"one\" : x = 2 ? \"two\" : \"three\"", "three")]
        [DataRow("x := 1; y := 1; x = 1 ? (y = 1 ? 11 : 12) : (y = 1 ? 21 : 22)", 11)]
        [DataRow("x := 1; y := 2; x = 1 ? (y = 1 ? 11 : 12) : (y = 1 ? 21 : 22)", 12)]
        [DataRow("x := 2; y := 1; x = 1 ? (y = 1 ? 11 : 12) : (y = 1 ? 21 : 22)", 21)]
        [DataRow("x := 2; y := 2; x = 1 ? (y = 1 ? 11 : 12) : (y = 1 ? 21 : 22)", 22)]
        [DataRow("x := 1; y := 1; x = 1 ? (y = 1 ? 11 : 12) : y = 1 ? 21 : 22", 11)]
        [DataRow("x := 1; y := 2; x = 1 ? (y = 1 ? 11 : 12) : y = 1 ? 21 : 22", 12)]
        [DataRow("x := 2; y := 1; x = 1 ? (y = 1 ? 11 : 12) : y = 1 ? 21 : 22", 21)]
        [DataRow("x := 2; y := 2; x = 1 ? (y = 1 ? 11 : 12) : y = 1 ? 21 : 22", 22)]

        [DataRow("x := 2; y := 2; x = 1 ? y = 1 ? 11 : 12 : 99", 99)]

        /*[DataRow("x := 1; y := 1; x = 1 ? y = 1 ? 11 : 12 : (y = 1 ? 21 : 22)", 11)]
        [DataRow("x := 1; y := 2; x = 1 ? y = 1 ? 11 : 12 : (y = 1 ? 21 : 22)", 12)]
        [DataRow("x := 2; y := 1; x = 1 ? y = 1 ? 11 : 12 : (y = 1 ? 21 : 22)", 21)]
        [DataRow("x := 2; y := 2; x = 1 ? y = 1 ? 11 : 12 : (y = 1 ? 21 : 22)", 22)]
        [DataRow("x := 1; y := 1; x = 1 ? y = 1 ? 11 : 12 : y = 1 ? 21 : 22", 11)]
        [DataRow("x := 1; y := 2; x = 1 ? y = 1 ? 11 : 12 : y = 1 ? 21 : 22", 12)]
        [DataRow("x := 2; y := 1; x = 1 ? y = 1 ? 11 : 12 : y = 1 ? 21 : 22", 21)]
        [DataRow("x := 2; y := 2; x = 1 ? y = 1 ? 11 : 12 : y = 1 ? 21 : 22", 22)]*/
        [TestMethod]
        public void ScratchTest(string text, object expected)
        {
            var term = Parser.Parse(text, caseSensitive: false);
            var actual = term.Result;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScratchTest2()
        {
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            var foo = true ? true ? 1 : 2 : 3;
#pragma warning restore CS0219 // Variable is assigned but its value is never used

            var text = "true ? true ? 1 : 2 : 3";
            var term = Parser.Parse(text, caseSensitive: false);
            var actual = term.Result;
        }

    }
}
