namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Utils;

    public static class Methods
    {
        #region Static Constructor

        static Methods()
        {
            MethodDictionary = new Dictionary<string, MethodInfo>
            {
                { "Compare", FindMethodInfo(typeof(string), true, "Compare", typeof(string), typeof(string)) },
                { "Concat_2", FindMethodInfo(typeof(string), true, "Concat", typeof(string), typeof(string)) },
                { "Concat_3", FindMethodInfo(typeof(string), true, "Concat", typeof(string), typeof(string), typeof(string)) },
                { "Concat_4", FindMethodInfo(typeof(string), true, "Concat", typeof(string), typeof(string), typeof(string), typeof(string)) },
                { "Contains", FindMethodInfo(typeof(string), false, "Contains", typeof(string)) },
                { "EndsWith", FindMethodInfo(typeof(string), false, "EndsWith", typeof(string)) },
                { "Equals", FindMethodInfo(typeof(object), false, "Equals", typeof(object)) },
                { "Format", FindMethodInfo(typeof(string), true, "Format", typeof(string), typeof(object[])) },
                { "Length", FindMethodInfo(typeof(string), false, "get_Length") },
                { "IndexOf", FindMethodInfo(typeof(string), false, "IndexOf", typeof(char)) },
                { "Insert", FindMethodInfo(typeof(string), false, "Insert", typeof(int), typeof(string)) },
                { "IsNull", FindMethodInfo(typeof(string), true, "IsNullOrWhiteSpace", typeof(string)) }, // "IsEmpty" already used as a Tag :-(
                { "Match$", FindMethodInfo(typeof(Regex), true, "IsMatch", typeof(string), typeof(string)) },
                { "LastIndexOf", FindMethodInfo(typeof(string), false, "LastIndexOf", typeof(char)) },
                { "Lowercase", FindMethodInfo(typeof(string), false, "ToLowerInvariant") },
                { "Max", FindMethodInfo(typeof(Math), true, "Max", typeof(double), typeof(double)) },
                { "Min", FindMethodInfo(typeof(Math), true, "Min", typeof(double), typeof(double)) },
                { "Power", FindMethodInfo(typeof(Math), true, "Pow", typeof(double), typeof(double)) },
                { "Remove", FindMethodInfo(typeof(string), false, "Remove", typeof(int), typeof(int)) },
                { "Replace", FindMethodInfo(typeof(string), false, "Replace", typeof(string), typeof(string)) },
                { "Replace$", FindMethodInfo(typeof(Regex), true, "Replace", typeof(string), typeof(string), typeof(string)) },
                { "Round", FindMethodInfo(typeof(Math), true, "Round", typeof(double)) },
                { "Sign", FindMethodInfo(typeof(Math), true, "Sign", typeof(double)) },
                { "StartsWith", FindMethodInfo(typeof(string), false, "StartsWith", typeof(string)) },
                { "Substring", FindMethodInfo(typeof(string), false, "Substring", typeof(int), typeof(int)) },
                { "ToString", FindMethodInfo(typeof(object), false, "ToString") },
                { "Trim", FindMethodInfo(typeof(string), false, "Trim") },
                { "Truncate", FindMethodInfo(typeof(Math), true, "Truncate", typeof(double)) },
                { "Uppercase", FindMethodInfo(typeof(string), false, "ToUpperInvariant") },
            };
            Keys = MethodDictionary.Keys.ToArray();
            Values = MethodDictionary.Values.ToArray();
        }

        #endregion

        #region Public Properties

        public static string[] Keys { get; }
        public static MethodInfo[] Values { get; }

        #endregion

        #region Public Methods

        public static string GetPrototype(this string key)
        {
            var method = key.MethodInfo();
            var fullName = method.IsStatic ? key : $"({method.DeclaringType.Say()}).{key}";
            return $"{method.ReturnType.Say()} {fullName}({method.SayParamTypes()})";
        }

        public static MethodInfo MethodInfo(this string key) => MethodDictionary[key];

        public static bool IsStatic(this string key) => key.MethodInfo().IsStatic;

        #endregion

        #region Private Fields

        private static readonly Dictionary<string, MethodInfo> MethodDictionary;

        #endregion

        #region Private Methods

        private static MethodInfo FindMethodInfo(Type declaringType, bool isStatic, string name,
            params Type[] paramTypes) => declaringType
            .GetMethods(BindingFlags.Public | (isStatic ? BindingFlags.Static : BindingFlags.Instance))
            .Single(p => p.Name == name && p.GetParamTypes().SequenceEqual(paramTypes));

        private static IEnumerable<Type> GetParamTypes(this MethodInfo method) => method.GetParameters().Select(p => p.ParameterType);

        private static string SayParamTypes(this MethodInfo method)
        {
            var types = method.GetParamTypes();
            return types.Any() ? types.Select(p => p.Say()).Aggregate((p, q) => $"{p}, {q}") : string.Empty;
        }

        #endregion
    }
}
