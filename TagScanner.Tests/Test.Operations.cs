namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using TagScanner.Models;
    using TagScanner.Terms;

    public partial class Test
    {
        [TestMethod]
        public void Operations_Relational()
        {
            var year = new Field("Year");
            Term
                _1960s = new Operation(year, ">=", 1960) & new Operation(year, '<', 1970),
                _1970s =  new Operation(year, ">=", 1970) & new Operation(year, '<', 1980),
                others = !_1960s & !_1970s;
            IEnumerable<Work>
                _60s = Works.Where(p => _1960s.Predicate(p)),
                _70s = Works.Where(p => _1970s.Predicate(p)),
                all = Works.Where(p => (_1960s | _1970s | others).Predicate(p));
            Assert.AreEqual(expected: "T.Year >= 1960 && T.Year < 1970", actual: _1960s.ToCode());
            Assert.AreEqual(expected: "Year ≥ 1960 and Year < 1970", actual: _1960s.ToFriendlyText());
            Assert.AreEqual(expected: "((T.Year >= 1960) AndAlso (T.Year < 1970))", actual: _1960s.Expression.ToString());
            Assert.AreEqual(expected: 13, actual: _60s.Count());
            Assert.AreEqual(expected: "T.Year >= 1970 && T.Year < 1980", actual: _1970s.ToCode());
            Assert.AreEqual(expected: "Year ≥ 1970 and Year < 1980", actual: _1970s.ToFriendlyText());
            Assert.AreEqual(expected: "((T.Year >= 1970) AndAlso (T.Year < 1980))", actual: _1970s.Expression.ToString());
            Assert.AreEqual(expected: 22, actual: _70s.Count());
            Assert.AreEqual(expected: "!(T.Year >= 1960 && T.Year < 1970) && !(T.Year >= 1970 && T.Year < 1980)", actual: others.ToCode());
            Assert.AreEqual(expected: "not (Year ≥ 1960 and Year < 1970) and not (Year ≥ 1970 and Year < 1980)", actual: others.ToFriendlyText());
            Assert.AreEqual(expected: "(Not(((T.Year >= 1960) AndAlso (T.Year < 1970))) AndAlso Not(((T.Year >= 1970) AndAlso (T.Year < 1980))))", actual: others.Expression.ToString());
            Assert.AreEqual(expected: 47, actual: all.Count());
        }
    }
}
