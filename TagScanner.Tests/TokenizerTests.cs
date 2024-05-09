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
        public void TestAllFields()
        {
            TestStrings(Tags.FieldNames, TokenType.TrackField);
            TestStrings(Tags.FieldNames.Select(p => $"${p}"), TokenType.ListField);
        }

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

        [DataRow(" /* This is a failed comment ", TokenType.Comment, "/*", "Unterminated comment")]
        [DataRow(" /*This is a failed comment ", TokenType.Comment, "/*This", "Unterminated comment")]
        [DataRow(" /*This is a failed comment * / ", TokenType.Comment, "/*This", "Unterminated comment")]
        [TestMethod]
        public void TestSingleTokenFail(string text, TokenType tokenType, string value, string error)
        {
            var tokens = Tokenizer.GetTokens(text);
            Assert.IsTrue(tokens.Count() > 0);
            var token = tokens.First();
            Assert.AreEqual(expected: tokenType, actual: token.TokenType);
            Assert.AreEqual(expected: 1, actual: token.StartIndex);
            Assert.AreEqual(expected: value, actual: token.Value);
            Assert.AreEqual(expected: error, actual: token.Error);
        }

        #region Boolean

        [DataRow(" true ", TokenType.Boolean, "true")]
        [DataRow(" True ", TokenType.Boolean, "true")]
        [DataRow(" TRUE ", TokenType.Boolean, "true")]

        #endregion
        #region Character

        [DataRow(" 'A' ", TokenType.Character, "'A'")]
        [DataRow(" '.' ", TokenType.Character, "'.'")] // Period
        [DataRow(" '\'' ", TokenType.Character, "'\''")] // Apostrophe
        [DataRow(" '\t' ", TokenType.Character, "'\t'")] // Tab
        [DataRow(" '\r' ", TokenType.Character, "'\r'")] // CR
        [DataRow(" '\n' ", TokenType.Character, "'\n'")] // LF

        #endregion
        #region Comment

        [DataRow(" // This is a comment ", TokenType.Comment, "// This is a comment ")]
        [DataRow(" /* This is a comment */ ", TokenType.Comment, "/* This is a comment */")]
        [DataRow(" /* This is a\r\nmulti-line comment */ ", TokenType.Comment, "/* This is a\r\nmulti-line comment */")]

        #endregion
        #region DateTime

        [DataRow(" [1975-11-22] ", TokenType.DateTime, "[1975-11-22]")]
        [DataRow(" [1975-11-22 12:34] ", TokenType.DateTime, "[1975-11-22 12:34]")]
        [DataRow(" [1975-11-22 12:34:56] ", TokenType.DateTime, "[1975-11-22 12:34:56]")]
        [DataRow(" [1975-11-22 12:34:56.789] ", TokenType.DateTime, "[1975-11-22 12:34:56.789]")]
        [DataRow(" [1975-1-2] ", TokenType.DateTime, "[1975-1-2]")]
        [DataRow(" [1975-1-2 2:3] ", TokenType.DateTime, "[1975-1-2 2:3]")]
        [DataRow(" [1975-1-2 2:3:4] ", TokenType.DateTime, "[1975-1-2 2:3:4]")]
        [DataRow(" [1975-1-2 2:3:4.5] ", TokenType.DateTime, "[1975-1-2 2:3:4.5]")]

        #endregion
        #region Field

        [DataRow(" Artist ", TokenType.TrackField, "Artist")]
        [DataRow(" title ", TokenType.TrackField, "Title")]
        [DataRow(" ALBUM ", TokenType.TrackField, "Album")]
        [DataRow(" Album Artist ", TokenType.TrackField, "Album Artist")]

        #endregion
        #region Number

        [DataRow(" 1 ", TokenType.Number, "1")]
        [DataRow(" 1.23 ", TokenType.Number, "1.23")]
        [DataRow(" 1.23f ", TokenType.Number, "1.23f")]
        [DataRow(" 1.23D ", TokenType.Number, "1.23D")]
        [DataRow(" 1.23M ", TokenType.Number, "1.23M")]
        [DataRow(" 1.23u ", TokenType.Number, "1.23u")]
        [DataRow(" 1.23L ", TokenType.Number, "1.23L")]
        [DataRow(" 1.23uL ", TokenType.Number, "1.23uL")]
        [DataRow(" 1.23e+4 ", TokenType.Number, "1.23e+4")]
        [DataRow(" 1.23E-5 ", TokenType.Number, "1.23E-5")]
        [DataRow(" 1.23e+4F ", TokenType.Number, "1.23e+4F")]
        [DataRow(" 1.23E-5d ", TokenType.Number, "1.23E-5d")]

        #endregion
        #region Parameter

        [DataRow(" {int} ", TokenType.Parameter, "{int}")]

        #endregion
        #region String

        [DataRow(" \"Abc Def\"", TokenType.String, "\"Abc Def\"")]
        [DataRow(" \"Abc\r\nDef\"", TokenType.String, "\"Abc\r\nDef\"")]

        #endregion
        #region TimeSpan

        [DataRow(" [12:34] ", TokenType.TimeSpan, "[12:34]")]
        [DataRow(" [12:34:56] ", TokenType.TimeSpan, "[12:34:56]")]
        [DataRow(" [12:34:56.789] ", TokenType.TimeSpan, "[12:34:56.789]")]
        [DataRow(" [2:3] ", TokenType.TimeSpan, "[2:3]")]
        [DataRow(" [2:3:4] ", TokenType.TimeSpan, "[2:3:4]")]
        [DataRow(" [2:3:4.5] ", TokenType.TimeSpan, "[2:3:4.5]")]

        #endregion
        [TestMethod]
        public void TestSingleTokenPass(string text, TokenType tokenType, string value)
        {
            var tokens = Tokenizer.GetTokens(text);
            Assert.AreEqual(expected: 1, actual: tokens.Count());
            var token = tokens.First();
            Assert.AreEqual(expected: null, actual: token.Error);
            Assert.AreEqual(expected: 1, actual: token.StartIndex);
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
                Assert.AreEqual(expected: 1, actual: token.StartIndex);
                Assert.AreEqual(expected: tokenType, actual: token.TokenType);
                Assert.AreEqual(expected: true, actual: token.Valid);
                Assert.AreEqual(expected: s, actual: token.Value);
            }
        }

        #endregion
    }
}
