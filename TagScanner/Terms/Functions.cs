namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public static class Functions
    {
        #region Static Constructor

        static Functions()
        {
            FunctionDictionary = new Dictionary<string, FuncInfo>
            {
                { "Compare", GetFuncInfo(typeof(string), true, "Compare", typeof(string), typeof(string)) },
                { "Concat_2", GetFuncInfo(typeof(string), true, "Concat", typeof(string), typeof(string)) },
                { "Concat_3", GetFuncInfo(typeof(string), true, "Concat", typeof(string), typeof(string), typeof(string)) },
                { "Concat_4", GetFuncInfo(typeof(string), true, "Concat", typeof(string), typeof(string), typeof(string), typeof(string)) },
                { "Contains", GetFuncInfo(typeof(string), false, "Contains", typeof(string)) },
                { "EndsWith", GetFuncInfo(typeof(string), false, "EndsWith", typeof(string)) },
                { "Equals", GetFuncInfo(typeof(object), false, "Equals", typeof(object)) },
                { "Format", GetFuncInfo(typeof(string), true, "Format", typeof(string), typeof(object[])) },
                { "Length", GetFuncInfo(typeof(string), false, "get_Length") },
                { "If", new FuncInfo("If", true, typeof(bool), typeof(object), typeof(object)) },
                { "IndexOf", GetFuncInfo(typeof(string), false, "IndexOf", typeof(char)) },
                { "Insert", GetFuncInfo(typeof(string), false, "Insert", typeof(int), typeof(string)) },
                { "IsNull", GetFuncInfo(typeof(string), true, "IsNullOrWhiteSpace", typeof(string)) }, // "IsEmpty" already used as a Tag :-(
                { "Match$", GetFuncInfo(typeof(Regex), true, "IsMatch", typeof(string), typeof(string)) },
                { "LastIndexOf", GetFuncInfo(typeof(string), false, "LastIndexOf", typeof(char)) },
                { "Lowercase", GetFuncInfo(typeof(string), false, "ToLowerInvariant") },
                { "Max", GetFuncInfo(typeof(Math), true, "Max", typeof(double), typeof(double)) },
                { "Min", GetFuncInfo(typeof(Math), true, "Min", typeof(double), typeof(double)) },
                { "Power", GetFuncInfo(typeof(Math), true, "Pow", typeof(double), typeof(double)) },
                { "Remove", GetFuncInfo(typeof(string), false, "Remove", typeof(int), typeof(int)) },
                { "Replace", GetFuncInfo(typeof(string), false, "Replace", typeof(string), typeof(string)) },
                { "Replace$", GetFuncInfo(typeof(Regex), true, "Replace", typeof(string), typeof(string), typeof(string)) },
                { "Round", GetFuncInfo(typeof(Math), true, "Round", typeof(double)) },
                { "Sign", GetFuncInfo(typeof(Math), true, "Sign", typeof(double)) },
                { "StartsWith", GetFuncInfo(typeof(string), false, "StartsWith", typeof(string)) },
                { "Substring", GetFuncInfo(typeof(string), false, "Substring", typeof(int), typeof(int)) },
                { "ToString", GetFuncInfo(typeof(object), false, "ToString") },
                { "Trim", GetFuncInfo(typeof(string), false, "Trim") },
                { "Truncate", GetFuncInfo(typeof(Math), true, "Truncate", typeof(double)) },
                { "Uppercase", GetFuncInfo(typeof(string), false, "ToUpperInvariant") },
            };
            Keys = FunctionDictionary.Keys.ToArray();
            Values = FunctionDictionary.Values.ToArray();
        }

        #endregion

        #region Public Properties

        public static string[] Keys { get; }
        public static FuncInfo[] Values { get; }

        #endregion

        #region Public Methods

        public static string GetPrototype(this string key)
        {
            var funcInfo = key.FuncInfo();
            var fullName = funcInfo.IsStatic ? key : $"({funcInfo.DeclaringType.Say()}).{key}";
            return $"{funcInfo.ReturnType.Say()} {fullName}({funcInfo.SayParamTypes()})";
        }

        public static FuncInfo FuncInfo(this string key) => FunctionDictionary[key];

        public static bool IsStatic(this string key) => key.FuncInfo().IsStatic;

        public static int ParamCount(this string key) => key.FuncInfo().ParamCount;

        #endregion

        #region Private Fields

        private static readonly Dictionary<string, FuncInfo> FunctionDictionary;

        #endregion

        #region Private Methods

        private static FuncInfo GetFuncInfo(Type declaringType, bool isStatic, string name, params Type[] paramTypes) =>
            new FuncInfo(declaringType
                .GetMethods(BindingFlags.Public | (isStatic ? BindingFlags.Static : BindingFlags.Instance))
                .Single(p => p.Name == name && p.GetParamTypes().SequenceEqual(paramTypes)));

        private static IEnumerable<Type> GetParamTypes(this MethodInfo methodInfo) => methodInfo.GetParameters().Select(p => p.ParameterType);

        private static string SayParamTypes(this FuncInfo funcInfo)
        {
            var types = funcInfo.ParamTypes;
            return types.Any() ? types.Select(p => p.Say()).Aggregate((p, q) => $"{p}, {q}") : string.Empty;
        }

        #endregion
    }
}
