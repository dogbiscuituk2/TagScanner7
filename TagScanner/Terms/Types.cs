namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Types
    {
        private static readonly Dictionary<string, Type> TypeDictionary = new Dictionary<string, Type>
        {
            { "bool", typeof(bool) },
            { "byte", typeof(byte) },
            { "char", typeof(char) },
            { "DateTime", typeof(DateTime) },
            { "decimal", typeof(decimal) },
            { "double", typeof(double) },
            { "float", typeof(float) },
            { "int", typeof(int) },
            { "long", typeof(long) },
            { "object", typeof(object) },
            { "RegexOptions", typeof(RegexOptions) },
            { "sbyte", typeof(sbyte) },
            { "short", typeof(short) },
            { "string", typeof(string) },
            { "TimeSpan", typeof(TimeSpan) },
            { "uint", typeof(uint) },
            { "ulong", typeof(ulong) },
            { "ushort", typeof(ushort) },
        };

        public static IEnumerable<string> TypeNames => TypeDictionary.Keys;
        public static IEnumerable<Type> TypeValues => TypeDictionary.Values;

        public static string Say(this Type type) => type.ToTypeName();

        public static Type ToType(this string typeName) => typeName.EndsWith("[]")
            ? typeName.Substring(0, typeName.Length - 2).ToType().MakeArrayType()
            : TypeDictionary[typeName];

        public static string ToTypeName(this Type type) => type.IsArray
            ? $"{type.GetElementType().ToTypeName()}[]"
            : TypeDictionary.FirstOrDefault(p => p.Value == type).Key;
    }
}