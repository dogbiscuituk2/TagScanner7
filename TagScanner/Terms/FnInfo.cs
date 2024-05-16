namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class FnInfo
    {
        #region Constructors

        public FnInfo(Fn fn, Type returnType, bool isInfinitary, params Type[] operandTypes) : this(fn)
        {
            IsInfinitary = isInfinitary;
            OperandCount = operandTypes.Length;
            OperandTypes = operandTypes;
            ReturnType = returnType;
        }

        public FnInfo(Fn fn, MethodInfo methodInfo) : this(fn)
        {
            _methodInfo = methodInfo;
            var operands = _methodInfo.GetParameters();
            IsInfinitary = operands.LastOrDefault()?.GetCustomAttribute(typeof(ParamArrayAttribute)) != null;
            OperandCount = operands.Length;
            OperandTypes = operands.Select(p => p.ParameterType).ToArray();
            ReturnType = _methodInfo.ReturnType;
        }

        private FnInfo(Fn fn) => _fn = fn;

        #endregion

        #region Public Properties

        public bool IsInfinitary { get; }
        public int OperandCount { get; }
        public Type[] OperandTypes { get; }
        public Type ReturnType { get; }

        #endregion

        public Expression GetExpression(List<Term> operands)
        {
            var expressions = operands.Select(p => p.Expression).ToList();
            switch (_fn)
            {
                case Fn.Iif:
                    return Expression.Condition(expressions[0], expressions[1], expressions[2]);
                case Fn.Concat:
                    return Expression.Call(
                        _methodInfo,
                        Expression.NewArrayInit(typeof(object), expressions));
                case Fn.Format:
                case Fn.Join:
                    return Expression.Call(
                        _methodInfo,
                        expressions.First(),
                        Expression.NewArrayInit(typeof(object), expressions.Skip(1).Select(p => Expression.Convert(p, typeof(object)))));
            }
            return Expression.Call(_methodInfo, expressions);
        }

        #region Private Fields

        private readonly Fn _fn;
        private readonly MethodInfo _methodInfo;

        #endregion
    }
}
