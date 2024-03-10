namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    public class Constant : Term
    {
        public Constant(object value = null) { Value = value; }

        public object Value { get; set; }

        public override Expression Expression => Expression.Constant(Value);
        public override Precedence Precedence => Precedence.Unary;
        public override Type ResultType => Value?.GetType();

        public override string ToString()
        {
            if (Value == null) return "(?)";
            if (ResultType == typeof(bool)) return (bool)Value ? "true" : "false";
            if (ResultType == typeof(char)) return $"'{Value}'";
            if (ResultType == typeof(string)) return $"\"{Value}\"";
            if (Value is DateTime) return $"DateTime.Parse(\"{Value}\")";
            if (Value is TimeSpan) return $"TimeSpan.Parse(\"{Value}\")";
            return Value?.ToString();
        }

        public static readonly Constant
            Empty = new Constant(string.Empty),
            False = new Constant(false),
            Nothing = new Constant(null),
            True = new Constant(true),
            Zero = new Constant(0);
    }
}
