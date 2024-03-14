using TagScanner.Models;

namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public static class Core
    {
        #region Public Properties

        public static MethodDictionary Methods => _methodDictionary ?? GetMethods();
        public static OperatorDictionary Operators => _operatorDictionary ?? GetOperators();
        public static TagDictionary Tags => _tagDictionary ?? GetTags();

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
                case Op.Concatenate:
                case Op.Add:
                case Op.Subtract:
                case Op.Multiply:
                case Op.Divide:
                    return int.MaxValue;
            }

            // Otherwise, the Arity value is simply the number of {#} placeholders in the relevant Format string.
            var format = op.Format();
            for (var result = 0;; result++)
                if (format.IndexOf($"{{{result}}}") < 0)
                    return result;
        }

        public static bool Associates(this Op op) => op.Arity() == int.MaxValue;
        public static bool CanChain(this Op op) => op == Op.EqualTo || op.GetRank() == Rank.Relational;
        public static ExpressionType ExpType(this Op op) => Operators[op].ExpType;
        public static string Format(this Op op) => Operators[op].Format;
        public static Rank GetRank(this Op op) => Operators[op].Rank;
        public static Type ResultType(this Op op) => Operators[op].ResultType;

        public static string Say(this Type type)
        {
            if (type.IsArray)
                return $"{type.GetElementType().Say()}[]";
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

        #endregion

        #region Private Fields

        private static MethodDictionary _methodDictionary;
        private static OperatorDictionary _operatorDictionary;
        private static TagDictionary _tagDictionary;

        #endregion

        #region Private Methods

        private static MethodDictionary GetMethods() => _methodDictionary = new MethodDictionary
        {
            { "Compare", FindMethodInfo(typeof(string), true, "Compare", typeof(string), typeof(string)) },
            { "Concat_2", FindMethodInfo(typeof(string), true, "Concat", typeof(string), typeof(string)) },
            { "Concat_3", FindMethodInfo(typeof(string), true, "Concat", typeof(string), typeof(string), typeof(string)) },
            { "Concat_4", FindMethodInfo(typeof(string), true, "Concat", typeof(string), typeof(string), typeof(string), typeof(string)) },
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

        private static MethodInfo FindMethodInfo(Type declaringType, bool isStatic, string name,
            params Type[] paramTypes) => declaringType
            .GetMethods(BindingFlags.Public | (isStatic ? BindingFlags.Static : BindingFlags.Instance))
            .Single(p => p.Name == name && p.GetParamTypes().SequenceEqual(paramTypes));

        private static OperatorDictionary GetOperators() => _operatorDictionary = new OperatorDictionary
        {
            { Op.Conditional, new OpInfo("if-then-else", ExpressionType.Conditional, Rank.Conditional, typeof(object), "if {0} then {1} else {2}", new[] { typeof(bool), typeof(object) }) },
            { Op.And, new OpInfo("and", ExpressionType.AndAlso, Rank.ConditionalAnd, typeof(bool), "{0} and {1}") },
            { Op.Or, new OpInfo("or", ExpressionType.OrElse, Rank.ConditionalOr, typeof(bool), "{0} or {1}") },
            { Op.Xor, new OpInfo("exclusive or", ExpressionType.ExclusiveOr, Rank.BitwiseXor, typeof(bool), "{0} xor {1}") },
            { Op.EqualTo, new OpInfo("=", ExpressionType.Equal, Rank.Equality, typeof(bool), "{0} = {1}", typeof(object)) },
            { Op.NotEqualTo, new OpInfo("≠", ExpressionType.NotEqual, Rank.Equality, typeof(bool), "{0} ≠ {1}", typeof(object)) },
            { Op.LessThan, new OpInfo("<", ExpressionType.LessThan, Rank.Relational, typeof(bool), "{0} < {1}", typeof(double)) },
            { Op.NotLessThan, new OpInfo("≥", ExpressionType.GreaterThanOrEqual, Rank.Relational, typeof(bool), "{0} ≥ {1}", typeof(double)) },
            { Op.GreaterThan, new OpInfo(">", ExpressionType.GreaterThan, Rank.Relational, typeof(bool), "{0} > {1}", typeof(double)) },
            { Op.NotGreaterThan, new OpInfo("≤", ExpressionType.LessThanOrEqual, Rank.Relational, typeof(bool), "{0} ≤ {1}", typeof(double)) },
            { Op.Concatenate, new OpInfo("＋", ExpressionType.Add, Rank.Additive, typeof(string), "{0} ＋ {1}") },
            { Op.Add, new OpInfo("＋", ExpressionType.Add, Rank.Additive, typeof(double), "{0} ＋ {1}") },
            { Op.Subtract, new OpInfo("－", ExpressionType.Subtract, Rank.Additive, typeof(double), "{0} － {1}") },
            { Op.Multiply, new OpInfo("✕", ExpressionType.Multiply, Rank.Multiplicative, typeof(double), "{0} ✕ {1}") },
            { Op.Divide, new OpInfo("／", ExpressionType.Divide, Rank.Multiplicative, typeof(double), "{0} ／ {1}") },
            { Op.Positive, new OpInfo("＋", ExpressionType.UnaryPlus, Rank.Unary, typeof(double), "＋{0}") },
            { Op.Negative, new OpInfo("－", ExpressionType.Negate, Rank.Unary, typeof(double), "－{0}") },
            { Op.Not, new OpInfo("not", ExpressionType.Not, Rank.Unary, typeof(bool), "not {0}") },
        };

        private static IEnumerable<string> GetParamTypeNames(this MethodInfo method) =>
            method.GetParamTypes().Select(t => t.Name);

        private static IEnumerable<Type> GetParamTypes(this MethodInfo method) =>
            method.GetParameters().Select(p => p.ParameterType);

        private static string GetParams(this MethodInfo method)
        {
            var names = method.GetParamTypeNames();
            return names.Any() ? names.Aggregate((p, q) => $"{p}, {q}") : string.Empty;
        }

        private static TagDictionary GetTags()
        {
            _tagDictionary = new TagDictionary();
            var props = typeof(Selection).GetProperties();
            foreach (Tag tag in Enum.GetValues(typeof(Tag)))
            {
                var name = tag.ToString();
                var prop = props.Single(p => p.Name == name);
                var category = GetCategory(name);
                if (category == Selection.Selected)
                    continue;
                var tagProps = new TagProps
                {
                    Browsable = GetBrowsable(name),
                    CanRead = prop.CanRead,
                    CanWrite = prop.CanWrite,
                    Category = category,
                    Column = GetColumn(name),
                    Details = GetDescription(name),
                    DirectUses = GetDirectUses(name),
                    DisplayName = GetDisplayName(name),
                    FrequentlyUsed = GetFrequentlyUsed(name),
                    Name = name,
                    ReadOnly = GetReadOnly(name),
                    Type = prop.PropertyType,
                };
                tagProps.AdjustAlignment();
                _tagDictionary.Add(tag, tagProps);
            }
            return _tagDictionary;
        }

        private static bool GetBrowsable(string name) => (bool)UseField(name, typeof(BrowsableAttribute), "browsable");
        private static string GetCategory(string name) => (string)UseField(name, typeof(CategoryAttribute), "categoryValue");
        private static Column GetColumn(string name) => (Column)UseField(name, typeof(ColumnAttribute), "_column");
        private static string GetDescription(string name) => (string)UseField(name, typeof(DescriptionAttribute), "description");
        private static string GetDisplayName(string name) => (string)UseField(name, typeof(DisplayNameAttribute), "_displayName");
        private static bool GetFrequentlyUsed(string name) => (bool)UseField(name, typeof(FrequentlyUsedAttribute), "_frequentlyUsed");
        private static bool GetReadOnly(string name) => (bool)UseField(name, typeof(ReadOnlyAttribute), "isReadOnly");
        private static IEnumerable<string> GetDirectUses(string name) => (IEnumerable<string>)UseField(name, typeof(UsesAttribute), "_propertyNames");
        private static object UseField(string name, Type attrType, string field, object value = null) => typeof(Selection).UseField(name, attrType, field, value);

        public static object UseField(this Type type, string propName, Type attrType, string field, object value = null)
        {
            var attr = TypeDescriptor.GetProperties(type)[propName].Attributes[attrType];
            var info = attrType.GetField(field, BindingFlags.NonPublic | BindingFlags.Instance);
            if (value == null)
                value = info?.GetValue(attr);
            else
                info?.SetValue(attr, value);
            return value;
        }

        private static void SetBrowsable(string name, bool value)
        {
            var property = name.GetProps();
            if (property.Browsable != value)
            {
                UseField(name, typeof(BrowsableAttribute), "browsable", value);
                property.Browsable = value;
            }
        }

        #endregion
    }

    #region Utility Classes

    public class MethodDictionary : Dictionary<string, MethodInfo> { }
    public class OperatorDictionary : Dictionary<Op, OpInfo> { }
    public class TagDictionary : Dictionary<Tag, TagProps> { public TagProps this[string name] => this[(Tag)Enum.Parse(typeof(Tag), name)]; }

    #endregion
}
