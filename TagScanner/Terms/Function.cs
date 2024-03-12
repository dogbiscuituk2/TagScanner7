namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class Function : Umptad
    {
        #region Constructors

        public Function(string name, params Term[] operands) : base(operands) => SetName(name);
        public Function(Term self, string name, params Term[] operands) : base(self, operands) => SetName(name);

        #endregion

        #region Public Properties

        public MethodInfo Method
        {
            get => _method;
            set
            {
                _method = value;
                AddParameters(ParameterTypes.ToArray());
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Method = Core.Methods[Name];
                AddParameters(GetParameterTypes().ToArray());
            }
        }

        public override int Arity => Method.GetParameters().Length + (Method.IsStatic ? 0 : 1);
        public override Expression Expression => GetExpression();
        public override Type ResultType => Method.ReturnType;

        #endregion

        #region Public Methods

        public override string ToString() => 

        #endregion

        #region Protected Methods

        protected override IEnumerable<Type> GetParameterTypes()
        {
            if (!Method.IsStatic)
                yield return Method.DeclaringType;
            var s = Name;
            int
                m = s.IndexOf('(') + 1,
                n = s.Length - m - 1;
            if (n > 0)
                foreach (var type in s.Substring(m, n).Split(',').Select(p => GetType(p.Trim())))
                    yield return type;
        }
    
        #endregion

        #region Private Fields

        private MethodInfo _method;
        private string _name;

        #endregion

        #region Private Methods

        private Expression GetExpression()
        {
            var expressions = (Method.IsStatic ? Operands : Operands.Skip(1)).Select(p => p.Expression).ToArray();
            return Method.IsStatic
                ? Expression.Call(Method, expressions)
                : Expression.Call(FirstOperand, Method, expressions);
        }

        private void SetName(string name)
        {
            _name = name;
            Method = Core.Methods[name];
        }

        #endregion
    }
}
