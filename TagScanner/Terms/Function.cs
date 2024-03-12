namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    [Serializable]
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

        public override string ToString()
        {
            var result = Name;
            var skip = 0;
            if (!Method.IsStatic)
            {
                result = $"{WrapTerm(0)}.{result}";
                skip = 1;
            }
            var count = Operands.Count;
            if (count <= skip)
                return result;
            var operands = Operands.Skip(skip).Select(p => p.ToString()).Aggregate((p, q) => $"{p}, {q}");
            return $"{result}({operands})";
        }

        #endregion

        #region Protected Methods

        protected override IEnumerable<Type> GetParameterTypes()
        {
            if (!Method.IsStatic)
                yield return Method.DeclaringType;
            foreach (var foo in Method.GetParameters())
                yield return foo.ParameterType;
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
