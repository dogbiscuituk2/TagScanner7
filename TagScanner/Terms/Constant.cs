namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    [Serializable]
    public class Constant : Term
    {
        public Constant(object value = null) { Value = value; }

        public object Value { get; set; }

        public override Expression Expression => Expression.Constant(Value);
        public override Type ResultType => Value?.GetType();

        public override string ToString()
        {
            if (Value == null) return "(?)";
            if (ResultType == typeof(bool)) return (bool)Value ? "true" : "false";
            if (ResultType == typeof(char)) return $"'{Value}'";
            if (ResultType == typeof(double)) return $"{Value}D";
            if (ResultType == typeof(decimal)) return $"{Value}M";
            if (ResultType == typeof(float)) return $"{Value}F";
            if (ResultType == typeof(int)) return $"{Value}";
            if (ResultType == typeof(long)) return $"{Value}L";
            if (ResultType == typeof(string)) return $"\"{Value}\"";
            if (ResultType == typeof(uint)) return $"{Value}U";
            if (ResultType == typeof(ulong)) return $"{Value}UL";
            switch (Value)
            {
                case DateTime _:
                    return $"DateTime.Parse(\"{Value}\")";
                case TimeSpan _:
                    return $"TimeSpan.Parse(\"{Value}\")";
                default:
                    return Value.ToString();
            }
        }

        [NonSerialized]
        public static readonly Constant
            Empty = new Constant(string.Empty),
            False = new Constant(false),
            Nothing = new Constant(null),
            True = new Constant(true),
            Zero = new Constant(0);
    }
}
