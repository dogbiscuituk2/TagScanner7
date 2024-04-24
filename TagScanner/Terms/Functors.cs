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

            const bool mem = false, stat = true;

            AddMemberFn(Fn.Change, "Replace", s, s, s);
            AddStaticFn(Fn.Compare, s, s, s);
            AddStaticFn(Fn.Concat_2, "Concat", s, s, s);
            AddStaticFn(Fn.Concat_3, "Concat", s, s, s, s);
            AddStaticFn(Fn.Concat_4, "Concat", s, s, s, s, s);
            AddMemberFn(Fn.Contains, s, s);
            AddMemberFn(Fn.EndsWith, s, s);
            AddMemberFn(Fn.Equals, o, o);
            AddStaticFn(Fn.Format, s, s, oo);

            AddFn(Fn.If, o, paramArray: false, b, s, s);

            AddMemberFn(Fn.Length, "get_Length", s);
            AddMemberFn(Fn.IndexOf, s, c);
            AddMemberFn(Fn.Insert, s, i, s);
            AddStaticFn(Fn.IsNull, "IsNullOrWhiteSpace", s, s); // "IsEmpty" already used as a Tag :-(
            AddStaticFn(Fn.Join, s, s, oo);
            AddMemberFn(Fn.LastIndexOf, s, c);
            AddMemberFn(Fn.Lowercase, "ToLowerInvariant", s);
            AddStaticFn(Fn.Match, "IsMatch", r, s, s, typeof(RegexOptions));
            AddStaticFn(Fn.Max, m, d, d);
            AddStaticFn(Fn.Min, m, d, d);
            AddStaticFn(Fn.Pow, m, d, d);
            AddMemberFn(Fn.Remove, s, i, i);
            AddStaticFn(Fn.Replace, r, s, s, s, typeof(RegexOptions));
            AddStaticFn(Fn.Round, m, d);
            AddStaticFn(Fn.Sign, m, d);
            AddMemberFn(Fn.StartsWith, s, s);
            AddMemberFn(Fn.Substring, s, i, i);
            AddMemberFn(Fn.ToString, o);

            AddFn(Fn.ToText, s, paramArray: true, oo);

            AddMemberFn(Fn.Trim, s,);
            AddStaticFn(Fn.Truncate, m, d);
            AddMemberFn(Fn.Uppercase, "ToUpperInvariant", s);

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

        private static void AddFn(Fn fn, Type returnType, bool paramArray, params Type[] paramTypes) =>
            FunctorDictionary.Add(fn, new FnInfo(fn, returnType, paramArray, paramTypes));

        private static void AddMemberFn(Fn fn, Type declaringType, params Type[] paramTypes) =>
            AddMemberFn(fn, $"{fn}", declaringType, paramTypes);

        private static void AddMemberFn(Fn fn, string name, Type declaringType, params Type[] paramTypes) =>
            AddFn(fn, name, declaringType, paramTypes);

        private static void AddStaticFn(Fn fn, Type declaringType, params Type[] paramTypes) =>
            AddStaticFn(fn, $"{fn}", declaringType, paramTypes);

        private static void AddStaticFn(Fn fn, string name, Type declaringType, params Type[] paramTypes) =>
            AddFn(fn, name, declaringType, paramTypes);

        private static void AddFn(Fn fn, string name, Type declaringType, bool isStatic, params Type[] paramTypes) =>
            FunctorDictionary.Add(fn, new FnInfo(fn,
                declaringType.GetMethods(BindingFlags.Public | (isStatic ? BindingFlags.Static : BindingFlags.Instance))
                .Single(p => p.Name == name && p.GetParamTypes().SequenceEqual(paramTypes))));

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
