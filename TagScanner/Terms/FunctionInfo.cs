namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class FunctionInfo
    {
        public FunctionInfo(MethodInfo methodInfo) { _methodInfo = methodInfo; }

        public FunctionInfo(bool isStatic, params Type[] paramTypes)
        {
            _isStatic = isStatic;
            _paramTypes = paramTypes;
        }

        public Type DeclaringType => _methodInfo?.DeclaringType ?? typeof(object);
        public bool IsStatic => _methodInfo?.IsStatic ?? _isStatic;
        public MethodInfo MethodInfo => _methodInfo;
        public int ParamCount => _paramTypes.Length;
        public IEnumerable<Type> ParamTypes => _methodInfo != null ? _methodInfo.GetParameters().Select(p => p.ParameterType) : _paramTypes;
        public Type ReturnType => _methodInfo?.ReturnType ?? typeof(object);

        private bool _isStatic;
        private MethodInfo _methodInfo;
        private Type[] _paramTypes;
    }
}
