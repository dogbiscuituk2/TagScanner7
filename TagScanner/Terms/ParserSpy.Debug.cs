namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;

    partial class ParserSpy
    {

#if DEBUG_PARSER

        private const string _format = "{0,19}{1,6}  {2,12}  {3}";
        private bool _headerShown;

        private void Dump(string caller, int line, object value, [CallerMemberName] string action = "")
        {
            {
                if (!_headerShown)
                {
                    DrawLine();
                    Say("CALLER", "LINE", "ACTION", "VALUE");
                    DrawLine();
                    _headerShown = true;
                }
                bool
                    isPeek = action.StartsWith("Peek"),
                    isNewTerm = action == "NewTerm";
#if !DEBUG_PARSER_PEEK
                if (isPeek) return;
#endif
#if !DEBUG_PARSER_NEW
                if (isNewTerm) return;
#endif
                Say(caller, line, action, ObjectToString(value));
                if (isNewTerm || isPeek)
                    return;
                Say("Tokens", _tokens);
                Say("Operators", _operators.Select(p => ObjectToString(p)));
                SayMultiline("Terms", _terms);
                if (action == "EndParse")
                    DrawLine();
                else
                    Debug.WriteLine(string.Empty);
            }
        }

        private static void DrawLine() => Debug.WriteLine(new string('_', 132) + Environment.NewLine);
        private static void Say(string header, IEnumerable<object> list) => Say(string.Empty, string.Empty, header, ListToString(list));
        private static void Say(params object[] values) => Debug.WriteLine(string.Format(_format, values));

        private static string ListToString(IEnumerable<object> values) =>
            !values.Any() ? string.Empty :
            values.Count() == 1 ? ObjectToString(values.First()) :
            (string)values.Aggregate((p, q) => $"{ObjectToString(p)} {ObjectToString(q)}");

        private static string ObjectToString(object o) =>
            o is Token token ? token.Value :
            o is Op op ? $"{op}" :
            o is Term term ? $"{term.GetType().Say()} {term}" :
            o.ToString();

        private void SayMultiline(string header, IEnumerable<object> values)
        {
            if (!values.Any()) return;
            foreach (object value in values)
            {
                Say(string.Empty, string.Empty, header, ObjectToString(value));
                header = string.Empty;
            }
        }

#endif

    }
}