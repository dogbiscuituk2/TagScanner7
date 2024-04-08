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
            FunctionDictionary = new Dictionary<fn, FuncInfo>();
            AddFn(Fn.Compare, typeof(string), true, typeof(string), typeof(string));
            AddFn(Fn.Concat_2, "Concat", typeof(string), true, typeof(string), typeof(string));
            AddFn(Fn.Concat_3, "Concat", typeof(string), true, typeof(string), typeof(string), typeof(string));
            AddFn(Fn.Concat_4, "Concat", typeof(string), true, typeof(string), typeof(string), typeof(string), typeof(string));

            {
                { Fn.Compare, GetFuncInfo(typeof(string), true, typeof(string), typeof(string)) },
                { Fn.Concat_2, GetFuncInfo(typeof(string), true, "Concat", typeof(string), typeof(string)) },
                { Fn.Concat_3, GetFuncInfo(typeof(string), true, "Concat", typeof(string), typeof(string), typeof(string)) },
                { Fn.Concat_4, GetFuncInfo(typeof(string), true, "Concat", typeof(string), typeof(string), typeof(string), typeof(string)) },
                { Fn.Contains, GetFuncInfo(typeof(string), false, typeof(string)) },
                { Fn.EndsWith, GetFuncInfo(typeof(string), false, typeof(string)) },
                { Fn.Equals, GetFuncInfo(typeof(object), false, typeof(object)) },
                { Fn.Format, GetFuncInfo(typeof(string), true, typeof(string), typeof(object[])) },
                { Fn.Length, GetFuncInfo(typeof(string), false, "get_Length") },
                { Fn.If, new FuncInfo(Fn.If, true, typeof(bool), typeof(object), typeof(object)) },
                { Fn.IndexOf, GetFuncInfo(typeof(string), false, typeof(char)) },
                { Fn.Insert, GetFuncInfo(typeof(string), false, typeof(int), typeof(string)) },
                { Fn.IsNull, GetFuncInfo(typeof(string), true, "IsNullOrWhiteSpace", typeof(string)) }, // "IsEmpty" already used as a Tag :-(
                { Fn.Match_, GetFuncInfo(typeof(Regex), true, "IsMatch", typeof(string), typeof(string)) },
                { Fn.LastIndexOf, GetFuncInfo(typeof(string), false, typeof(char)) },
                { Fn.Lowercase, GetFuncInfo(typeof(string), false, "ToLowerInvariant") },
                { Fn.Max, GetFuncInfo(typeof(Math), true, typeof(double), typeof(double)) },
                { "Min", GetFuncInfo(typeof(Math), true, typeof(double), typeof(double)) },
                { Fn.Pow, GetFuncInfo(typeof(Math), true,  typeof(double), typeof(double)) },
                { Fn.Remove, GetFuncInfo(typeof(string), false, typeof(int), typeof(int)) },
                { Fn.Replace, GetFuncInfo(typeof(string), false, typeof(string), typeof(string)) },
                { Fn.Replace_, GetFuncInfo(typeof(Regex), true, "Replace", typeof(string), typeof(string), typeof(string)) },
                { Fn.Round, GetFuncInfo(typeof(Math), true, typeof(double)) },
                { Fn.Sign, GetFuncInfo(typeof(Math), true, typeof(double)) },
                { Fn.StartsWith, GetFuncInfo(typeof(string), false, typeof(string)) },
                { Fn.Substring, GetFuncInfo(typeof(string), false, typeof(int), typeof(int)) },
                { Fn.ToString, GetFuncInfo(typeof(object), false) },
                { Fn.ToText, new FuncInfo(Fn.ToText, true, typeof(string)) },
                { Fn.Trim, GetFuncInfo(typeof(string), false) },
                { Fn.Truncate, GetFuncInfo(typeof(Math), true, typeof(double)) },
                { Fn.Uppercase, GetFuncInfo(typeof(string), false, "ToUpperInvariant") },
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

        private static readonly Dictionary<Fn, FuncInfo> FunctionDictionary;

        #endregion

        #region Private Methods

        private static void AddFn(Fn fn, Type declaringType, bool isStatic, params Type[] paramTypes) =>
            AddFn(fn, fn.ToString(), declaringType, isStatic, paramTypes);

        private static void AddFn(Fn fn, string name, Type declaringType, bool isStatic, params Type[] paramTypes) =>
            FunctionDictionary.Add(fn, new FuncInfo(declaringType
                .GetMethods(BindingFlags.Public | (isStatic ? BindingFlags.Static : BindingFlags.Instance))
                .Single(p => p.Name == name && p.GetParamTypes().SequenceEqual(paramTypes))));

        private static IEnumerable<Type> GetParamTypes(this MethodInfo methodInfo) => methodInfo.GetParameters().Select(p => p.ParameterType);

        private static string SayParamTypes(this FuncInfo funcInfo)
        {
            var types = funcInfo.ParamTypes;
            return types.Any() ? types.Select(p => p.Say()).Aggregate((p, q) => $"{p}, {q}") : string.Empty;
        }

        #endregion
    }
}
