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
            FunctionDictionary = new Dictionary<Fn, FuncInfo>();
            AddFn(Fn.Compare, typeof(string), true, typeof(string), typeof(string));
            AddFn(Fn.Concat_2, "Concat", typeof(string), true, typeof(string), typeof(string));
            AddFn(Fn.Concat_3, "Concat", typeof(string), true, typeof(string), typeof(string), typeof(string));
            AddFn(Fn.Concat_4, "Concat", typeof(string), true, typeof(string), typeof(string), typeof(string), typeof(string));
            AddFn(Fn.Contains, typeof(string), false, typeof(string));
            AddFn(Fn.EndsWith, typeof(string), false, typeof(string));
            AddFn(Fn.Equals, typeof(object), false, typeof(object));
            AddFn(Fn.Format, typeof(string), true, typeof(string), typeof(object[]));
            AddFn(Fn.Length, "get_Length", typeof(string), false);
            AddFn(Fn.If, null, true, typeof(bool), typeof(string), typeof(string));
            AddFn(Fn.IndexOf, typeof(string), false, typeof(char));
            AddFn(Fn.Insert, typeof(string), false, typeof(int), typeof(string));
            AddFn(Fn.IsNull, "IsNullOrWhiteSpace", typeof(string), true, typeof(string)); // "IsEmpty" already used as a Tag :-(
            AddFn(Fn.Match_, "IsMatch", typeof(Regex), true, typeof(string), typeof(string));
            AddFn(Fn.LastIndexOf, typeof(string), false, typeof(char));
            AddFn(Fn.Lowercase, "ToLowerInvariant", typeof(string), false);
            AddFn(Fn.Max, typeof(Math), true, typeof(double), typeof(double));
            AddFn(Fn.Min, typeof(Math), true, typeof(double), typeof(double));
            AddFn(Fn.Pow, typeof(Math), true, typeof(double), typeof(double));
            AddFn(Fn.Remove, typeof(string), false, typeof(int), typeof(int));
            AddFn(Fn.Replace, typeof(string), false, typeof(string), typeof(string));
            AddFn(Fn.Replace_, "Replace", typeof(Regex), true, typeof(string), typeof(string), typeof(string));
            AddFn(Fn.Round, typeof(Math), true, typeof(double));
            AddFn(Fn.Sign, typeof(Math), true, typeof(double));
            AddFn(Fn.StartsWith, typeof(string), false, typeof(string));
            AddFn(Fn.Substring, typeof(string), false, typeof(int), typeof(int));
            AddFn(Fn.ToString, typeof(object), false);
            AddFn(Fn.ToText, null, true, typeof(string));
            AddFn(Fn.Trim, typeof(string), false);
            AddFn(Fn.Truncate, typeof(Math), true, typeof(double));
            AddFn(Fn.Uppercase, "ToUpperInvariant", typeof(string), false);
            Keys = FunctionDictionary.Keys.ToArray();
            Values = FunctionDictionary.Values.ToArray();
        }

        #endregion

        #region Public Properties

        public static Fn[] Keys { get; }
        public static FuncInfo[] Values { get; }

        #endregion

        #region Public Methods

        public static string GetPrototype(this Fn fn)
        {
            var funcInfo = fn.FuncInfo();
            var fullName = funcInfo.IsStatic ? $"{fn}" : $"({funcInfo.DeclaringType.Say()}).{fn}";
            return $"{funcInfo.ReturnType.Say()} {fullName}({funcInfo.SayParamTypes()})";
        }

        public static FuncInfo FuncInfo(this Fn fn) => FunctionDictionary[fn];

        public static bool IsStatic(this Fn fn) => fn.FuncInfo().IsStatic;

        public static int ParamCount(this Fn fn) => fn.FuncInfo().ParamCount;

        public static Fn ToFunction(this string name) => Keys.Single(p => $"{p}" == name);

        #endregion

        #region Private Fields

        private static readonly Dictionary<Fn, FuncInfo> FunctionDictionary;

        #endregion

        #region Private Methods

        private static void AddFn(Fn fn, Type declaringType, bool isStatic, params Type[] paramTypes) =>
            AddFn(fn, $"{fn}", declaringType, isStatic, paramTypes);

        private static void AddFn(Fn fn, string name, Type declaringType, bool isStatic, params Type[] paramTypes) =>
            FunctionDictionary.Add(fn, GetFn(fn, name, declaringType, isStatic, paramTypes));

        private static FuncInfo GetFn(Fn fn, string name, Type declaringType, bool isStatic, params Type[] paramTypes) =>
            declaringType == null
                ? new FuncInfo(fn, isStatic, paramTypes)
                : new FuncInfo(fn,
                    declaringType
                        .GetMethods(BindingFlags.Public | (isStatic ? BindingFlags.Static : BindingFlags.Instance))
                        .Single(p => p.Name == name && p.GetParamTypes().SequenceEqual(paramTypes)));

        private static IEnumerable<Type> GetParamTypes(this MethodInfo methodInfo) =>
            methodInfo.GetParameters().Select(p => p.ParameterType);

        private static string SayParamTypes(this FuncInfo funcInfo)
        {
            var types = funcInfo.ParamTypes;
            return types.Any() ? types.Select(p => p.Say()).Aggregate((p, q) => $"{p}, {q}") : string.Empty;
        }

        #endregion
    }
}
