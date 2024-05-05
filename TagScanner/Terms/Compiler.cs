namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;

    public static class Compiler
    {
        public static IEnumerable<Track> Filter(this IEnumerable<Track> tracks, string source, bool caseSensitive)
        {
            var code = GetCode(source, caseSensitive, out object[] values);
            return tracks.Where(p =>
            {
                values[0] = p;
                return (bool)code.DynamicInvoke(values);
            });
        }

        public static void Process(this IEnumerable<Track> tracks, string source, bool caseSensitive)
        {
            var code = GetCode(source, caseSensitive, out object[] values);
            foreach (var track in tracks)
            {
                values[0] = track;
                code.DynamicInvoke(values);
            }
        }

        private static Delegate GetCode(string source, bool caseSensitive, out object[] values)
        {
            Delegate result = null;
            values = null;
            var parser = new Parser();
            if (parser.TryParse(source, out Term term, out Exception exception, caseSensitive))
            {
                var variables = parser.State;
                var parameters = new List<ParameterExpression> { Term.Track };
                parameters.AddRange(variables.Select(p => (ParameterExpression)p.Expression));
                var count = variables?.Count() ?? 0;
                values = new object[count + 1];
                values[0] = null;
                for (var index = 0; index < count; index++)
                    values[index + 1] = variables[index].ResultType.GetDefaultValue();
                var expression = term.Expression;

                var lambda = Expression.Lambda(expression, parameters);
                result = lambda.Compile();
            }
            return result;
        }
    }
}