namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Terms;

    [TestClass]
    public class FunctionResultTests : BaseTests
    {
        [TestMethod]
        public void TestFunctionResults()
        {
            foreach (var fn in Functors.Keys)
            {
                var function = new Function(fn);
                var isInfinitary = fn.IsInfinitary();
                var typesCount = fn.OperandCount();
                var operandsCount = typesCount + (isInfinitary ? 2 : 0);
                Assert.IsNotNull(function);
                Assert.AreEqual(expected: fn, actual: function.Fn);
                Assert.AreEqual(expected: typesCount, actual: function.OperandTypes.Count());
                Assert.AreEqual(expected: Rank.Unary, actual: function.Rank);
                AddTestValues(function);
                Assert.AreEqual(expected: operandsCount, actual: function.Operands.Count);
                TestParse(function);
            }
        }

        #region Compare

        [DataRow("Compare(\"Abc\", \"Def\")", -1, -1)]
        [DataRow("Compare(\"Def\", \"Abc\")", +1, +1)]
        [DataRow("Compare(\"Abc\", \"ABC\")", -1, 0)]

        [DataRow("Compare(\"Abc\", \"ABC\", true)", -1)]
        [DataRow("Compare(\"Abc\", \"ABC\", false)", 0)]

        [DataRow("\"Abc\" compare \"Def\"", -1, -1)]
        [DataRow("\"Def\" compare \"Abc\"", +1, +1)]
        [DataRow("\"Abc\" compare \"ABC\"", -1, 0)]

        [DataRow("\"Abc\" compare(\"ABC\", true)", -1)]
        [DataRow("\"Abc\" compare(\"ABC\", false)", 0)]

        #endregion
        #region Concat

        [DataRow("Concat(2, 4, 6, 8, \" It's never too late.\")", "2468 It's never too late.")]
        [DataRow("Concat_2(\"A\", \"B\")", "AB")]
        [DataRow("Concat_3(\"A\", \"B\", \"C\")", "ABC")]
        [DataRow("Concat_4(\"A\", \"B\", \"C\", \"D\")", "ABCD")]

        #endregion
        #region Contains

        [DataRow("Contains(\"Gloves\", \"love\")", true, true)]
        [DataRow("Contains(\"Gloves\", \"Love\")", false, true)]

        [DataRow("Contains(\"Gloves\", \"Love\", true)", false)]
        [DataRow("Contains(\"Gloves\", \"Love\", false)", true)]

        [DataRow("\"Gloves\" contains \"love\"", true, true)]
        [DataRow("\"Gloves\" contains \"Love\"", false, true)]

        [DataRow("\"Gloves\" contains(\"Love\", true)", false)]
        [DataRow("\"Gloves\" contains(\"Love\", false)", true)]

        #endregion
        #region ContainsX

        [DataRow("ContainsX(\"Gloves\", \"l.v[aeiou]\")", true, true)]
        [DataRow("ContainsX(\"Gloves\", \"L.v[aeiou]\")", false, true)]
        [DataRow("ContainsX(\"Gloves\", \"l.v[AEIOU]\")", false, true)]
        [DataRow("ContainsX(\"Gloves\", \"l.v[D-F]\")", false, true)]
        [DataRow("ContainsX(\"Gloves\", \"l.v[D-f]\")", true, true)]
        [DataRow("ContainsX(\"Gloves\", \"l.v[d-f]\")", true, true)]

        [DataRow("ContainsX(\"Gloves\", \"l.v[D-F]\", true)", false)]
        [DataRow("ContainsX(\"Gloves\", \"l.v[D-F]\", false)", true)]

        [DataRow("\"Gloves\" containsx \"l.v[aeiou]\"", true, true)]
        [DataRow("\"Gloves\" containsx \"L.v[aeiou]\"", false, true)]
        [DataRow("\"Gloves\" containsx \"l.v[AEIOU]\"", false, true)]
        [DataRow("\"Gloves\" containsx \"l.v[D-F]\"", false, true)]
        [DataRow("\"Gloves\" containsx \"l.v[D-f]\"", true, true)]
        [DataRow("\"Gloves\" containsx \"l.v[d-f]\"", true, true)]

        [DataRow("\"Gloves\" containsx(\"l.v[D-F]\", true)", false)]
        [DataRow("\"Gloves\" containsx(\"l.v[D-F]\", false)", true)]

        #endregion
        #region Count

        [DataRow("Count(\"C:\\Media\\Music\\Song.mp3\", \"\\\")", 3)]
        [DataRow("Count(\"C:\\Media\\Music\\Song.mp3\", \"s\")", 1, 2)]
        [DataRow("\"C:\\Media\\Music\\Song.mp3\" count \"\\\"", 3)]
        [DataRow("\"C:\\Media\\Music\\Song.mp3\" count \"s\"", 1, 2)]

        [DataRow("Count(\"C:\\Media\\Music\\Song.mp3\", \"s\", true)", 1)]
        [DataRow("Count(\"C:\\Media\\Music\\Song.mp3\", \"s\", false)", 2)]

        #endregion
        #region CountX

        [DataRow("CountX(\"C:\\Media\\Music\\Song.mp3\", \"m..i.\")", 0, 2)]
        [DataRow("\"C:\\Media\\Music\\Song.mp3\" countx \"m..i.\"", 0, 2)]

        [DataRow("CountX(\"C:\\Media\\Music\\Song.mp3\", \"m..i.\", true)", 0)]
        [DataRow("CountX(\"C:\\Media\\Music\\Song.mp3\", \"m..i.\", false)", 2)]
        [DataRow("\"C:\\Media\\Music\\Song.mp3\" countx(\"m..i.\", true)", 0)]
        [DataRow("\"C:\\Media\\Music\\Song.mp3\" countx(\"m..i.\", false)", 2)]

        #endregion
        #region Empty

        [DataRow("Empty(\"Abc\")", false)]
        [DataRow("Empty(\"   \")", true)]
        [DataRow("\"Abc\" Empty()", false)]
        [DataRow("\"Abc\" empty", false)]
        [DataRow("\"   \" Empty()", true)]
        [DataRow("\"   \" empty", true)]

        #endregion
        #region EndsWith

        [DataRow("EndsWith(\"Gloves\", \"ves\")", true, true)]
        [DataRow("EndsWith(\"Gloves\", \"VES\")", false, true)]

        [DataRow("EndsWith(\"Gloves\", \"VES\", true)", false)]
        [DataRow("EndsWith(\"Gloves\", \"VES\", false)", true)]

        [DataRow("\"Gloves\" endswith \"ves\"", true, true)]
        [DataRow("\"Gloves\" endswith \"VES\"", false, true)]

        [DataRow("\"Gloves\" endswith(\"VES\", true)", false)]
        [DataRow("\"Gloves\" endswith(\"VES\", false)", true)]

        #endregion
        #region EndsWithX

        [DataRow("EndsWithX(\"Gloves\", \"v[aeiou]s\")", true, true)]
        [DataRow("EndsWithX(\"Gloves\", \"V[AEIOU]s\")", false, true)]
        [DataRow("EndsWithX(\"Gloves\", \"v[aeiou]\")", false, false)]
        [DataRow("EndsWithX(\"Gloves\", \"V[AEIOU]\")", false, false)]

        [DataRow("\"Gloves\" endswithx \"v[aeiou]s\"", true, true)]
        [DataRow("\"Gloves\" endswithx \"V[AEIOU]s\"", false, true)]
        [DataRow("\"Gloves\" endswithx \"v[aeiou]\"", false, false)]
        [DataRow("\"Gloves\" endswithx \"V[AEIOU]\"", false, false)]

        #endregion
        #region Equals

        [DataRow("Equals(\"Abc\", \"Def\")", false)]
        [DataRow("Equals(\"Abc\", \"Abc\")", true)]
        [DataRow("Equals(\"Abc\", \"ABC\")", false, true)]
        [DataRow("\"Abc\" equals \"Def\"", false)]
        [DataRow("\"Abc\" equals \"Abc\"", true)]
        [DataRow("\"Abc\" equals \"ABC\"", false, true)]

        #endregion
        #region EqualsX

        [DataRow("EqualsX(\"Abc\", \"Def\")", false)]
        [DataRow("EqualsX(\"Abc\", \"Abc\")", true)]
        [DataRow("EqualsX(\"Abcdef\", \"ABC.*\")", false, true)]
        [DataRow("\"Abc\" equalsx \"Def\"", false)]
        [DataRow("\"Abc\" equalsx \"Abc\"", true)]
        [DataRow("\"Abc\" equalsx \"A[BC]{2}\"", false, true)]

        #endregion
        #region Format

        [DataRow("Format(\"{0} {1} {2} {3} {4}\", 2, 4, 6, 8, 10)", "2 4 6 8 10")]
        [DataRow("Format(\"{0} {1} {2} {3} {4}\", 1, 2.0, \"three\", true, [1958-11-23])", "1 2 three True 23/11/1958 00:00:00")]
        [DataRow("\"{0} {1} {2} {3} {4}\" format(2, 4, 6, 8, 10)", "2 4 6 8 10")]
        [DataRow("\"{0} {1} {2} {3} {4}\" format(1, 2.0, \"three\", true, [1958-11-23])", "1 2 three True 23/11/1958 00:00:00")]

        #endregion
        #region If

        [DataRow("If(true, 1, 2)", 1)]
        [DataRow("If(false, 1, 2)", 2)]
        [DataRow("If(1 + 1 = 2, 1, 2)", 1)]
        [DataRow("If(1 + 1 > 2, 1, 2)", 2)]
        [DataRow("If(true, \"Beatles\", \"Stones\")", "Beatles")]
        [DataRow("true if(1, 2)", 1)]
        [DataRow("false if(1, 2)", 2)]
        [DataRow("(1 + 1 = 2) if(1, 2)", 1)]
        [DataRow("(1 + 1 > 2) if(1, 2)", 2)]
        [DataRow("true if(\"Beatles\", \"Stones\")", "Beatles")]

        #endregion
        #region IndexOf

        [DataRow("IndexOf(\"One Two Three\", \" Two\")", 3, 3)]
        [DataRow("IndexOf(\"One Two Three\", \" TWO\")", -1, 3)]
        [DataRow("IndexOf(\"One Two Three\", \" Four\")", -1, -1)]
        [DataRow("\"One Two Three\" indexof \" Two\"", 3, 3)]
        [DataRow("\"One Two Three\" indexof \" TWO\"", -1, 3)]
        [DataRow("\"One Two Three\" indexof \" Four\"", -1, -1)]

        #endregion
        #region IndexOfX

        [DataRow("IndexOfX(\"One Two Three\", \" T.o\")", 3, 3)]
        [DataRow("IndexOfX(\"One Two Three\", \" T.O\")", -1, 3)]
        [DataRow("IndexOfX(\"One Two Three\", \" F.ur\")", -1, -1)]
        [DataRow("\"One Two Three\" indexofx \" T.o\"", 3, 3)]
        [DataRow("\"One Two Three\" indexofx \" T.O\"", -1, 3)]
        [DataRow("\"One Two Three\" indexofx \" F.ur\"", -1, -1)]

        #endregion
        #region Insert

        [DataRow("Insert(\"One Three\", 3, \" Two\")", "One Two Three")]
        [DataRow("\"One Three\" insert(3, \" Two\")", "One Two Three")]

        #endregion
        #region Join

        [DataRow("Join(\"; \", 2, 4, 6, 8, 10)", "2; 4; 6; 8; 10")]
        [DataRow("Join(\"; \", 1, 2.0, \"three\", true, [1958-11-23])", "1; 2; three; True; 23/11/1958 00:00:00")]
        [DataRow("\"; \" join(2, 4, 6, 8, 10)", "2; 4; 6; 8; 10")]
        [DataRow("\"; \" join(1, 2.0, \"three\", true, [1958-11-23])", "1; 2; three; True; 23/11/1958 00:00:00")]

        #endregion
        #region LastIndexOf

        [DataRow("LastIndexOf(\"One Two Three Two \", \" Two\")", 13, 13)]
        [DataRow("LastIndexOf(\"One Two Three Two \", \" TWO\")", -1, 13)]
        [DataRow("LastIndexOf(\"One Two Three Two \", \" Four\")", -1, -1)]
        [DataRow("\"One Two Three Two \" lastindexof \" Two\"", 13, 13)]
        [DataRow("\"One Two Three Two \" lastindexof \" TWO\"", -1, 13)]
        [DataRow("\"One Two Three Two \" lastindexof \" Four\"", -1, -1)]

        #endregion
        #region LastIndexOfX

        [DataRow("LastIndexOfX(\"One Two Three Two \", \" T.o\")", 13, 13)]
        [DataRow("LastIndexOfX(\"One Two Three Two \", \" T.O\")", -1, 13)]
        [DataRow("LastIndexOfX(\"One Two Three Two \", \" F.ur\")", -1, -1)]
        [DataRow("\"One Two Three Two \" lastindexofx \" T.o\"", 13, 13)]
        [DataRow("\"One Two Three Two \" lastindexofx \" T.O\"", -1, 13)]
        [DataRow("\"One Two Three Two \" lastindexofx \" F.ur\"", -1, -1)]

        #endregion
        #region Length

        [DataRow("Length(\"Abc\")", 3)]
        [DataRow("Length \"Abc\"", 3)]
        [DataRow("\"Abc\" Length()", 3)]
        [DataRow("\"Abc\" length", 3)]

        #endregion
        #region Lower

        [DataRow("Lower(\"Abc\")", "abc")]
        [DataRow("\"Abc\" Lower()", "abc")]
        [DataRow("\"Abc\" lower", "abc")]

        #endregion
        #region Max

        [DataRow("Max(1, 2)", 2D)]
        [DataRow("1 max 2", 2D)]
        [DataRow("1 max 2 max 3", 3D)]

        #endregion
        #region Min

        [DataRow("Min(1, 2)", 1D)]
        [DataRow("1 min 2", 1D)]
        [DataRow("1 min 2 min 3", 1D)]

        #endregion
        #region Pow

        [DataRow("Pow(2, 8)", 256D)]
        [DataRow("2 pow 8", 256D)]
        [DataRow("2 pow -8", 1D / 256)]
        [DataRow("2 pow 16", 65536D)]

        #endregion
        #region Remove

        [DataRow("Remove(\"One Two Three\", 3, 4)", "One Three")]
        [DataRow("\"One Two Three\" remove(3, 4)", "One Three")]

        #endregion
        #region Replace

        [DataRow("Replace(\"Call me Ishmael\", \"ishmael\", \"a cab\")", "Call me Ishmael", "Call me a cab")]
        [DataRow("Replace(\"Run and run\", \"Run\", \"Stop\")", "Stop and run", "Stop and Stop")]

        [DataRow("\"Call me Ishmael\" replace(\"ishmael\", \"a cab\")", "Call me Ishmael", "Call me a cab")]
        [DataRow("\"Run and run\" replace(\"Run\", \"Stop\")", "Stop and run", "Stop and Stop")]

        [DataRow("Replace(\"Call me Ishmael\", \"ishmael\", \"a cab\", true)", "Call me Ishmael")]
        [DataRow("Replace(\"Call me Ishmael\", \"ishmael\", \"a cab\", false)", "Call me a cab")]

        #endregion
        #region ReplaceX

        [DataRow("ReplaceX(\"Call me Ishmael\", \"ishm[aeiou]{2}l\", \"a cab\")", "Call me Ishmael", "Call me a cab")]
        [DataRow("ReplaceX(\"Run and run\", \"R.n\", \"Stop\")", "Stop and run", "Stop and Stop")]

        [DataRow("\"Call me Ishmael\" replacex(\"ishm[aeiou]{2}l\", \"a cab\")", "Call me Ishmael", "Call me a cab")]
        [DataRow("\"Run and run\" replacex(\"R.n\", \"Stop\")", "Stop and run", "Stop and Stop")]

        [DataRow("\"Run and run\" replacex(\"R.n\", \"Stop\", true)", "Stop and run")]
        [DataRow("\"Run and run\" replacex(\"R.n\", \"Stop\", false)", "Stop and Stop")]

        #endregion
        #region Round

        [DataRow("Round(3.14159)", 3D)]
        [DataRow("3.14159 round()", 3D)]
        [DataRow("2.71828 round", 3D)]

        #endregion
        #region Sign

        [DataRow("Sign(123)", +1)]
        [DataRow("Sign(0)", 0)]
        [DataRow("Sign(-123)", -1)]
        [DataRow("123 sign()", +1)]
        [DataRow("0 sign()", 0)]
        [DataRow("-123 sign()", -1)]
        [DataRow("123 sign", +1)]
        [DataRow("0 sign", 0)]
        [DataRow("-123 sign", -1)]

        #endregion
        #region StartsWith

        [DataRow("StartsWith(\"Gloves\", \"Glo\")", true, true)]
        [DataRow("StartsWith(\"Gloves\", \"GLO\")", false, true)]
        [DataRow("\"Gloves\" startswith \"Glo\"", true, true)]
        [DataRow("\"Gloves\" startswith \"GLO\"", false, true)]

        #endregion
        #region StartsWithX

        [DataRow("StartsWithX(\"Gloves\", \"Gl[aeiou]\")", true, true)]
        [DataRow("StartsWithX(\"Gloves\", \"Gl[AEIOU]\")", false, true)]
        [DataRow("StartsWithX(\"Gloves\", \"l[aeiou]\")", false, false)]
        [DataRow("StartsWithX(\"Gloves\", \"L[AEIOU]\")", false, false)]
        [DataRow("\"Gloves\" startswithx \"Gl[aeiou]\"", true, true)]
        [DataRow("\"Gloves\" startswithx \"Gl[AEIOU]\"", false, true)]
        [DataRow("\"Gloves\" startswithx \"l[aeiou]\"", false, false)]
        [DataRow("\"Gloves\" startswithx \"L[AEIOU]\"", false, false)]

        #endregion
        #region Substring

        [DataRow("Substring(\"One Two Three\", 3, 4)", " Two")]
        [DataRow("\"One Two Three\" substring(3, 4)", " Two")]

        #endregion
        #region ToString

        [DataRow("ToString(true)", "True")]
        [DataRow("ToString(123)", "123")]
        [DataRow("ToString(9876543210L)", "9876543210")]

        #endregion
        #region Trim

        [DataRow("Trim(\"   Abc   \")", "Abc")]
        [DataRow("\"   Abc   \" trim()", "Abc")]
        [DataRow("\"   Abc   \" trim", "Abc")]

        #endregion
        #region Truncate

        [DataRow("Truncate(3.14159)", 3D)]
        [DataRow("3.14159 truncate()", 3D)]
        [DataRow("2.71828 truncate", 2D)]

        #endregion
        #region Upper

        [DataRow("Upper(\"Abc\")", "ABC")]
        [DataRow("\"Abc\" Upper()", "ABC")]
        [DataRow("\"Abc\" upper", "ABC")]

        #endregion

        [TestMethod]
        public void TestFunctionResult(string text, object sense, object nonsense = null) =>
            TestResult(text, sense, nonsense ?? sense);

        [DataRow("\"Abc\" compare \"ABC\"", -1, 0)]
        [TestMethod]
        public void ScratchTestFunctionResult(string text, object sense, object nonsense = null) =>
            TestResult(text, sense, nonsense ?? sense);
    }
}
