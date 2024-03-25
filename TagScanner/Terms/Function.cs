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
            get => _method ?? (_method = Name.MethodInfo());
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
                Method = Name.MethodInfo();
                AddParameters(GetParameterTypes().ToArray());
            }
        }

        public override int Arity => Method.GetParameters().Length + (IsStatic ? 0 : 1);
        public override Expression Expression => GetExpression();
        public bool IsStatic => Method.IsStatic;
        public override Type ResultType => Method.ReturnType;

        #endregion

        #region Public Methods

        public override int Start(int index)
        {
            switch (IsStatic)
            {
                case true when index == 0:
                    return Name.Length + 1;
                case false:
                {
                    var up = UseParens(0);
                    switch (index)
                    {
                        case 0: return up ? 1 : 0;
                        case 1: return Operands.First().Length + Name.Length + (up ? 4 : 2);
                    }
                    break;
                }
            }
            return Start(index - 1) + Operands[index - 1].Length + 2;
        }

        public override string ToString()
        {
            var result = Name;
            var skip = 0;
            if (!IsStatic)
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
            if (!IsStatic)
                yield return Method.DeclaringType;
            foreach (var foo in Method.GetParameters())
                yield return foo.ParameterType;
        }

        protected override bool UseParens(int index) => !IsStatic && index == 0 && Operands.First().Rank < Rank.Unary;

        #endregion

        #region Private Fields

        [NonSerialized]
        private MethodInfo _method;

        private string _name;

        #endregion

        #region Private Methods

        private Expression GetExpression()
        {
            var expressions = (IsStatic ? Operands : Operands.Skip(1)).Select(p => p.Expression).ToArray();
            return IsStatic
                ? Expression.Call(Method, expressions)
                : Expression.Call(FirstSubExpression, Method, expressions);
        }

        private void SetName(string name)
        {
            _name = name;
            Method = Name.MethodInfo();
        }

        #endregion
    }
}
