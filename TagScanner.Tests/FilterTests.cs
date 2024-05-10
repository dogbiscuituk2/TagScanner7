namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Terms;

    [TestClass]
    public class FilterTests : BaseTests
    {
        #region Compare

        [DataRow("Compare(Year.ToString(), \"1970\") < 0", 31, 31)]
        [DataRow("Compare(Year.ToString, \"1970\") = 0", 0, 0)]
        [DataRow("Compare(year tostring, \"1970\") > 0", 0, 0)]

        #endregion
        #region Contains

        [DataRow("Artist.Contains(\"the\")", 0, 47)]
        [DataRow("artist contains \"The\"", 47, 47)]
        [DataRow("Title.Contains(\"love\")", 0, 2)]
        [DataRow("title contains \"Love\"", 2, 2)]
        [DataRow("title contains album", 3, 3)] // Sgt Pepper, Let It Be.
        [DataRow("title contains(album substring(4, 13))", 3, 3)] // Sgt Pepper, Let It Be, Rolling Stone.

        #endregion
        #region ContainsX

        [DataRow("Artist.ContainsX(\"^the.*es$\")", 0, 47)]
        [DataRow("Artist.ContainsX(\"^he.*es$\")", 0, 0)]
        [DataRow("Artist.ContainsX(\"^the.*e$\")", 0, 0)]
        [DataRow("Title.ContainsX(\"a[aeiou]n\")", 4, 4)]
        [DataRow("title containsx \"ing\"", 16, 16)]
        [DataRow("title containsx \"ING$\"", 0, 3)]

        #endregion

        [TestMethod]
        public void TestFilters(string text, int sense, int nonsense)
        {
            TestCases(text, term => Test.Tracks.Where(track => term.TrackPredicate(track)).Count(), sense, nonsense);
            TestCases(text, term => term.Filter(Test.Tracks).Count(), sense, nonsense);
        }

        [TestMethod]
        public void ScratchTest()
        {
            string text;
            var parser = new Parser();
            Term term;

            text = "Compare(Year.ToString, \"1970\")";
            term = parser.Parse(text, caseSensitive: false);

            Assert.IsNotNull(term);

            return;
        }
    }
}
