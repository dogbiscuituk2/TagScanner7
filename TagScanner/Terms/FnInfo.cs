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

        public FnInfo(Fn fn, MethodInfo methodInfo) : this(fn) => _methodInfo = methodInfo;

        public FnInfo(Fn fn, bool isStatic, params Type[] paramTypes) : this(fn)
        {
            _isStatic = isStatic;
            _methodInfo = null;
            _paramTypes = paramTypes;
        }

        private FnInfo(Fn fn) => _fn = fn;

        #endregion

        #region Public Properties

        public Type DeclaringType => _methodInfo?.DeclaringType ?? typeof(object);
        public bool IsStatic => _methodInfo?.IsStatic ?? _isStatic;
        public int ParamCount => _methodInfo?.GetParameters()?.Length ?? _paramTypes.Length;
        public IEnumerable<Type> ParamTypes => _methodInfo?.GetParameters().Select(p => p.ParameterType) ?? _paramTypes;
        public Type ReturnType => _methodInfo?.ReturnType ?? typeof(object);

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
                            if (operand.ResultType != typeof(string))
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
        private readonly bool _isStatic;
        private readonly MethodInfo _methodInfo;
        private readonly Type[] _paramTypes;

        #endregion
    }
}
