namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Utils;

    public static class Functors
    {
        #region Static Constructor

        static Functors()
        {
            Type
                b = typeof(bool),
                d = typeof(double),
                f = typeof(Functors),
                i = typeof(int),
                m = typeof(Math),
                o = typeof(object),
                oo = typeof(object[]),
                s = typeof(string),
                sc = typeof(StringComparison);

            AddStatic(Fn.Compare, s, s, s, b);
            AddStatic(Fn.Concat, "Concat", s, oo);
            AddStatic(Fn.Concat_2, "Concat", s, s, s);
            AddStatic(Fn.Concat_3, "Concat", s, s, s, s);
            AddStatic(Fn.Concat_4, "Concat", s, s, s, s, s);
            AddStatic(Fn.Contains, f, s, s, b);
            AddStatic(Fn.ContainsX, f, s, s, b);
            AddMember(Fn.EndsWith, s, s, sc);
            AddMember(Fn.Equals, s, s, sc);
            AddStatic(Fn.Format, s, s, oo);
            AddUser(Fn.If, o, paramArray: false, b, o, o);
            AddMember(Fn.Length, "get_Length", s);
            AddMember(Fn.IndexOf, s, s, sc);
            AddMember(Fn.IndexOfX, f, s, b);
            AddMember(Fn.Insert, s, i, s);
            AddStatic(Fn.IsNull, "IsNullOrWhiteSpace", s, s); // "IsEmpty" already used as a Tag :-(
            AddStatic(Fn.Join, s, s, oo);
            AddMember(Fn.LastIndexOf, s, s, sc);
            AddMember(Fn.LastIndexOfX, s, s, b);
            AddMember(Fn.Lowercase, "ToLowerInvariant", s);
            AddStatic(Fn.Max, m, d, d);
            AddStatic(Fn.Min, m, d, d);
            AddStatic(Fn.Pow, m, d, d);
            AddMember(Fn.Remove, s, i, i);
            AddStatic(Fn.Replace, f, s, s, s, b);
            AddStatic(Fn.ReplaceX, f, s, s, s, b);
            AddStatic(Fn.Round, m, d);
            AddStatic(Fn.Sign, m, d);
            AddMember(Fn.StartsWith, s, s, sc);
            AddMember(Fn.Substring, s, i, i);
            AddMember(Fn.ToString, o);
            AddUser(Fn.ToText, s, paramArray: true, oo);
            AddMember(Fn.Trim, s);
            AddStatic(Fn.Truncate, m, d);
            AddMember(Fn.Uppercase, "ToUpperInvariant", s);

            Keys = FunctorDictionary.Keys.ToArray();
            Values = FunctorDictionary.Values.ToArray();
        }

        #endregion

        #region Public Properties

        public static Fn[] Keys { get; }
        public static FnInfo[] Values { get; }

        #endregion

        #region Local Functors

        public static bool Contains(this string input, string pattern, bool caseSensitive) =>
            input.ContainsX(Regex.Escape(pattern), caseSensitive);

        public static bool ContainsX(this string input, string pattern, bool caseSensitive) =>
            Regex.IsMatch(input, pattern, caseSensitive.AsRegexOptions());

        public static int IndexOfX(string input, string pattern, bool caseSensitive)
        {
            var matches = Regex.Matches(input, pattern, caseSensitive.AsRegexOptions());
            var count = matches.Count;
            return count == 0 ? -1 : matches[0].Index;
        }

        public static int LastIndexOfX(string input, string pattern, bool caseSensitive)
        {
            var matches = Regex.Matches(input, pattern, caseSensitive.AsRegexOptions());
            var count = matches.Count;
            return count == 0 ? -1 : matches[count - 1].Index;
        }

        public static string Replace(this string input, string pattern, string replacement, bool caseSensitive) =>
            input.ReplaceX(Regex.Escape(pattern), replacement, caseSensitive);

        public static string ReplaceX(this string input, string pattern, string replacement, bool caseSensitive) =>
            Regex.Replace(input, pattern, replacement, caseSensitive.AsRegexOptions());

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
        public static bool ParamArray(this Fn fn) => fn.FnInfo().ParamArray;
        public static int ParamCount(this Fn fn) => fn.FnInfo().ParamCount;
        public static Type[] ParamTypes(this Fn fn) => fn.FnInfo().ParamTypes;
        public static Type ResultType(this Fn fn) => fn.FnInfo().ReturnType;
        public static Fn ToFunction(this string name) => Keys.Single(p => $"{p}" == name);

        #endregion

        #region Private Fields

        private static readonly Dictionary<Fn, FnInfo> FunctorDictionary = new Dictionary<Fn, FnInfo>();

        #endregion

        #region Private Methods

        private static void AddFn(Fn fn, string name, Type declaringType, bool isStatic, params Type[] paramTypes) =>
            FunctorDictionary.Add(fn, new FnInfo(fn,
                declaringType.GetMethods(BindingFlags.Public | (isStatic ? BindingFlags.Static : BindingFlags.Instance))
                .Single(p => p.Name == name && p.GetParamTypes().SequenceEqual(paramTypes))));

        private static void AddMember(Fn fn, Type declaringType, params Type[] paramTypes) =>
            AddMember(fn, $"{fn}", declaringType, paramTypes);

        private static void AddMember(Fn fn, string name, Type declaringType, params Type[] paramTypes) =>
            AddFn(fn, name, declaringType, isStatic: false, paramTypes);

        private static void AddStatic(Fn fn, Type declaringType, params Type[] paramTypes) =>
            AddStatic(fn, $"{fn}", declaringType, paramTypes);

        private static void AddStatic(Fn fn, string name, Type declaringType, params Type[] paramTypes) =>
            AddFn(fn, name, declaringType, isStatic: true, paramTypes);

        private static void AddUser(Fn fn, Type returnType, bool paramArray, params Type[] paramTypes) =>
            FunctorDictionary.Add(fn, new FnInfo(fn, returnType, paramArray, paramTypes));

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
