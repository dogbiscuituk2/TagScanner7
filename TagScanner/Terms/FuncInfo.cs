﻿namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class FuncInfo
    {
        public FuncInfo(MethodInfo methodInfo) { _methodInfo = methodInfo; }

        public FuncInfo(string name, bool isStatic, params Type[] paramTypes)
        {
            _isStatic = isStatic;
            _methodInfo = null;
            _name = name;
            _paramTypes = paramTypes;
        }

        public Type DeclaringType => _methodInfo?.DeclaringType ?? typeof(object);
        public bool IsStatic => _methodInfo?.IsStatic ?? _isStatic;
        public int ParamCount => _methodInfo?.GetParameters()?.Length ?? _paramTypes.Length;
        public IEnumerable<Type> ParamTypes => _methodInfo != null ? _methodInfo.GetParameters().Select(p => p.ParameterType) : _paramTypes;
        public Type ReturnType => _methodInfo?.ReturnType ?? typeof(object);

        public Expression GetExpression(IEnumerable<Term> operands)
        {
            var expressions = operands.Select(p => p.Expression).ToList();
            if (_methodInfo != null)
                return IsStatic
                    ? Expression.Call(_methodInfo, expressions)
                    : Expression.Call(expressions[0], _methodInfo, expressions.Skip(1));
            switch (_name)
            {
                case "If": return Expression.Condition(expressions[0], expressions[1], expressions[2]);
            }
            return null;
        }

        private readonly bool _isStatic;
        private readonly MethodInfo _methodInfo;
        private readonly string _name;
        private readonly Type[] _paramTypes;
    }
}
