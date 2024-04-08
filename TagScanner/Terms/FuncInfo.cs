namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class FuncInfo
    {
        public FuncInfo(MethodInfo methodInfo) { _methodInfo = methodInfo; }

        public FuncInfo(Fn fn, bool isStatic, params Type[] paramTypes)
        {
            _isStatic = isStatic;
            _methodInfo = null;
            _fn = fn;
            _paramTypes = paramTypes;
        }

        public Type DeclaringType => _methodInfo?.DeclaringType ?? typeof(object);
        public Fn Fn => _fn;
        public bool IsStatic => _methodInfo?.IsStatic ?? _isStatic;
        public string Name => _fn.ToString();
        public int ParamCount => _methodInfo?.GetParameters()?.Length ?? _paramTypes.Length;
        public IEnumerable<Type> ParamTypes => _methodInfo != null ? _methodInfo.GetParameters().Select(p => p.ParameterType) : _paramTypes;
        public Type ReturnType => _methodInfo?.ReturnType ?? typeof(object);

        public Expression GetExpression(List<Term> operands)
        {
            var expressions = operands.Select(p => p.Expression).ToList();
            if (_methodInfo != null)
                return IsStatic
                    ? Expression.Call(_methodInfo, expressions)
                    : Expression.Call(expressions[0], _methodInfo, expressions.Skip(1));
            switch (Fn)
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
                            operand = new Function("ToString", operand);
                            expressions[index] = operand.Expression;
                        }
                        if (index > 0)
                            newOperands.Add(newLine);
                        newOperands.Add(operand);
                    }
                    return new Concatenation(newOperands.ToArray()).Expression;
            }
            return null;
        }

        private readonly bool _isStatic;
        private readonly MethodInfo _methodInfo;
        private readonly Fn _fn;
        private readonly Type[] _paramTypes;
    }
}
