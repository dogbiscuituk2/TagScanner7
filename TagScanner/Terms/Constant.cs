﻿namespace TagScanner.Terms
{
    using Newtonsoft.Json;
    using System;
    using System.Linq.Expressions;
    using System.Text;
    using System.Xml.Serialization;

    [Serializable]
    public class Constant<T> : Term
    {
        public Constant() { }
        public Constant(T value) { Value = value; }

        public T Value { get; set; }

        [JsonIgnore, XmlIgnore] public override Expression Expression => Expression.Constant(Value);

        public override Type ResultType => typeof(T);

        private static string FormatDateTime(DateTime dateTime)
        {
            var format = new StringBuilder("yyyy-MM-dd");
            var timeSpan = dateTime.TimeOfDay;
            if (timeSpan.Ticks > 0)
            {
                format.Append(" HH:mm:ss");
                if (timeSpan.Milliseconds > 0)
                    format.Append(".fff");
            }
            return dateTime.ToString($"[{format}]");
        }

        private static string FormatTimeSpan(TimeSpan timeSpan)
        {
            var format = new StringBuilder(@"hh\:mm\:ss");
            if (timeSpan.Days > 0)
                format.Insert(0, @"d\.");
            if (timeSpan.Milliseconds > 0)
                format.Append(@"\.fff");
            return string.Format($"[{{0:{format}}}]", timeSpan);
        }

        public override string ToString()
        {
            if (Value == null) return "(?)";
            if (ResultType == typeof(bool)) return Value.ToString().ToLower();
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
                    return FormatDateTime(dateTime);
                case TimeSpan timeSpan:
                    return FormatTimeSpan(timeSpan);
                default:
                    return Value.ToString();
            }
        }
    }
}
