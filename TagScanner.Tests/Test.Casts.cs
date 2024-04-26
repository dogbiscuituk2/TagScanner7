namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestCasts()
        {
            foreach (var type in Types.TypeValues)
            {
                var cast = new Cast(type);

                Assert.IsNotNull(cast);
                Assert.AreEqual(expected: 1, actual: cast.Arity);
                Assert.AreEqual(expected: type, actual: cast.NewType);
                Assert.AreEqual(expected: false, actual: cast.ParamArray);
                Assert.IsTrue(cast.ParameterTypes.SequenceEqual(new[] { typeof(object) }));
                Assert.AreEqual(expected: Rank.Unary, actual: cast.Rank);
                Assert.AreEqual(expected: type, actual: cast.ResultType);

                AddTestValues(cast);

                var operands = cast.Operands;
                var operandsCount = operands.Count;
                Assert.AreEqual(expected: 1, actual: operandsCount);

                var expectedRangeCount = 2 * operandsCount + 1;
                List<CharacterRange>
                    ranges = cast.CharacterRanges,
                    rangesAll = cast.CharacterRangesAll;
                Assert.AreEqual(expected: expectedRangeCount, actual: ranges.Count);
                Assert.AreEqual(expected: expectedRangeCount, actual: rangesAll.Count);

                var lens = new[] { type.Say().Length + 2, operands[0].ToString().Length, 0 };
                var expectedRanges = new[] {
                    new CharacterRange(0, lens[0]),
                    new CharacterRange(lens[0], lens[1]),
                    new CharacterRange(lens[0] + lens[1], 0) };
                Assert.IsTrue(ranges.SequenceEqual(expectedRanges));
                Assert.IsTrue(rangesAll.SequenceEqual(expectedRanges));

                var result = cast.Result;

                TestParse(cast);

                //var foo = cast.
            }
        }
    }
}
