namespace TagScanner.Terms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;

    partial class ParserSpy
    {

#if DEBUG_PARSER

        private static readonly string _ = string.Empty;
        private const string _format = "{0,19}{1,6}  {2,12}  {3}";
        private bool _headerShown;

        private void Dump(string caller, int line, object value, [CallerMemberName] string action = "")
        {
            {
                if (!_headerShown)
                {
                    DrawLine();
                    Say4("CALLER", "LINE", "ACTION", "VALUE");
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
                Say4(caller, line, action, value);
                if (isNewTerm || isPeek)
                    return;

                Say2("Tokens", _tokens);
                Say2("Operators", _operators.Select(p => SayObject(p)));
                Say4(_, _, "Terms", _terms.Any() ? _terms.First() : _);

                if (_terms.Count > 1)
                    foreach (var term in _terms?.Skip(1))
                        Say4(_, _, _, term);

                if (action == "EndParse")
                    DrawLine();
                else
                    Debug.WriteLine(_);

                void DrawLine() => Debug.WriteLine(new string('_', 132) + Environment.NewLine);
            }
        }

        private static void Say2(string header, IEnumerable<object> list) => Say4(_, _, header, SayList(list));

        private static void Say4(params object[] values) => Debug.WriteLine(string.Format(_format, values));

        private static string 30(object o) =>
            o is Token token ? token.Value :
            o is Op op ? $"{op}" :
            o is Term term ? $"{term.GetType().Say()} {term}" :
            o.ToString();

        private static string SayList(IEnumerable<object> values)
        {
            if (!values.Any())
                return _;
            if (values.Count() == 1)
                return SayObject(values.First());
            return (string)values.Aggregate((p, q) => $"{SayObject(p)} {SayObject(q)}");
        }

#endif

    }
}