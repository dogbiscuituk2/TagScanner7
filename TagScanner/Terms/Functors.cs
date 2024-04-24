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
                ro = typeof(RegexOptions),
                s = typeof(string);

            AddMember(Fn.Change, "Replace", s, s, s);
            AddStatic(Fn.Compare, s, s, s);
            AddStatic(Fn.Concat_2, "Concat", s, s, s);
            AddStatic(Fn.Concat_3, "Concat", s, s, s, s);
            AddStatic(Fn.Concat_4, "Concat", s, s, s, s, s);
            AddMember(Fn.Contains, s, s);
            AddMember(Fn.EndsWith, s, s);
            AddMember(Fn.Equals, o, o);
            AddStatic(Fn.Format, s, s, oo);
            AddUser(Fn.If, o, paramArray: false, b, o, o);
            AddMember(Fn.Length, "get_Length", s);
            AddMember(Fn.IndexOf, s, c);
            AddMember(Fn.Insert, s, i, s);
            AddStatic(Fn.IsNull, "IsNullOrWhiteSpace", s, s); // "IsEmpty" already used as a Tag :-(
            AddStatic(Fn.Join, s, s, oo);
            AddMember(Fn.LastIndexOf, s, c);
            AddMember(Fn.Lowercase, "ToLowerInvariant", s);
            AddStatic(Fn.Match, "IsMatch", r, s, s, ro);
            AddStatic(Fn.Max, m, d, d);
            AddStatic(Fn.Min, m, d, d);
            AddStatic(Fn.Pow, m, d, d);
            AddMember(Fn.Remove, s, i, i);
            AddStatic(Fn.Replace, r, s, s, s, ro);
            AddStatic(Fn.Round, m, d);
            AddStatic(Fn.Sign, m, d);
            AddMember(Fn.StartsWith, s, s);
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
