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

        public int IndexOfParams => IsInfinitary ? OperandCount - 1 : -1;
        public bool IsInfinitary { get; }
        public int OperandCount { get; }
        public Type[] OperandTypes { get; }
        public Type ReturnType { get; }

        #endregion

        public Expression GetExpression(List<Term> operands)
        {
            var exps = operands.Select(p => p.Expression).ToList();
            if (_fn == Fn.IfThenElse)
                return Expression.Condition(exps[0], exps[1], exps[2]);
            var fix = _fn.IndexOfParams();
            if (fix < 0)
                return Expression.Call(_methodInfo, exps);
            var args = exps.Take(fix).ToList();
            args.Add(Expression.NewArrayInit(typeof(object), exps.Skip(fix).Select(p => Expression.ConvertChecked(p, typeof(object)))));
            return Expression.Call(_methodInfo, args);
        }

        #region Private Fields

        private readonly Fn _fn;
        private readonly MethodInfo _methodInfo;

        #endregion
    }
}
