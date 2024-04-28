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
                i = typeof(int),
                o = typeof(object),
                oo = typeof(object[]),
                s = typeof(string);

            Add(Fn.Compare, s, s, b);
            Add(Fn.Concat, oo);
            Add(Fn.Concat_2, "Concat", s, s);
            Add(Fn.Concat_3, "Concat", s, s, s);
            Add(Fn.Concat_4, "Concat", s, s, s, s);
            Add(Fn.Contains, s, s, b);
            Add(Fn.ContainsX, s, s, b);
            Add(Fn.Empty, s); // "IsEmpty" already used as a Tag :-(
            Add(Fn.EndsWith, s, s, b);
            Add(Fn.EndsWithX, s, s, b);
            Add(Fn.Equals, s, s, b);
            Add(Fn.EqualsX, s, s, b);
            Add(Fn.Format, s, oo);
            AddUser(Fn.If, o, paramArray: false, b, o, o);
            Add(Fn.IndexOf, s, s, b);
            Add(Fn.IndexOfX, s, s, b);
            Add(Fn.Insert, s, i, s);
            Add(Fn.Join, s, oo);
            Add(Fn.LastIndexOf, s, s, b);
            Add(Fn.LastIndexOfX, s, s, b);
            Add(Fn.Length, s);
            Add(Fn.Lower, s);
            Add(Fn.Max, d, d);
            Add(Fn.Min, d, d);
            Add(Fn.Pow, d, d);
            Add(Fn.Remove, s, i, i);
            Add(Fn.Replace, s, s, s, b);
            Add(Fn.ReplaceX, s, s, s, b);
            Add(Fn.Round, d);
            Add(Fn.Sign, d);
            Add(Fn.StartsWith, s, s, b);
            Add(Fn.StartsWithX, s, s, b);
            Add(Fn.Substring, s, i, i);
            Add(Fn.ToString, o);
            Add(Fn.Trim, s);
            Add(Fn.Truncate, d);
            Add(Fn.Upper, s);

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

        private static void AddFn(Fn fn, string name, params Type[] paramTypes) =>
            FunctorDictionary.Add(fn, new FnInfo(fn,
                typeof(Functors).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Single(p => p.Name == name && p.GetParamTypes().SequenceEqual(paramTypes))));

        private static void Add(Fn fn, params Type[] paramTypes) => Add(fn, $"{fn}", paramTypes);

        private static void Add(Fn fn, string name, params Type[] paramTypes) => AddFn(fn, name, paramTypes);

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
