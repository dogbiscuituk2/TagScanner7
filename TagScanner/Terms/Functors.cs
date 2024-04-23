namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public static class Functors
    {
        #region Static Constructor

        static Functors()
        {
            Type
                b = typeof(bool),
                c = typeof(char),
                d = typeof(double),
                i = typeof(int),
                m = typeof(Math),
                o = typeof(object),
                oo = typeof(object[]),
                r = typeof(Regex),
                s = typeof(string);

            FunctorDictionary = new Dictionary<Fn, FnInfo>();

            AddFn(Fn.Change, "Replace", s, false, s, s);
            AddFn(Fn.Compare, s, true, s, s);
            AddFn(Fn.Concat_2, "Concat", s, true, s, s);
            AddFn(Fn.Concat_3, "Concat", s, true, s, s, s);
            AddFn(Fn.Concat_4, "Concat", s, true, s, s, s, s);
            AddFn(Fn.Contains, s, false, s);
            AddFn(Fn.EndsWith, s, false, s);
            AddFn(Fn.Equals, o, false, o);
            AddFn(Fn.Format, s, true, s, oo);
            AddFn(Fn.Length, "get_Length", s, false);
            AddFn(Fn.If, null, true, b, s, s);
            AddFn(Fn.IndexOf, s, false, c);
            AddFn(Fn.Insert, s, false, i, s);
            AddFn(Fn.IsNull, "IsNullOrWhiteSpace", s, true, s); // "IsEmpty" already used as a Tag :-(
            AddFn(Fn.Match, "IsMatch", r, true, s, s, typeof(RegexOptions));
            AddFn(Fn.LastIndexOf, s, false, c);
            AddFn(Fn.Lowercase, "ToLowerInvariant", s, false);
            AddFn(Fn.Max, m, true, d, d);
            AddFn(Fn.Min, m, true, d, d);
            AddFn(Fn.Pow, m, true, d, d);
            AddFn(Fn.Remove, s, false, i, i);
            AddFn(Fn.Replace, r, true, s, s, s, typeof(RegexOptions));
            AddFn(Fn.Round, m, true, d);
            AddFn(Fn.Sign, m, true, d);
            AddFn(Fn.StartsWith, s, false, s);
            AddFn(Fn.Substring, s, false, i, i);
            AddFn(Fn.ToString, o, false);
            AddFn(Fn.ToText, null, true, s);
            AddFn(Fn.Trim, s, false);
            AddFn(Fn.Truncate, m, true, d);
            AddFn(Fn.Uppercase, "ToUpperInvariant", s, false);

            Keys = FunctorDictionary.Keys.ToArray();
            Values = FunctorDictionary.Values.ToArray();
        }

        #endregion

        #region Public Properties

        public static Fn[] Keys { get; }
        public static FnInfo[] Values { get; }

        #endregion

        #region Public Methods

        public static string GetPrototype(this Fn fn)
        {
            var fnInfo = fn.FnInfo();
            var fullName = fnInfo.IsStatic ? $"{fn}" : $"({fnInfo.DeclaringType.Say()}).{fn}";
            return $"{fnInfo.ReturnType.Say()} {fullName}({fnInfo.SayParamTypes()})";
        }

        public static FnInfo FnInfo(this Fn fn) => FunctorDictionary[fn];

        public static bool IsStatic(this Fn fn) => fn.FnInfo().IsStatic;

        public static int ParamCount(this Fn fn) => fn.FnInfo().ParamCount;

        public static Fn ToFunction(this string name) => Keys.Single(p => $"{p}" == name);

        #endregion

        #region Private Fields

        private static readonly Dictionary<Fn, FnInfo> FunctorDictionary;

        #endregion

        #region Private Methods

        private static void AddFn(Fn fn, Type declaringType, bool isStatic, params Type[] paramTypes) =>
            AddFn(fn, $"{fn}", declaringType, isStatic, paramTypes);

        private static void AddFn(Fn fn, string name, Type declaringType, bool isStatic, params Type[] paramTypes) =>
            FunctorDictionary.Add(fn, GetFn(fn, name, declaringType, isStatic, paramTypes));

        private static FnInfo GetFn(Fn fn, string name, Type declaringType, bool isStatic, params Type[] paramTypes) =>
            declaringType == null
                ? new FnInfo(fn, isStatic, paramTypes)
                : new FnInfo(fn,
                    declaringType
                        .GetMethods(BindingFlags.Public | (isStatic ? BindingFlags.Static : BindingFlags.Instance))
                        .Single(p => p.Name == name && p.GetParamTypes().SequenceEqual(paramTypes)));

        private static IEnumerable<Type> GetParamTypes(this MethodInfo methodInfo) =>
            methodInfo.GetParameters().Select(p => p.ParameterType);

        private static string SayParamTypes(this FnInfo fnInfo)
        {
            var types = fnInfo.ParamTypes;
            return types.Any() ? types.Select(p => p.Say()).Aggregate((p, q) => $"{p}, {q}") : string.Empty;
        }

        #endregion
    }
}
