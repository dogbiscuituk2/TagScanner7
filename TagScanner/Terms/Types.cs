namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Types
    {
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

        public static IEnumerable<string> Names => _types.Keys;
        public static IEnumerable<Type> Values => _types.Values;

        public static string Say(this Type type) => type.ToTypeName();

        public static Type ToType(this string typeName) => typeName.EndsWith("[]")
            ? typeName.TrimEnd('[', ']').ToType().MakeArrayType()
            : _types[typeName];

        public static string ToTypeName(this Type type) => type.IsArray
            ? $"{type.GetElementType().ToTypeName()}[]"
            : _types.FirstOrDefault(p => p.Value == type).Key;
    }
}