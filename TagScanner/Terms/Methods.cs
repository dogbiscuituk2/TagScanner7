namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public static class Methods
    {
        #region Static Constructor

        static Methods()
        {
            MethodDictionary = new Dictionary<string, FunctionInfo>
            {
                { "Compare", GetFunctionInfo(typeof(string), true, "Compare", typeof(string), typeof(string)) },
                { "Concat_2", GetFunctionInfo(typeof(string), true, "Concat", typeof(string), typeof(string)) },
                { "Concat_3", GetFunctionInfo(typeof(string), true, "Concat", typeof(string), typeof(string), typeof(string)) },
                { "Concat_4", GetFunctionInfo(typeof(string), true, "Concat", typeof(string), typeof(string), typeof(string), typeof(string)) },
                { "Contains", GetFunctionInfo(typeof(string), false, "Contains", typeof(string)) },
                { "EndsWith", GetFunctionInfo(typeof(string), false, "EndsWith", typeof(string)) },
                { "Equals", GetFunctionInfo(typeof(object), false, "Equals", typeof(object)) },
                { "Format", GetFunctionInfo(typeof(string), true, "Format", typeof(string), typeof(object[])) },
                { "Length", GetFunctionInfo(typeof(string), false, "get_Length") },
                { "If", null },
                { "IndexOf", GetFunctionInfo(typeof(string), false, "IndexOf", typeof(char)) },
                { "Insert", GetFunctionInfo(typeof(string), false, "Insert", typeof(int), typeof(string)) },
                { "IsNull", GetFunctionInfo(typeof(string), true, "IsNullOrWhiteSpace", typeof(string)) }, // "IsEmpty" already used as a Tag :-(
                { "Match$", GetFunctionInfo(typeof(Regex), true, "IsMatch", typeof(string), typeof(string)) },
                { "LastIndexOf", GetFunctionInfo(typeof(string), false, "LastIndexOf", typeof(char)) },
                { "Lowercase", GetFunctionInfo(typeof(string), false, "ToLowerInvariant") },
                { "Max", GetFunctionInfo(typeof(Math), true, "Max", typeof(double), typeof(double)) },
                { "Min", GetFunctionInfo(typeof(Math), true, "Min", typeof(double), typeof(double)) },
                { "Power", GetFunctionInfo(typeof(Math), true, "Pow", typeof(double), typeof(double)) },
                { "Remove", GetFunctionInfo(typeof(string), false, "Remove", typeof(int), typeof(int)) },
                { "Replace", GetFunctionInfo(typeof(string), false, "Replace", typeof(string), typeof(string)) },
                { "Replace$", GetFunctionInfo(typeof(Regex), true, "Replace", typeof(string), typeof(string), typeof(string)) },
                { "Round", GetFunctionInfo(typeof(Math), true, "Round", typeof(double)) },
                { "Sign", GetFunctionInfo(typeof(Math), true, "Sign", typeof(double)) },
                { "StartsWith", GetFunctionInfo(typeof(string), false, "StartsWith", typeof(string)) },
                { "Substring", GetFunctionInfo(typeof(string), false, "Substring", typeof(int), typeof(int)) },
                { "ToString", GetFunctionInfo(typeof(object), false, "ToString") },
                { "Trim", GetFunctionInfo(typeof(string), false, "Trim") },
                { "Truncate", GetFunctionInfo(typeof(Math), true, "Truncate", typeof(double)) },
                { "Uppercase", GetFunctionInfo(typeof(string), false, "ToUpperInvariant") },
            };
            Keys = MethodDictionary.Keys.ToArray();
            Values = MethodDictionary.Values.ToArray();
        }

        #endregion

        #region Public Properties

        public static string[] Keys { get; }
        public static FunctionInfo[] Values { get; }

        #endregion

        #region Public Methods

        public static string GetPrototype(this string key)
        {
            var method = key.FunctionInfo();
            var fullName = method.IsStatic ? key : $"({method.DeclaringType.Say()}).{key}";
            return $"{method.ReturnType.Say()} {fullName}({method.SayParamTypes()})";
        }

        public static FunctionInfo FunctionInfo(this string key) => MethodDictionary[key];

        public static bool IsStatic(this string key) => key.FunctionInfo().IsStatic;

        #endregion

        #region Private Fields

        private static readonly Dictionary<string, FunctionInfo> MethodDictionary;

        #endregion

        #region Private Methods

        private static FunctionInfo GetFunctionInfo(Type declaringType, bool isStatic, string name, params Type[] paramTypes) =>
            new FunctionInfo(declaringType
                .GetMethods(BindingFlags.Public | (isStatic ? BindingFlags.Static : BindingFlags.Instance))
                .Single(p => p.Name == name && p.GetParamTypes().SequenceEqual(paramTypes)));

        private static IEnumerable<Type> GetParamTypes(this MethodInfo method) => method.GetParameters().Select(p => p.ParameterType);

        private static string SayParamTypes(this FunctionInfo method)
        {
            var types = method.GetParamTypes();
            return types.Any() ? types.Select(p => p.Say()).Aggregate((p, q) => $"{p}, {q}") : string.Empty;
        }

        #endregion
    }
}
