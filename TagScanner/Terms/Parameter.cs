﻿namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    public class Parameter : Term
    {
        public Parameter(Type type) { _resultType = type; }

        public override Expression Expression => Expression.Default(ResultType);
        public override Type ResultType => _resultType;

        public override string ToString() => ResultType == null ? "(text/number)" : $"({ResultType.Name})";

        private readonly Type _resultType;
    }
}
