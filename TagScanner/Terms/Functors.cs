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
            Add(Fn.Count, s, s, b);
            Add(Fn.CountX, s, s, b);
            Add(Fn.Empty, s); // "IsEmpty" already used as a Tag :-(
            Add(Fn.EndsWith, s, s, b);
            Add(Fn.EndsWithX, s, s, b);
            Add(Fn.Equals, s, s, b);
            Add(Fn.EqualsX, s, s, b);
            Add(Fn.Format, s, oo);
            AddUser(Fn.Iif, o, isInfinitary: false, b, o, o);
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
            Add(Fn.Print, oo);
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

            Keys = _functors.Keys.ToArray();
            Values = _functors.Values.ToArray();
        }

        #endregion

        #region Public Properties

        public static Fn[] Keys { get; }
        public static FnInfo[] Values { get; }
        public static IEnumerable<string> FunctionNames => Keys.Select(fn => $"{fn}");

        #endregion

        #region Public Methods

        public static string GetPrototype(this Fn fn)
        {
            var fnInfo = fn.FnInfo();
            return $"{fnInfo.ReturnType.Say()} {fn}({fnInfo.SayOperandTypes()})";
        }

        public static FnInfo FnInfo(this Fn fn) => _functors[fn];
        public static bool IsInfinitary(this Fn fn) => fn.FnInfo().IsInfinitary;
        public static int OperandCount(this Fn fn) => fn.FnInfo().OperandCount;
        public static Type[] OperandTypes(this Fn fn) => fn.FnInfo().OperandTypes;
        public static Type ResultType(this Fn fn) => fn.FnInfo().ReturnType;
        public static Fn ToFunction(this string name) => (Fn)Enum.Parse(typeof(Fn), name);

        #endregion

        #region Private Fields

        private static readonly Dictionary<Fn, FnInfo> _functors = new Dictionary<Fn, FnInfo>();

        #endregion

        #region Private Methods

        private static void AddFn(Fn fn, string name, params Type[] operandTypes) =>
            _functors.Add(fn, new FnInfo(fn,
                typeof(Functors).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Single(p => p.Name == name && p.GetOperandTypes().SequenceEqual(operandTypes))));

        private static void Add(Fn fn, params Type[] operandTypes) => Add(fn, $"{fn}", operandTypes);

        private static void Add(Fn fn, string name, params Type[] operandTypes) => AddFn(fn, name, operandTypes);

        private static void AddUser(Fn fn, Type returnType, bool isInfinitary, params Type[] operandTypes) =>
            _functors.Add(fn, new FnInfo(fn, returnType, isInfinitary, operandTypes));

        private static IEnumerable<Type> GetOperandTypes(this MethodInfo methodInfo) =>
            methodInfo.GetParameters().Select(p => p.ParameterType);

        private static string SayOperandTypes(this FnInfo fnInfo)
        {
            var types = fnInfo.OperandTypes;
            return types.Any() ? types.Select(p => p.Say()).Aggregate((p, q) => $"{p}, {q}") : string.Empty;
        }

        #endregion
    }
}
