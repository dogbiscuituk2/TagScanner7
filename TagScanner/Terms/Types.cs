namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class Types
    {
        public static IEnumerable<string> Names => _types.Keys;
        public static IEnumerable<Type> Values => _types.Values;

        public static object GetDefaultValue(this Type type) =>
            type.IsArray
            ? (new[] { GetDefaultValue(type.GetElementType()) })
            : _defaultValues.ContainsKey(type)
            ? _defaultValues[type]
            : null;

        public static string Say(this Type type)
        {
            if (type == null)
                return string.Empty;
            if (type.IsArray)
                return $"{type.GetElementType().Say()}[]";
            var name = type.Name;
            if (type.IsGenericType)
            {
                var result = new StringBuilder(name.Substring(0, name.IndexOf('`')));
                result.Append('<');
                var first = true;
                foreach (var t in type.GetGenericArguments())
                {
                    if (!first) result.Append(',');
                    result.Append(t.Say());
                    first = false;
                }
                result.Append('>');
                return result.ToString();
            }
            return _types.FirstOrDefault(p => p.Value == type).Key ?? name;
        }

        public static Type ToType(this string typeName)
        {
            if (typeName.EndsWith("[]"))
                return typeName.TrimEnd('[', ']').ToType().MakeArrayType();
            if (_types.ContainsKey(typeName))
                return _types[typeName];
            return Type.GetType(typeName);
        }

        private static readonly Dictionary<string, Type> _types = new Dictionary<string, Type>
        {
            { "bool", typeof(bool) },
            { "char", typeof(char) },
            { "DateTime", typeof(DateTime) },
            { "decimal", typeof(decimal) },
            { "double", typeof(double) },
            { "float", typeof(float) },
            { "int", typeof(int) },
            { "long", typeof(long) },
            { "object", typeof(object) },
            { "RegexOptions", typeof(RegexOptions) },
            { "string", typeof(string) },
            { "TimeSpan", typeof(TimeSpan) },
            { "uint", typeof(uint) },
            { "ulong", typeof(ulong) },
        };

        private static readonly Dictionary<Type, object> _defaultValues = new Dictionary<Type, object>
        {
            { typeof(bool), false },
            { typeof(char), '\0' },
            { typeof(DateTime), DateTime.MinValue },
            { typeof(decimal), 0M },
            { typeof(double), 0D },
            { typeof(float), 0F },
            { typeof(int), 0 },
            { typeof(long), 0L },
            { typeof(RegexOptions), 0 },
            { typeof(TimeSpan), TimeSpan.MinValue },
            { typeof(uint), 0U },
            { typeof(ulong), 0UL },
        };
    }
}