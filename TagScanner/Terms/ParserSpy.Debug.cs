namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    partial class ParserSpy
    {
#if PARSER
        private const string _format = "{0,19}{1,6}  {2,12}  {3}";
        private bool _headerShown;
        private string
            _prevTokens = null,
            _prevOperators = null,
            _prevTerms = null;

        private void Dump(string caller, int line, object value, [CallerMemberName] string action = "")
        {
            if (action == "Reset")
                _headerShown = false;
            if (!_headerShown)
            {
                DrawLine();
                Print("CALLER", "LINE", "ACTION", "VALUE");
                DrawLine();
                _headerShown = true;
            }
            var skip = action.StartsWith("Peek") || action == "NewTerm";
#if !VERBOSE
                if (skip) return;
#endif // !VERBOSE
            Print(caller, line, action, ObjectToString(value));
            if (skip)
                return;

            Say("Tokens", ref _prevTokens, _tokens, singleLine: true);
            Say("Operators", ref _prevOperators, _operators.Select(p => ObjectToString(p)), singleLine: true);
            Say("Terms", ref _prevTerms, _terms, singleLine: false);

            if (action == "EndParse")
            {
                DrawLine();
#if VERBOSE
                Debug.WriteLine("#undef VERBOSE to reduce the level of detail in this output.");
#else
                Debug.WriteLine("#define VERBOSE to increase the level of detail in this output.");
#endif
            }
            Debug.WriteLine(string.Empty);
        }

        private static void DrawLine() => Debug.WriteLine(new string('_', 132) + Environment.NewLine);

        private static void Say(string header, ref string prev, IEnumerable<object> values, bool singleLine)
        {
            var s = new StringBuilder(string.Empty);
            if (singleLine)
                Add(ListToString(values));
            else if (values.Any())
                foreach (object value in values)
                {
                    Add(ObjectToString(value));
                    header = string.Empty;
                }
            else
                Add(string.Empty);
            var result = s.ToString();
#if VERBOSE
            Debug.Write(result);
#else // !VERBOSE
            if (prev != result)
            {
                prev = result;
                Debug.Write(result);
            }
#endif // VERBOSE
            void Add(string t) => s.AppendLine(Format(string.Empty, string.Empty, header, t));
        }

        private static string Format(params object[] values) => string.Format(_format, values);

        private static void Print(params object[] values) => Debug.WriteLine(Format(values));

        private static string ListToString(IEnumerable<object> values) =>
            !values.Any() ? string.Empty :
            values.Count() == 1 ? ObjectToString(values.First()) :
            (string)values.Aggregate((p, q) => $"{ObjectToString(p)} {ObjectToString(q)}");

        private static string ObjectToString(object o) =>
            o is Token token ? token.Value :
            o is Op op ? $"{op}" :
            o is Term term ? $"{term.GetType().Say()} {term}" :
            o.ToString();
#endif // PARSER
    }
}