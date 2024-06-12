﻿namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    partial class ParserSpy
    {
        private void Dump(string caller, int line, object value, [CallerMemberName] string action = "")
#if !PARSER
        {
        }
#else // PARSER
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
            if (action.StartsWith("Peek") || action == "NewTerm")
                return;

            Print(caller, line, action, ObjectToString(value));
            Say("Tokens", _tokens);
            Say("Operators", _operators.Select(p => ObjectToString(p)));
            Say("Terms", _terms, singleLine: false);

            if (action == "EndParse")
                DrawLine();
            Debug.WriteLine(string.Empty);
        }

        private const string _format = "{0,19}{1,6}  {2,12}  {3}";
        private bool _headerShown;

        private static void DrawLine() => Debug.WriteLine(new string('_', 132) + Environment.NewLine);

        private static void Say(string header, IEnumerable<object> values, bool singleLine = true) =>
            Say(string.Empty, string.Empty, header, values, singleLine);

        private static void Say(string h1, string h2, string h3, IEnumerable<object> values, bool singleLine)
        {
            var s = new StringBuilder(string.Empty);
            if (singleLine)
                Add(ListToString(values));
            else if (values.Any())
                foreach (object value in values)
                {
                    Add(ObjectToString(value));
                    h1 = h2 = h3 = string.Empty;
                }
            else
                Add(string.Empty);
            var result = s.ToString();
            Debug.Write(result);

            void Add(string t) => s.AppendLine(Format(h1, h2, h3, t));
        }

        private static string Format(params object[] values) => string.Format(_format, values);

        private static string ListToString(IEnumerable<object> values) =>
            !values.Any() ? string.Empty :
            values.Count() == 1 ? ObjectToString(values.First()) :
            (string)values.Aggregate((p, q) => $"{ObjectToString(p)} {ObjectToString(q)}");

        private static string ObjectToString(object o) =>
            o is Token token ? token.Value :
            o is Op op ? $"{op}" :
            o is Term term ? $"{term.GetType().Say()} {term}" :
            o.ToString();

        private static void Print(params object[] values) => Debug.WriteLine(Format(values));
#endif // PARSER
    }
}