namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;
    using System.Text;

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
                case DateTime dateTime:
                    return dateTime.ToString(dateTime.TimeOfDay.Ticks == 0 ? "[yyyy-MM-dd]" : "[yyyy-MM-dd HH:mm:ss]");
                case TimeSpan timeSpan:
                    return FormatTimeSpan(timeSpan);
                default:
                    return Value.ToString();
            }
        }

        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            var format = new StringBuilder(@"mm\:ss");
            if (timeSpan.Days > 0 || timeSpan.Hours > 0)
            {
                format.Insert(0, @"hh\:");
                if (timeSpan.Days > 0)
                    format.Insert(0, @"d\.");
            }
            if (timeSpan.Milliseconds > 0)
                format.Append(@"\.fff");
            return string.Format($@"[{{0:{format}}}]", timeSpan);
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
