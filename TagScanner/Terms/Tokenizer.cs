﻿namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Utils;

    public static class Tokenizer
    {
        #region Public Methods

        public static bool TryGetTokens(string text, ref List<Token> tokens)
        {
            bool ok = true;
            try
            {
                foreach (var token in GetTokens(text))
                    tokens.Add(token);
            }
            catch (Exception exception)
            {
                exception.LogException();
                ok = false;
            }
            return ok;
        }

        public static IEnumerable<Token> GetTokens(string text)
        {
            int count = text.Length, index = 0;
            while (true)
            {
                while (index < count && text[index] <= ' ')
                    index++;
                if (index >= count)
                    break;
                var token = Match();
                if (token.Length == 0)
                    token = UnexpectedCharacter();
                if (string.IsNullOrWhiteSpace(token.Value))
                    break;
                index += token.Length;
#if DEBUG_TOKENIZER
                System.Diagnostics.Debug.WriteLine(token);
#endif
                yield return token;
            }
            if (index < count)
                SyntaxError();
            yield break;

            Token UnexpectedCharacter() => new Token(0, index, $"{text[index]}");

            Token Match()
            {
                var remainingText = RemainingText();
                if (remainingText.IsComment())
                    return MatchComment();
                if (remainingText.StartsWithNumber())
                    return MatchNumber();

                Token token = null;
                if (MatchKeyword(ref token, TokenType.Boolean, Booleans)) return token;
                if (MatchKeyword(ref token, TokenType.Field, Fields)) return token;
                if (MatchKeyword(ref token, TokenType.Function, FunctionNames)) return token;
                if (MatchKeyword(ref token, TokenType.Symbol, Symbols)) return token;
                if (MatchKeyword(ref token, TokenType.TypeName, TypeNames)) return token;

                switch (index < count ? text[index] : Nul)
                {
                    case SingleQuote:
                        return MatchCharacter();
                    case DoubleQuote:
                        return MatchString();
                    case LeftBracket:
                        var dateTime = MatchDateTime();
                        return !string.IsNullOrWhiteSpace(dateTime.Value) ? dateTime : MatchTimeSpan();
                    case LeftBrace:
                        return MatchParameter();
                    case char c when char.IsLetter(c):
                        return MatchVariable();
                }
                return UnexpectedCharacter();
            }

            bool MatchKeyword(ref Token token, TokenType tokenType, IEnumerable<string> keywords)
            {
                var remainingText = RemainingText();
                var value = keywords
                    .OrderByDescending(p => p).
                    FirstOrDefault(p => remainingText.StartsWith(p, StringComparison.OrdinalIgnoreCase));
                var ok = !string.IsNullOrWhiteSpace(value);
                if (ok)
                    token = new Token(tokenType, index, value);
                return ok;
            }

            Token MatchCharacter() => MatchRegex(TokenType.Character, "^'.'");
            Token MatchDateTime() => MatchRegex(TokenType.DateTime, DateTimeParser.DateTimePattern);
            Token MatchNumber() => MatchRegex(TokenType.Number, NumberPattern);
            Token MatchParameter() => MatchRegex(TokenType.Parameter, @"^\{\w+(\[\])?\}");
            Token MatchString() => MatchRegex(TokenType.String, "\"[^\"|\\\"]*\"");
            Token MatchTimeSpan() => MatchRegex(TokenType.TimeSpan, DateTimeParser.TimeSpanPattern);
            Token MatchVariable() => MatchRegex(TokenType.Variable, @"[\w]+");

            Token MatchComment()
            {
                var remainingText = RemainingText();
                return new Token(
                    TokenType.Comment,
                    index,
                    remainingText.Substring(0,
                    remainingText.StartsWith("/*")
                    ? remainingText.IndexOf("*/") + 2
                    : $"{remainingText}\n".IndexOf("\n")));
            }

            Token MatchRegex(TokenType tokenType, string pattern, RegexOptions options = RegexOptions.IgnoreCase) =>
                new Token(tokenType, index, Regex.Match(RemainingText(), $"^{pattern}", options).Value);

            string RemainingText() => text.Substring(index);
            void SyntaxError() => throw new FormatException($"Unrecognised term at character position {index}: {RemainingText()}");
        }

        public static bool IsBinaryOperator(this string token) => Operators.ContainsBinarySymbol(token);
        public static bool IsBoolean(this string token) => Booleans.Contains(token, IgnoreCase);
        public static bool IsChar(this string token) => token[0] == SingleQuote;
        public static bool IsConstant(this string token) => token.IsBoolean() || token.IsNumber() || token.IsString();
        public static bool IsDateTime(this string token) => Regex.IsMatch(token, DateTimeParser.DateTimePattern);
        public static bool IsField(this string token) => Fields.Contains(token, IgnoreCase);
        public static bool IsFunction(this string token) => FunctionNames.Contains(token, IgnoreCase);
        public static bool IsName(this string token) => Regex.IsMatch(token, $"{NamePattern}$");
        public static bool IsNumber(this string token) => Regex.IsMatch(token, $"{NumberPattern}$");
        public static bool IsOperator(this string token) => Operators.ContainsSymbol(token);
        public static bool IsParameter(this string token) => token[0] == '{';
        public static bool IsString(this string token) => token[0] == DoubleQuote;
        public static bool IsSymbol(this string token) => Symbols.Contains(token, IgnoreCase);
        public static bool IsTimeSpan(this string token) => Regex.IsMatch(token, DateTimeParser.TimeSpanPattern);
        public static bool IsType(this string token) => TypeNames.Contains(token, IgnoreCase);
        public static bool IsUnaryOperator(this string token) => Operators.ContainsUnarySymbol(token);
        public static Rank Rank(this string token, bool unary) => token.ToOperator(unary).GetRank();
        public static bool StartsWithNumber(this string token) => Regex.IsMatch(token, NumberPattern);

        private const string NamePattern = @"\w+";
        private const string NumberPattern = @"^(\d+\.?\d*([Ee][-+]\d+)?(UL|LU|D|F|L|M|U)?)";

        #endregion

        #region Private Fields

        private const char
            Nul = (char)0,
            SingleQuote = '\'',
            DoubleQuote = '"',
            LeftAngle = '<',
            LeftBrace = '{',
            LeftBracket = '[',
            LeftParen = '(',
            RightAngle = '>',
            RightBrace = '}',
            RightBracket = ']',
            RightParen = ')';

        /// <summary>
        /// Names are ordered descending to that, for example, "Album Artists" is matched before "Artists".
        /// If these were sorted in ascending or other order, "Album Artists" might never be matched.
        /// </summary>
        private static readonly string[] AllTokens = Booleans
            .Union(Fields)
            .Union(FunctionNames)
            .Union(Symbols)
            .Union(TypeNames)
            .OrderByDescending(p => p).ToArray();

        private static EqualityComparer IgnoreCase = new EqualityComparer(caseSensitive: false);

        #endregion

        #region Private Properties

        private static IEnumerable<string> Booleans => new[] { "false", "true" };
        private static IEnumerable<string> Fields => Tags.Keys.Select(p => p.DisplayName());
        private static IEnumerable<string> FunctionNames => Functors.Keys.Select(fn => $"{fn}");
        private static IEnumerable<string> Symbols => Operators.GetAllSymbols();
        private static IEnumerable<string> TypeNames => Types.Names;

        #endregion
    }
}
