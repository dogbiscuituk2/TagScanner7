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
        public void TestAllFields() => TestStrings(Tags.FieldNames, TokenKind.Field);

        [TestMethod]
        public void TestAllFunctions() => TestStrings(Functors.FunctionNames, TokenKind.Function);

        [TestMethod]
        public void TestAllSymbols() => TestStrings(Operators.Symbols, TokenKind.Symbol);

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

        [DataRow(" /* This is a failed comment ", TokenKind.Comment, "/*", "Unterminated comment")]
        [DataRow(" /*This is a failed comment ", TokenKind.Comment, "/*This", "Unterminated comment")]
        [DataRow(" /*This is a failed comment * / ", TokenKind.Comment, "/*This", "Unterminated comment")]
        [TestMethod]
        public void TestSingleTokenFail(string text, TokenKind tokenType, string value, string error)
        {
            var tokens = Tokenizer.GetTokens(text);
            Assert.IsTrue(tokens.Count() > 0);
            var token = tokens.First();
            Assert.AreEqual(expected: tokenType, actual: token.Kind);
            Assert.AreEqual(expected: 1, actual: token.Start);
            Assert.AreEqual(expected: value, actual: token.Value);
            Assert.AreEqual(expected: error, actual: token.Error);
        }

        #region Boolean

        [DataRow(" true ", TokenKind.Boolean, "true")]
        [DataRow(" True ", TokenKind.Boolean, "true")]
        [DataRow(" TRUE ", TokenKind.Boolean, "true")]

        #endregion
        #region Character

        [DataRow(" 'A' ", TokenKind.Character, "'A'")]
        [DataRow(" '.' ", TokenKind.Character, "'.'")] // Period
        [DataRow(" '\'' ", TokenKind.Character, "'\''")] // Apostrophe
        [DataRow(" '\t' ", TokenKind.Character, "'\t'")] // Tab
        [DataRow(" '\r' ", TokenKind.Character, "'\r'")] // CR
        [DataRow(" '\n' ", TokenKind.Character, "'\n'")] // LF

        #endregion
        #region Comment

        [DataRow(" // This is a comment ", TokenKind.Comment, "// This is a comment ")]
        [DataRow(" /* This is a comment */ ", TokenKind.Comment, "/* This is a comment */")]
        [DataRow(" /* This is a\r\nmulti-line comment */ ", TokenKind.Comment, "/* This is a\r\nmulti-line comment */")]

        #endregion
        #region DateTime

        [DataRow(" [1975-11-22] ", TokenKind.DateTime, "[1975-11-22]")]
        [DataRow(" [1975-11-22 12:34] ", TokenKind.DateTime, "[1975-11-22 12:34]")]
        [DataRow(" [1975-11-22 12:34:56] ", TokenKind.DateTime, "[1975-11-22 12:34:56]")]
        [DataRow(" [1975-11-22 12:34:56.789] ", TokenKind.DateTime, "[1975-11-22 12:34:56.789]")]
        [DataRow(" [1975-1-2] ", TokenKind.DateTime, "[1975-1-2]")]
        [DataRow(" [1975-1-2 2:3] ", TokenKind.DateTime, "[1975-1-2 2:3]")]
        [DataRow(" [1975-1-2 2:3:4] ", TokenKind.DateTime, "[1975-1-2 2:3:4]")]
        [DataRow(" [1975-1-2 2:3:4.5] ", TokenKind.DateTime, "[1975-1-2 2:3:4.5]")]

        #endregion
        #region Field

        [DataRow(" Artist ", TokenKind.Field, "Artist")]
        [DataRow(" title ", TokenKind.Field, "Title")]
        [DataRow(" ALBUM ", TokenKind.Field, "Album")]
        [DataRow(" Album Artist ", TokenKind.Field, "Album Artist")]

        #endregion
        #region Number

        [DataRow(" 1 ", TokenKind.Number, "1")]
        [DataRow(" 1.23 ", TokenKind.Number, "1.23")]
        [DataRow(" 1.23f ", TokenKind.Number, "1.23f")]
        [DataRow(" 1.23D ", TokenKind.Number, "1.23D")]
        [DataRow(" 1.23M ", TokenKind.Number, "1.23M")]
        [DataRow(" 1.23u ", TokenKind.Number, "1.23u")]
        [DataRow(" 1.23L ", TokenKind.Number, "1.23L")]
        [DataRow(" 1.23uL ", TokenKind.Number, "1.23uL")]
        [DataRow(" 1.23e+4 ", TokenKind.Number, "1.23e+4")]
        [DataRow(" 1.23E-5 ", TokenKind.Number, "1.23E-5")]
        [DataRow(" 1.23e+4F ", TokenKind.Number, "1.23e+4F")]
        [DataRow(" 1.23E-5d ", TokenKind.Number, "1.23E-5d")]

        #endregion
        #region Parameter

        [DataRow(" {int} ", TokenKind.Default, "{int}")]

        #endregion
        #region String

        [DataRow(" \"Abc Def\"", TokenKind.String, "\"Abc Def\"")]
        [DataRow(" \"Abc\r\nDef\"", TokenKind.String, "\"Abc\r\nDef\"")]

        #endregion
        #region TimeSpan

        [DataRow(" [12:34] ", TokenKind.TimeSpan, "[12:34]")]
        [DataRow(" [12:34:56] ", TokenKind.TimeSpan, "[12:34:56]")]
        [DataRow(" [12:34:56.789] ", TokenKind.TimeSpan, "[12:34:56.789]")]
        [DataRow(" [2:3] ", TokenKind.TimeSpan, "[2:3]")]
        [DataRow(" [2:3:4] ", TokenKind.TimeSpan, "[2:3:4]")]
        [DataRow(" [2:3:4.5] ", TokenKind.TimeSpan, "[2:3:4.5]")]

        #endregion
        [TestMethod]
        public void TestSingleTokenPass(string text, TokenKind tokenType, string value)
        {
            var tokens = Tokenizer.GetTokens(text);
            Assert.AreEqual(expected: 1, actual: tokens.Count());
            var token = tokens.First();
            Assert.AreEqual(expected: null, actual: token.Error);
            Assert.AreEqual(expected: 1, actual: token.Start);
            Assert.AreEqual(expected: tokenType, actual: token.Kind);
            Assert.AreEqual(expected: true, actual: token.Valid);
            Assert.AreEqual(expected: value, actual: token.Value);
        }

        #endregion

        #region Private Methods

        private void TestStrings(IEnumerable<string> strings, TokenKind tokenType)
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
                Assert.AreEqual(expected: 1, actual: token.Start);
                Assert.AreEqual(expected: tokenType, actual: token.Kind);
                Assert.AreEqual(expected: true, actual: token.Valid);
                Assert.AreEqual(expected: s, actual: token.Value);
            }
        }

        #endregion
    }
}
