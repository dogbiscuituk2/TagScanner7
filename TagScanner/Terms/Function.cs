namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;

    public class Function : Umptad
    {
        #region Constructors

        public Function(string signature, params Term[] operands) : base(operands) { Signature = signature; }
        public Function(Term self, string signature, params Term[] operands) : base(self, operands) { Signature = signature; }

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

        public string Prototype => $"{Method.ReturnType.Name} {Signature}";

        public string Signature
        {
            get => _signature;
            set
            {
                _signature = value;
                Method = Core.Methods[Signature];
                AddParameters(GetParameterTypes().ToArray());
            }
        }

        public override int Arity => Method.GetParameters().Length + (Method.IsStatic ? 0 : 1);
        public override Expression Expression => GetExpression();
        public override Type ResultType => Method.ReturnType;

        #endregion

        #region Protected Methods

        protected override IEnumerable<Type> GetParameterTypes()
        {
            if (!Method.IsStatic)
                yield return Method.DeclaringType;
            var s = Signature;
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
        private string _signature;

        #endregion                  l

        #region Private Methods

        private Expression GetExpression()
        {
            var expressions = (Method.IsStatic ? Operands : Operands.Skip(1)).Select(p => p.Expression).ToArray();
            return Method.IsStatic
                ? Expression.Call(Method, expressions)
                : Expression.Call(FirstOperand, Method, expressions);
        }

        #endregion
    }
}
