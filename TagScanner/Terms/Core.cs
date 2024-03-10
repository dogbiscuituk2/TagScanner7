namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        public static Dictionary<Operator, OperatorInfo> Operators => _operators ?? GetOperators();

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
        public static int Arity(this Operator op)
        {
            // Return int.MaxValue in the case of an associative Operator.
            switch (op)
            {
                case Operator.And:
                case Operator.Or:
                case Operator.Xor:
                case Operator.Add:
                case Operator.Subtract:
                case Operator.Multiply:
                case Operator.Divide:
                    return int.MaxValue;
            }
            // Otherwise, the Arity value is simply the number of {#} placeholders in the relevant Format string.
            var format = op.Format();
            for (var result = 0; ; result++)
                if (format.IndexOf($"{{{result}}}") < 0)
                    return result;
        }

        public static bool Associates(this Operator op) => op.Arity() == int.MaxValue;

        public static string Format(this Operator op, bool friendlyText = false)
        {
            var format = Operators[op].Format;
            if (friendlyText)
            {
                switch (op)
                {
                    case Operator.Conditional: return "if {0} then {1} else {2}";
                    case Operator.And: return format.Replace("&&", "and");
                    case Operator.Or: return format.Replace("||", "or");
                    case Operator.Xor: return format.Replace("^", "xor");
                    case Operator.EqualTo: return format.Replace("==", "=");
                    case Operator.NotEqualTo: return format.Replace("!=", "≠");
                    case Operator.NotLessThan: return format.Replace(">=", "≥");
                    case Operator.NotGreaterThan: return format.Replace("<=", "≤");
                    case Operator.Multiply: return format.Replace("*", "×");
                    case Operator.Divide: return format.Replace("/", "÷");
                    case Operator.Not: return format.Replace("!", "not ");
                }
            }
            return format;
        }

        /// <summary>
        /// A string containing either the unadorned MethodInfo name, in the case of a nonstatic member,
        /// or else the MethodInfo name qualified with its declaring type name, in the case of a nonstatic member.
        /// </summary>
        /// <param name="method">The given MethodInfo.</param>
        /// <returns>The MethodInfo name, qualified or not as appropriate.</returns>
        public static string Label(this MethodInfo method) => method.IsStatic ? $"{method.Prefix()}.{method.Name}" : method.Name;

        public static Precedence Precedence(this Operator op) => Operators[op].Precedence;

        /// <summary>
        /// A string containing the declaring type of the given MethodInfo, in the case of a nonstatic member,
        /// or else the empty string, in the case of a nonstatic member,
        /// </summary>
        /// <param name="method">The given MethodInfo.</param>
        /// <returns>The declaring type of the given MethodInfo, in the case of a nonstatic member,
        /// otherwise the empty string.</returns>
        public static string Prefix(this MethodInfo method) => method.IsStatic ? method.DeclaringType.Name : string.Empty;

        public static Type ResultType(this Operator op) => Operators[op].ResultType;
        public static string Signature(this MethodInfo method) => $"{method.Label()}({method.GetParams()})";

        #endregion

        #region Private Fields

        private static Dictionary<string, MethodInfo> _methods;
        private static Dictionary<Operator, OperatorInfo> _operators;

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
            //foreach (var method in methods)
            //    Debug.WriteLine(method.Signature());
            return methods;
        }

        private static MethodInfo[] GetMethods(Type type, BindingFlags flags) => type.GetMethods(flags).OrderBy(p => p.Signature()).ToArray();

        private static Dictionary<string, MethodInfo> GetMethods()
        {
            _methods = new Dictionary<string, MethodInfo>();
            foreach (var method in GetMethodInfos())
            {
                var signature = method.Signature();
                if (!Methods.ContainsKey(signature))
                    Methods.Add(method.Signature(), method);
            }
            return Methods;
        }

        private static Dictionary<Operator, OperatorInfo> GetOperators()
        {
            _operators = new Dictionary<Operator, OperatorInfo>
            {
                { Operator.Conditional, new OperatorInfo(null, "{0} ? {1} : {2}", Terms.Precedence.Conditional) },
                { Operator.And, new OperatorInfo(typeof(bool), "{0} && {1}", Terms.Precedence.ConditionalAND) },
                { Operator.Or, new OperatorInfo(typeof(bool),"{0} || {1}", Terms.Precedence.ConditionalOR) },
                { Operator.Xor, new OperatorInfo(typeof(bool), "{0} ^ {1}", Terms.Precedence.BitwiseXOR) },
                { Operator.EqualTo, new OperatorInfo(typeof(bool), "{0} == {1}", Terms.Precedence.Equality) },
                { Operator.NotEqualTo, new OperatorInfo(typeof(bool), "{0} != {1}", Terms.Precedence.Equality) },
                { Operator.LessThan, new OperatorInfo(typeof(bool), "{0} < {1}", Terms.Precedence.Relational) },
                { Operator.NotLessThan, new OperatorInfo(typeof(bool), "{0} >= {1}", Terms.Precedence.Relational) },
                { Operator.GreaterThan, new OperatorInfo(typeof(bool), "{0} > {1}", Terms.Precedence.Relational) },
                { Operator.NotGreaterThan, new OperatorInfo(typeof(bool), "{0} <= {1}", Terms.Precedence.Relational) },
                { Operator.Add, new OperatorInfo(null, "{0} + {1}", Terms.Precedence.Additive) },
                { Operator.Subtract, new OperatorInfo(null, "{0} - {1}", Terms.Precedence.Additive) },
                { Operator.Multiply, new OperatorInfo(null, "{0} * {1}", Terms.Precedence.Multiplicative) },
                { Operator.Divide, new OperatorInfo(null, "{0} / {1}", Terms.Precedence.Multiplicative) },
                { Operator.Positive, new OperatorInfo(null, "{0}") },
                { Operator.Negative, new OperatorInfo(null, "- {0}") },
                { Operator.Not, new OperatorInfo(typeof(bool), "!{0}") },
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
