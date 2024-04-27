namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Terms;

    public partial class Test
    {
        [TestMethod]
        public void TestFunctions()
        {
            foreach (var fn in Functors.Keys)
            {
                var function = new Function(fn);
                var isStatic = fn.IsStatic();
                var paramArray = fn.ParamArray();
                var paramTypesCount = fn.ParamCount() + (isStatic ? 0 : 1);
                var operandsCount = paramTypesCount + (paramArray ? 2 : 0);
                Assert.IsNotNull(function);
                // Arity?
                Assert.AreEqual(expected: fn, actual: function.Fn);
                Assert.AreEqual(expected: isStatic, actual: function.IsStatic);
                Assert.AreEqual(expected: paramArray, actual: function.ParamArray);
                Assert.AreEqual(expected: paramTypesCount, actual: function.ParameterTypes.Count());
                Assert.AreEqual(expected: Rank.Unary, actual: function.Rank);
                Assert.AreEqual(expected: fn.ResultType(), actual: function.ResultType);
                AddTestValues(function);
                Assert.AreEqual(expected: operandsCount, actual: function.Operands.Count);
                TestParse(function);
                var result = function.Result;
            }
        }

        // Compare
        [DataRow("Compare(\"Abc\", \"Def\")", -1, -1)]
        [DataRow("Compare(\"Def\", \"Abc\")", +1, +1)]
        [DataRow("Compare(\"Abc\", \"ABC\")", -1, 0)]
        [DataRow("\"Abc\" compare \"Def\"", -1, -1)]
        [DataRow("\"Def\" compare \"Abc\"", +1, +1)]
        [DataRow("\"Abc\" compare \"ABC\"", -1, 0)]
        // Concat
        [DataRow("Concat_2(\"A\", \"B\")", "AB")]
        [DataRow("Concat_3(\"A\", \"B\", \"C\")", "ABC")]
        [DataRow("Concat_4(\"A\", \"B\", \"C\", \"D\")", "ABCD")]
        // Contains
        [DataRow("Contains(\"Gloves\", \"love\")", true, true)]
        [DataRow("Contains(\"Gloves\", \"Love\")", false, true)]
        [DataRow("\"Gloves\" contains \"love\"", true, true)]
        [DataRow("\"Gloves\" contains \"Love\"", false, true)]
        // ContainsX
        [DataRow("ContainsX(\"Gloves\", \"l.v[aeiou]\")", true, true)]
        [DataRow("ContainsX(\"Gloves\", \"L.v[aeiou]\")", false, true)]
        [DataRow("ContainsX(\"Gloves\", \"l.v[AEIOU]\")", false, true)]
        [DataRow("ContainsX(\"Gloves\", \"l.v[D-F]\")", false, true)]
        [DataRow("ContainsX(\"Gloves\", \"l.v[D-f]\")", true, true)]
        [DataRow("ContainsX(\"Gloves\", \"l.v[d-f]\")", true, true)]
        [DataRow("\"Gloves\" containsx \"l.v[aeiou]\"", true, true)]
        [DataRow("\"Gloves\" containsx \"L.v[aeiou]\"", false, true)]
        [DataRow("\"Gloves\" containsx \"l.v[AEIOU]\"", false, true)]
        [DataRow("\"Gloves\" containsx \"l.v[D-F]\"", false, true)]
        [DataRow("\"Gloves\" containsx \"l.v[D-f]\"", true, true)]
        [DataRow("\"Gloves\" containsx \"l.v[d-f]\"", true, true)]
        // Empty
        [DataRow("Empty(\"Abc\")", false)]
        [DataRow("Empty(\"   \")", true)]
        [DataRow("\"Abc\" Empty()", false)]
        [DataRow("\"Abc\" empty", false)]
        [DataRow("\"   \" Empty()", true)]
        [DataRow("\"   \" empty", true)]
        // EndsWith
        [DataRow("EndsWith(\"Gloves\", \"ves\")", true, true)]
        [DataRow("EndsWith(\"Gloves\", \"VES\")", false, true)]
        [DataRow("\"Gloves\" endswith \"ves\"", true, true)]
        [DataRow("\"Gloves\" endswith \"VES\"", false, true)]
        // EndsWithX
        [DataRow("EndsWithX(\"Gloves\", \"v[aeiou]s\")", true, true)]
        [DataRow("EndsWithX(\"Gloves\", \"V[AEIOU]s\")", false, true)]
        [DataRow("EndsWithX(\"Gloves\", \"v[aeiou]\")", false, false)]
        [DataRow("EndsWithX(\"Gloves\", \"V[AEIOU]\")", false, false)]
        [DataRow("\"Gloves\" endswithx \"v[aeiou]s\"", true, true)]
        [DataRow("\"Gloves\" endswithx \"V[AEIOU]s\"", false, true)]
        [DataRow("\"Gloves\" endswithx \"v[aeiou]\"", false, false)]
        [DataRow("\"Gloves\" endswithx \"V[AEIOU]\"", false, false)]
        // Equals
        [DataRow("Equals(\"Abc\", \"Def\")", false)]
        [DataRow("Equals(\"Abc\", \"Abc\")", true)]
        [DataRow("Equals(\"Abc\", \"ABC\")", false, true)]
        [DataRow("\"Abc\" equals \"Def\"", false)]
        [DataRow("\"Abc\" equals \"Abc\"", true)]
        [DataRow("\"Abc\" equals \"ABC\"", false, true)]
        // EqualsX
        [DataRow("EqualsX(\"Abc\", \"Def\")", false)]
        [DataRow("EqualsX(\"Abc\", \"Abc\")", true)]
        [DataRow("EqualsX(\"Abcdef\", \"ABC.*\")", false, true)]
        [DataRow("\"Abc\" equalsx \"Def\"", false)]
        [DataRow("\"Abc\" equalsx \"Abc\"", true)]
        [DataRow("\"Abc\" equalsx \"A[BC]{2}\"", false, true)]
        // If
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

        /*
        // Format
        [DataRow("Format(\"{0}, {1), {2}\", 1, 2, 3)", "1, 2, 3")]
        */

        // Insert
        [DataRow("Insert(\"One Three\", 3, \" Two\")", "One Two Three")]
        [DataRow("\"One Three\" insert(3, \" Two\")", "One Two Three")]
        // Length
        [DataRow("Length(\"Abc\")", 3)]
        [DataRow("Length \"Abc\"", 3)]
        [DataRow("\"Abc\" Length()", 3)]
        [DataRow("\"Abc\" length", 3)]
        // Lower
        [DataRow("Lower(\"Abc\")", "abc")]
        [DataRow("\"Abc\" Lower()", "abc")]
        [DataRow("\"Abc\" lower", "abc")]
        // Max
        [DataRow("Max(1, 2)", 2D)]
        [DataRow("1 max 2", 2D)]
        [DataRow("1 max 2 max 3", 3D)]
        // Min
        [DataRow("Min(1, 2)", 1D)]
        [DataRow("1 min 2", 1D)]
        [DataRow("1 min 2 min 3",1D)]
        // Pow
        [DataRow("Pow(2, 8)", 256D)]
        [DataRow("2 pow 8", 256D)]
        [DataRow("2 pow 16", 65536D)]
        // Remove
        [DataRow("Remove(\"One Two Three\", 3, 4)", "One Three")]
        [DataRow("\"One Two Three\" remove(3, 4)", "One Three")]
        // StartsWith
        [DataRow("StartsWith(\"Gloves\", \"Glo\")", true, true)]
        [DataRow("StartsWith(\"Gloves\", \"GLO\")", false, true)]
        [DataRow("\"Gloves\" startswith \"Glo\"", true, true)]
        [DataRow("\"Gloves\" startswith \"GLO\"", false, true)]
        // StartsWithX
        [DataRow("StartsWithX(\"Gloves\", \"Gl[aeiou]\")", true, true)]
        [DataRow("StartsWithX(\"Gloves\", \"Gl[AEIOU]\")", false, true)]
        [DataRow("StartsWithX(\"Gloves\", \"l[aeiou]\")", false, false)]
        [DataRow("StartsWithX(\"Gloves\", \"L[AEIOU]\")", false, false)]
        [DataRow("\"Gloves\" startswithx \"Gl[aeiou]\"", true, true)]
        [DataRow("\"Gloves\" startswithx \"Gl[AEIOU]\"", false, true)]
        [DataRow("\"Gloves\" startswithx \"l[aeiou]\"", false, false)]
        [DataRow("\"Gloves\" startswithx \"L[AEIOU]\"", false, false)]
        // Substring
        [DataRow("Substring(\"One Two Three\", 3, 4)", " Two")]
        [DataRow("\"One Two Three\" substring(3, 4)", " Two")]
        // ToString
        [DataRow("ToString(true)", "True")]
        [DataRow("ToString(123)", "123")]
        [DataRow("ToString(9876543210L)", "9876543210")]
        // Trim
        [DataRow("Trim(\"   Abc   \")", "Abc")]
        [DataRow("\"   Abc   \" trim()", "Abc")]
        [DataRow("\"   Abc   \" trim", "Abc")]
        // Upper
        [DataRow("Upper(\"Abc\")", "ABC")]
        [DataRow("\"Abc\" Upper()", "ABC")]
        [DataRow("\"Abc\" upper", "ABC")]

        [TestMethod]
        public void TestFunction(string text, object sense, object nonsense = null)
        {
            var term = new Parser().Parse(text, caseSensitive: true);
            Assert.AreEqual(expected: sense, actual: term.Result);
            if (nonsense == null)
                nonsense = sense;
            term = new Parser().Parse(text, caseSensitive: false);
            Assert.AreEqual(expected: nonsense, actual: term.Result);
        }

        [TestMethod]
        public void TestFunctionZ()
        {
            var text = "-3";
            var term = new Parser().Parse(text, caseSensitive: true);
            var result = term.Result;
            return;
        }
    }
}
