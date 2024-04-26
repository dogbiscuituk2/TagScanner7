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

        public FnInfo(Fn fn, Type returnType, bool paramArray, params Type[] paramTypes) : this(fn)
        {
            DeclaringType = typeof(object);
            IsStatic = true;
            ParamArray = paramArray;
            ParamCount = paramTypes.Length;
            ParamTypes = paramTypes;
            ReturnType = returnType;
        }

        public FnInfo(Fn fn, MethodInfo methodInfo) : this(fn)
        {
            _methodInfo = methodInfo;
            var parameters = _methodInfo.GetParameters();
            DeclaringType = _methodInfo.DeclaringType;
            IsStatic = _methodInfo.IsStatic;
            ParamArray = parameters.LastOrDefault()?.GetCustomAttribute(typeof(ParamArrayAttribute)) != null;
            ParamCount = parameters.Length;
            ParamTypes = parameters.Select(p => p.ParameterType).ToArray();
            ReturnType = _methodInfo.ReturnType;
        }

        private FnInfo(Fn fn) => _fn = fn;

        #endregion

        #region Public Properties

        public Type DeclaringType { get; }
        public bool IsStatic { get; }
        public bool ParamArray { get; }
        public int ParamCount { get; }
        public Type[] ParamTypes { get; }
        public Type ReturnType { get; }

        #endregion

        public Expression GetExpression(List<Term> operands)
        {
            var expressions = operands.Select(p => p.Expression).ToList();
            if (_methodInfo == null)
                switch (_fn)
                {
                    case Fn.If:
                        return Expression.Condition(expressions[0], expressions[1], expressions[2]);
                    case Fn.ToText:
                        var newOperands = new List<Term>();
                        var newLine = new Constant<string>(Environment.NewLine);
                        for (var index = 0; index < operands.Count; index++)
                        {
                            var operand = operands[index];
                            var operandType = operand.ResultType;
                            if (operandType != typeof(string))
                            {
                                operand = new Function(Fn.ToString, operand);
                                expressions[index] = operand.Expression;
                            }
                            if (index > 0)
                                newOperands.Add(newLine);
                            newOperands.Add(operand);
                        }
                        return new Concatenation(newOperands.ToArray()).Expression;
                    default:
                        return null;
                }
            if (IsStatic)
                return Expression.Call(_methodInfo, expressions);
            return Expression.Call(expressions[0], _methodInfo, expressions.Skip(1));
        }

        #region Private Fields

        private readonly Fn _fn;
        private readonly MethodInfo _methodInfo;

        #endregion
    }
}
