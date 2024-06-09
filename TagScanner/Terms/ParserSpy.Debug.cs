namespace TagScanner.Terms
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System;

    partial class ParserSpy
    {

#if DEBUG_PARSER

        private void Dump(string caller, int line, object value, [CallerMemberName] string action = "")
        {
            {
                const string format = "{0,19}{1,6}  {2,12}  {3}";                                                                                                                                 r
                if (!_headerShown)
                {
                    DrawLine();
                    Debug.WriteLine(format, "CALLER", "LINE", "ACTION", "VALUE");
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
                Debug.WriteLine(format, caller, line, action, Say(value));
                if (isNewTerm || isPeek)
                    return;
                Debug.WriteLine(format, _, _, "Tokens", Says(_tokens));
                Debug.WriteLine(format, _, _, "Operators", Says(_operators.Cast<object>()));

                Debug.WriteLine(format, _, _, "Terms", _terms.Any() ? Say(_terms.First()) : _);
                if (_terms.Count > 1)
                    foreach (var term in _terms?.Skip(1))
                        Debug.WriteLine(format, _, _, _, Say(term));

                if (action == "EndParse")
                    DrawLine();
                else
                    Debug.WriteLine(_);

                void DrawLine() => Debug.WriteLine(new string('_', 132) + Environment.NewLine);

                /*void SayFormat(string format, string header, IEnumerable<object> values)
                {
                    if ((!values.Any()))
                        return;
                    var first = true;
                    foreach (var value in values)
                    {

                    }

                }*/
            }
        }

        private static string Say(object o) =>
            o is Token token ? token.Value :
            o is Op op ? $"{op}" :
            o is Term term ? $"{term.GetType().Say()} {term}" :
            o.ToString();

        private static string Say(IEnumerable<object> s)
        {
            if (!s.Any())
                return _;
            if (s.Count() == 1)
                return Say(s.First());
            return (string)s.Aggregate((p, q) => $"{Say(p)} {Say(q)}");
        }

#endif

    }
}