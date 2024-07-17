namespace TagScanner.Terms.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;

    partial class ParserSpy
    {
        private void Dump(string caller, int line, object value, [CallerMemberName] string action = "")
        {
#if PARSER
            if (action == "Reset")
                _headerShown = false;
            if (!_headerShown)
            {
                DrawLine();
                Say("CALLER", "LINE", "ACTION", new[] { "VALUE" });
                DrawLine();
                _headerShown = true;
            }
            if (action.StartsWith("Peek") || action == "NewTerm")
                return;
            Say(caller, line, action, ObjectToString(value).Split('\r', '\n').Where(p => p.Length > 0), singleLine: false);
            Say("Tokens", _tokens);
            Say("Operators", _operators.Select(p => ObjectToString(p)));
            Say("Terms", _terms, singleLine: false);
            if (action == "EndParse")
                DrawLine();
            Debug.WriteLine(string.Empty);
        }

        private const string _format = "{0,19}{1,6}  {2,12}  {3}";
        private bool _headerShown;

        private static void DrawLine() => Debug.WriteLine($"{new string('_', 132)}\n");

        private static string ObjectToString(object o) =>
            o is Token token ? token.Value :
            o is Op op ? $"{op}" :
            o is Term term ? $"{term.GetType().Say()} {term}" :
            o.ToString();

        private static void Say(string header, IEnumerable<object> values, bool singleLine = true) =>
            Say(string.Empty, string.Empty, header, values, singleLine);

        private static void Say(object h1, object h2, object h3, IEnumerable<object> values, bool singleLine = true)
        {
            if (singleLine)
                Write(ValuesToString());
            else if (values.Any())
                foreach (object value in values)
                {
                    Write(ObjectToString(value));
                    h1 = h2 = h3 = string.Empty;
                }
            else
                Write(string.Empty);

            object ValuesToString()
            {
                switch (values.Count())
                {
                    case 0: return string.Empty;
                    case 1: return ObjectToString(values.First());
                    default: return values.Aggregate((p, q) => $"{ObjectToString(p)} {ObjectToString(q)}");
                }
            }

            void Write(object o) => Debug.WriteLine(string.Format(_format, h1, h2, h3, o));
#endif // PARSER
        }
    }
}