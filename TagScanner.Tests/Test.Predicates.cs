namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TagScanner.Terms;

    public partial class Test
    {
        #region Constants

        [TestMethod]
        public void AlwaysFalse()
        {
            var term = Constant.False;
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected: 0, works.Count());
        }

        [TestMethod]
        public void AlwaysTrue()
        {
            var term = Constant.True;
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected: Works.Length, actual: works.Count());
        }

        #endregion

        #region Operations

        [TestMethod]
        [DataRow("19th", 0)]
        [DataRow("20th", 35)]
        [DataRow("21st", 12)]
        [DataRow("22nd", 0)]
        public void Century(string century, int expected)
        {
            var term = new Operation(new Field("Century"), Operator.EqualTo, new Constant(century));
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected, actual: works.Count());
        }

        [TestMethod]
        [DataRow("1950s", 0)]
        [DataRow("1960s", 13)]
        [DataRow("1970s", 22)]
        [DataRow("1980s", 0)]
        [DataRow("1990s", 0)]
        [DataRow("2000s", 0)]
        [DataRow("2010s", 0)]
        [DataRow("2020s", 12)]
        public void Decade(string decade, int expected)
        {
            var term = new Operation(new Field("Decade"), Operator.EqualTo, new Constant(decade));
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected, actual: works.Count());
        }

        [TestMethod]
        public void FindTitle()
        {
            var term = new Operation(new Field("Title"), Operator.EqualTo, new Constant("When I'm Sixty-Four"));
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected: 1, actual: works.Count());
            Assert.AreEqual(expected: 9, actual: works.First().TrackNumber);
        }

        [TestMethod]
        [DataRow("1st", 0)]
        [DataRow("2nd", 35)]
        [DataRow("3rd", 12)]
        [DataRow("4th", 0)]
        public void Millennium(string millennium, int expected)
        {
            var term = new Operation(new Field("Millennium"), Operator.EqualTo, new Constant(millennium));
            var works = Works.Where(p => term.Predicate(p));
            Assert.AreEqual(expected, actual: works.Count());
        }

        #endregion

        #region Math Static Functions

        #endregion

        #region Regex Static Functions

        #endregion

        #region String Member Functions

        #endregion

        #region String Static Functions

        #endregion
    }
}
