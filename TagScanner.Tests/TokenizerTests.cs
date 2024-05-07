namespace TagScanner.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using Terms;

    [TestClass]
    public class TokenizerTests
    {
        #region Public Methods

        [TestMethod]
        public void TestAllFields() => TestStrings(Tags.FieldNames, TokenType.Field);

        [TestMethod]
        public void TestAllFunctions() => TestStrings(Functors.FunctionNames, TokenType.Function);

        [TestMethod]
        public void TestAllSymbols() => TestStrings(Operators.Symbols, TokenType.Symbol);

        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(" \t \r \n ")]
        [TestMethod]
        public void TestNullOrWhiteSpace(string text)
        {
            var tokens = Tokenizer.GetTokens(text);
            Assert.AreEqual(expected: 0, actual: tokens.Count());
        }

        [DataRow(" /* This is a failed comment ", TokenType.Comment, 1, "/*", "Unterminated comment")]
        [DataRow(" /*This is a failed comment ", TokenType.Comment, 1, "/*This", "Unterminated comment")]
        [DataRow(" /*This is a failed comment * / ", TokenType.Comment, 1, "/*This", "Unterminated comment")]
        [TestMethod]
        public void TestSingleTokenFail(string text, TokenType tokenType, int index, string value, string error)
        {
            var tokens = Tokenizer.GetTokens(text);
            Assert.IsTrue(tokens.Count() > 0);
            var token = tokens.First();
            Assert.AreEqual(expected: tokenType, actual: token.TokenType);
            Assert.AreEqual(expected: index, actual: token.Index);
            Assert.AreEqual(expected: value, actual: token.Value);
            Assert.AreEqual(expected: error, actual: token.Error);
        }

        #region Comment

        [DataRow(" // This is a comment ", TokenType.Comment, 1, "// This is a comment ")]
        [DataRow(" /* This is a comment */ ", TokenType.Comment, 1, "/* This is a comment */")]
        [DataRow(" /* This is a\r\nmulti-line comment */ ", TokenType.Comment, 1, "/* This is a\r\nmulti-line comment */")]

        #endregion
        #region Number

        [DataRow(" 1 ", TokenType.Number, 1, "1")]
        [DataRow(" 1.23 ", TokenType.Number, 1, "1.23")]
        [DataRow(" 1.23f ", TokenType.Number, 1, "1.23f")]
        [DataRow(" 1.23D ", TokenType.Number, 1, "1.23D")]
        [DataRow(" 1.23M ", TokenType.Number, 1, "1.23M")]
        [DataRow(" 1.23u ", TokenType.Number, 1, "1.23u")]
        [DataRow(" 1.23L ", TokenType.Number, 1, "1.23L")]
        [DataRow(" 1.23uL ", TokenType.Number, 1, "1.23uL")]
        [DataRow(" 1.23e+4 ", TokenType.Number, 1, "1.23e+4")]
        [DataRow(" 1.23E-5 ", TokenType.Number, 1, "1.23E-5")]
        [DataRow(" 1.23e+4F ", TokenType.Number, 1, "1.23e+4F")]
        [DataRow(" 1.23E-5d ", TokenType.Number, 1, "1.23E-5d")]

        #endregion
        #region Boolean

        [DataRow(" true ", TokenType.Boolean, 1, "true")]
        [DataRow(" True ", TokenType.Boolean, 1, "true")]
        [DataRow(" TRUE ", TokenType.Boolean, 1, "true")]

        #endregion
        #region Field

        [DataRow(" Artist ", TokenType.Field, 1, "Artist")]
        [DataRow(" title ", TokenType.Field, 1, "Title")]
        [DataRow(" ALBUM ", TokenType.Field, 1, "Album")]
        [DataRow(" Album Artist ", TokenType.Field, 1, "Album Artist")]

        #endregion
        [TestMethod]
        public void TestSingleTokenPass(string text, TokenType tokenType, int index, string value)
        {
            var tokens = Tokenizer.GetTokens(text);
            Assert.AreEqual(expected: 1, actual: tokens.Count());
            var token = tokens.First();
            Assert.AreEqual(expected: null, actual: token.Error);
            Assert.AreEqual(expected: index, actual: token.Index);
            Assert.AreEqual(expected: tokenType, actual: token.TokenType);
            Assert.AreEqual(expected: true, actual: token.Valid);
            Assert.AreEqual(expected: value, actual: token.Value);
        }

        #endregion

        #region Private Methods

        private void TestStrings(IEnumerable<string> strings, TokenType tokenType)
        {
            foreach (var s in strings)
            {
                TestString(s, s);
                TestString(s, s.ToLowerInvariant());
                TestString(s, s.ToUpperInvariant());
            }

            void TestString(string s, string t)
            {
                var tokens = Tokenizer.GetTokens($" {t} ");
                Assert.AreEqual(expected: 1, actual: tokens.Count());
                var token = tokens.First();
                Assert.AreEqual(expected: null, actual: token.Error);
                Assert.AreEqual(expected: 1, actual: token.Index);
                Assert.AreEqual(expected: tokenType, actual: token.TokenType);
                Assert.AreEqual(expected: true, actual: token.Valid);
                Assert.AreEqual(expected: s, actual: token.Value);
            }
        }

        #endregion
    }
}
/*
Implemented Tested
			vv	vv
			
Comment		OK	OK
Number		OK	OK

Boolean		OK	OK
Field		OK	OK
Function	OK	OK
Symbol		OK	OK
TypeName	OK	OK

Character	OK
String		OK
DateTime	OK
TimeSpan	OK
Parameter	OK
Variable	OK
*/