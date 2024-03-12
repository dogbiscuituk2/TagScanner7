namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public static class Core
    {
        #region Static Constructor

        static Core() => ResetDefaults();

        #endregion

        #region Public Fields

        public static bool MinimiseParentheses;
        public static string ParamName;

        public static IEnumerable<KeyValuePair<string, MethodInfo>>
            StringMethods = Methods.Where(p => !p.Value.IsStatic).OrderBy(p => p.Key),
            StringStatics = Methods.Where(p => p.Value.Prefix() == "String").OrderBy(p => p.Key),
            RegexStatics = Methods.Where(p => p.Value.Prefix() == "Regex").OrderBy(p => p.Key),
            MathStatics = Methods.Where(p => p.Value.Prefix() == "Math").OrderBy(p => p.Key);

        #endregion

        #region Public Properties

        public static Dictionary<string, MethodInfo> Methods => _methods ?? GetMethods();
        public static Dictionary<Op, OpInfo> Operators => _operators ?? GetOperators();

        #endregion

        #region Public Methods

        public static void ResetDefaults()
        {
            MinimiseParentheses = true;
            ParamName = "T";
        }

        #endregion

        #region Public Extension Methods

        /// <summary>
        /// Calculate the Arity of an Operator, method call, or function; i.e., the number of parameters it expects.
        /// </summary>
        /// <param name="op">The given Operator, method call, or function.</param>
        /// <returns>An integer representing the number of parameters expected by the Operator, method call, or function.
        /// Note: int.MaxValue is returned for associative operators && || ^ + - * / since these can accept any number of parameters.</returns>
        public static int Arity(this Op op)
        {
            // Return int.MaxValue in the case of an associative Operator.
            switch (op)
            {
                case Op.And:
                case Op.Or:
                //case Op.Xor:
                case Op.Add:
                case Op.Subtract:
                case Op.Multiply:
                case Op.Divide:
                    return int.MaxValue;
            }
            // Otherwise, the Arity value is simply the number of {#} placeholders in the relevant Format string.
            var format = op.Format();
            for (var result = 0; ; result++)
                if (format.IndexOf($"{{{result}}}") < 0)
                    return result;
        }

        public static bool Associates(this Op op) => op.Arity() == int.MaxValue;
        public static bool CanChain(this Op op) => op == Op.EqualTo || op.GetRank() == Rank.Relational;

        public static ExpressionType ExpType(this Op op) => Operators[op].ExpType;

        public static string Format(this Op op) => Operators[op].Format;
        public static Rank GetRank(this Op op) => Operators[op].Rank;

        /// <summary>
        /// A string containing either the unadorned MethodInfo name, in the case of a nonstatic member,
        /// or else the MethodInfo name qualified with its declaring type name, in the case of a nonstatic member.
        /// </summary>
        /// <param name="method">The given MethodInfo.</param>
        /// <returns>The MethodInfo name, qualified or not as appropriate.</returns>
        public static string Label(this MethodInfo method) => method.IsStatic ? $"{method.Prefix()}.{method.Name}" : method.Name;

        /// <summary>
        /// A string containing the declaring type of the given MethodInfo, in the case of a nonstatic member,
        /// or else the empty string, in the case of a nonstatic member,
        /// </summary>
        /// <param name="method">The given MethodInfo.</param>
        /// <returns>The declaring type of the given MethodInfo, in the case of a nonstatic member,
        /// otherwise the empty string.</returns>
        public static string Prefix(this MethodInfo method) => method.IsStatic ? method.DeclaringType.Name : string.Empty;

        public static Type ResultType(this Op op) => Operators[op].ResultType;

        public static string Say(this Type type)
        {
            if (type.IsArray)
                return $"{type.GetElementType().Say()}[]";
            if (type == typeof(Number))
                return "number";
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean: return "condition";
                case TypeCode.Char: return "character";
                case TypeCode.Double: return "number";
                case TypeCode.Int32: return "integer";
                case TypeCode.Int64: return "long";
                case TypeCode.Object: return "this";
                case TypeCode.String: return "string";
                default: return type.Name;
            }
        }

        public static string Signature(this MethodInfo method) => $"{method.Label()}({method.GetParams()})";

        #endregion

        #region Private Fields

        private static Dictionary<string, MethodInfo> _methods;
        private static Dictionary<Op, OpInfo> _operators;

        #endregion

        #region Private Methods

        private static List<MethodInfo> GetMethodInfos()
        {
            const BindingFlags
                instances = BindingFlags.Instance | BindingFlags.Public,
                statics = BindingFlags.Static | BindingFlags.Public;
            var methods = new List<MethodInfo>();
            methods.AddRange(GetMethods(typeof(string), instances));
            methods.AddRange(GetMethods(typeof(string), statics));
            methods.AddRange(GetMethods(typeof(Regex), statics));
            methods.AddRange(GetMethods(typeof(Math), statics));
            foreach (var method in methods)
                System.Diagnostics.Debug.WriteLine(method.Signature());
            return methods;
        }

        private static IEnumerable<MethodInfo> GetMethods(Type type, BindingFlags flags) => type.GetMethods(flags).OrderBy(p => p.Signature());

        private static Dictionary<string, MethodInfo> GetMethods()
        {
            _methods = new Dictionary<string, MethodInfo>
            {
                { "Compare", FindMethodInfo(typeof(string), true, "Compare", typeof(string), typeof(string)) },
                { "Contains", FindMethodInfo(typeof(string), false, "Contains", typeof(string)) },
                { "EndsWith", FindMethodInfo(typeof(string), false, "EndsWith", typeof(string)) },
                { "Equals", FindMethodInfo(typeof(object), false, "Equals", typeof(object)) },
                { "Format", FindMethodInfo(typeof(string), true, "Format", typeof(string), typeof(object[])) },
                { "Length", FindMethodInfo(typeof(string), false, "get_Length") },
                { "IndexOf", FindMethodInfo(typeof(string), false, "IndexOf", typeof(char)) },
                { "Insert", FindMethodInfo(typeof(string), false, "Insert", typeof(int), typeof(string)) },
                { "IsEmpty", FindMethodInfo(typeof(string), true, "IsNullOrWhiteSpace", typeof(string)) },
                { "Match$", FindMethodInfo(typeof(Regex), true, "IsMatch", typeof(string), typeof(string)) },
                { "LastIndexOf", FindMethodInfo(typeof(string), false, "LastIndexOf", typeof(char)) },
                { "Lowercase", FindMethodInfo(typeof(string), false, "ToLowerInvariant") },
                { "Max", FindMethodInfo(typeof(Math), true, "Max", typeof(double), typeof(double)) },
                { "Min", FindMethodInfo(typeof(Math), true, "Min", typeof(double), typeof(double)) },
                { "Power", FindMethodInfo(typeof(Math), true, "Pow", typeof(double), typeof(double)) },
                { "Remove", FindMethodInfo(typeof(string), false, "Remove", typeof(int), typeof(int)) },
                { "Replace", FindMethodInfo(typeof(string), false, "Replace", typeof(string), typeof(string)) },
                { "Replace$", FindMethodInfo(typeof(Regex), true, "Replace", typeof(string), typeof(string), typeof(string)) },
                { "Round", FindMethodInfo(typeof(Math), true, "Round", typeof(double)) },
                { "Sign", FindMethodInfo(typeof(Math), true, "Sign", typeof(double)) },
                { "StartsWith", FindMethodInfo(typeof(string), false, "StartsWith", typeof(string)) },
                { "Substring", FindMethodInfo(typeof(string), false, "Substring", typeof(int), typeof(int)) },
                { "ToString", FindMethodInfo(typeof(object), false, "ToString") },
                { "Trim", FindMethodInfo(typeof(string), false, "Trim") },
                { "Truncate", FindMethodInfo(typeof(Math), true, "Truncate", typeof(double)) },
                { "Uppercase", FindMethodInfo(typeof(string), false, "ToUpperInvariant") },
            };
            return Methods;
        }

        private static MethodInfo FindMethodInfo(Type declaringType, bool isStatic, string name, params Type[] paramTypes) => declaringType
            .GetMethods(BindingFlags.Public | (isStatic ? BindingFlags.Static : BindingFlags.Instance))
            .Where(p => p.Name == name && p.GetParamTypes().SequenceEqual(paramTypes))
            .Single();

        private static MethodInfo GetMethod(string signature) => null;

        private static Dictionary<Op, OpInfo> GetOperators()
        {
            _operators = new Dictionary<Op, OpInfo>
            {
                { Op.Conditional, new OpInfo("if-then-else", ExpressionType.Conditional, Rank.Conditional, typeof(object), "if {0} then {1} else {2}", new[]{ typeof(bool), typeof(object) }) },
                { Op.And, new OpInfo("and", ExpressionType.AndAlso, Rank.ConditionalAND, typeof(bool), "{0} and {1}") },
                { Op.Or, new OpInfo("or", ExpressionType.OrElse, Rank.ConditionalOR, typeof(bool),"{0} or {1}") },
                { Op.Xor, new OpInfo("exclusive or", ExpressionType.ExclusiveOr, Rank.BitwiseXOR, typeof(bool), "{0} xor {1}") },
                { Op.EqualTo, new OpInfo("=", ExpressionType.Equal, Rank.Equality, typeof(bool), "{0} = {1}", typeof(object)) },
                { Op.NotEqualTo, new OpInfo("≠", ExpressionType.NotEqual, Rank.Equality, typeof(bool), "{0} ≠ {1}", typeof(object)) },
                { Op.LessThan, new OpInfo("<", ExpressionType.LessThan, Rank.Relational, typeof(bool), "{0} < {1}", typeof(Number)) },
                { Op.NotLessThan, new OpInfo("≥", ExpressionType.GreaterThanOrEqual, Rank.Relational, typeof(bool), "{0} ≥ {1}", typeof(Number)) },
                { Op.GreaterThan, new OpInfo(">", ExpressionType.GreaterThan, Rank.Relational, typeof(bool), "{0} > {1}", typeof(Number)) },
                { Op.NotGreaterThan, new OpInfo("≤", ExpressionType.LessThanOrEqual, Rank.Relational, typeof(bool), "{0} ≤ {1}", typeof(Number)) },
                { Op.Concatenate, new OpInfo("＋", ExpressionType.Add, Rank.Additive, typeof(string), "{0} ＋ {1}") },
                { Op.Add, new OpInfo("＋",ExpressionType.Add, Rank.Additive, typeof(Number), "{0} ＋ {1}") },
                { Op.Subtract, new OpInfo("－", ExpressionType.Subtract, Rank.Additive, typeof(Number), "{0} － {1}") },
                { Op.Multiply, new OpInfo("✕", ExpressionType.Multiply, Rank.Multiplicative, typeof(Number), "{0} ✕ {1}") },
                { Op.Divide, new OpInfo("／", ExpressionType.Divide, Rank.Multiplicative, typeof(Number), "{0} ／ {1}") },
                { Op.Positive, new OpInfo("＋", ExpressionType.UnaryPlus, Rank.Unary, typeof(Number), "＋{0}") },
                { Op.Negative, new OpInfo("－", ExpressionType.Negate, Rank.Unary, typeof(Number), "－{0}") },
                { Op.Not, new OpInfo("not", ExpressionType.Not, Rank.Unary, typeof(bool), "not {0}") },
            };
            return Operators;
        }

        private static IEnumerable<string> GetParamTypeNames(this MethodInfo method) => method.GetParamTypes().Select(t => t.Name);
        private static IEnumerable<Type> GetParamTypes(this MethodInfo method) => method.GetParameters().Select(p => p.ParameterType);

        private static string GetParams(this MethodInfo method)
        {
            var names = method.GetParamTypeNames();
            return names.Any() ? names.Aggregate((p, q) => $"{p}, {q}") : string.Empty;
        }

        #endregion
    }
}
