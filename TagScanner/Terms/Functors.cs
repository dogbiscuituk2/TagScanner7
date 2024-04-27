namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static partial class Functors
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
                s = typeof(string);

            Add(Fn.Compare, f, s, s, b);
            Add(Fn.Concat_2, "Concat", f, s, s);
            Add(Fn.Concat_3, "Concat", f, s, s, s);
            Add(Fn.Concat_4, "Concat", f, s, s, s, s);
            Add(Fn.Contains, f, s, s, b);
            Add(Fn.ContainsX, f, s, s, b);
            Add(Fn.Empty, f, s); // "IsEmpty" already used as a Tag :-(
            Add(Fn.EndsWith, f, s, s, b);
            Add(Fn.EndsWithX, f, s, s, b);
            Add(Fn.Equals, f, s, s, b);
            Add(Fn.EqualsX, f, s, s, b);
            Add(Fn.Format, f, s, oo);
            AddUser(Fn.If, o, paramArray: false, b, o, o);
            Add(Fn.IndexOf, f, s, s, b);
            Add(Fn.IndexOfX, f, s, s, b);
            Add(Fn.Insert, f, s, i, s);
            Add(Fn.Join, s, s, oo);
            Add(Fn.LastIndexOf, f, s, s, b);
            Add(Fn.LastIndexOfX, f, s, s, b);
            Add(Fn.Length, f, s);
            Add(Fn.Lower, f, s);
            Add(Fn.Max, m, d, d);
            Add(Fn.Min, m, d, d);
            Add(Fn.Pow, m, d, d);
            Add(Fn.Remove, f, s, i, i);
            Add(Fn.Replace, f, s, s, s, b);
            Add(Fn.ReplaceX, f, s, s, s, b);
            Add(Fn.Round, m, d);
            Add(Fn.Sign, m, d);
            Add(Fn.StartsWith, f, s, s, b);
            Add(Fn.StartsWithX, f, s, s, b);
            Add(Fn.Substring, f, s, i, i);
            Add(Fn.ToString, f, o);
            AddUser(Fn.ToText, s, paramArray: true, oo);
            Add(Fn.Trim, f, s);
            Add(Fn.Truncate, m, d);
            Add(Fn.Upper, f, s);

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

        private static void Add(Fn fn, Type declaringType, params Type[] paramTypes) =>
            Add(fn, $"{fn}", declaringType, paramTypes);

        private static void Add(Fn fn, string name, Type declaringType, params Type[] paramTypes) =>
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
