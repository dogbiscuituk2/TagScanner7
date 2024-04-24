namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class Function : TermList
    {
        #region Constructors

        public Function(Fn fn, params Term[] operands) : base(operands) => SetFn(fn);
        public Function(Term self, Fn fn, params Term[] operands) : this(fn, new[] { self }.Union(operands).ToArray()) { }

        #endregion

        #region Public Properties

        public FnInfo FnInfo
        {
            get => _fnInfo ?? (_fnInfo = Fn.FnInfo());
            set
            {
                _fnInfo = value;
                InitParameters(ParameterTypes.ToArray());
            }
        }

        public Fn Fn
        {
            get => _fn;
            set
            {
                _fn = value;
                FnInfo = Fn.FnInfo();
                InitParameters(GetParameterTypes().ToArray());
            }
        }

        public override int Arity => FnInfo.ParamCount + (IsStatic ? 0 : 1);
        public override Expression Expression => GetExpression();
        public bool IsStatic => FnInfo.IsStatic;
        public string Name => $"{Fn}";
        public override Type ResultType => FnInfo.ReturnType;

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
                yield return FnInfo.DeclaringType;
            foreach (var paramType in FnInfo.ParamTypes)
                yield return paramType;
        }

        protected override bool UseParens(int index) => !IsStatic && index == 0 && Operands.First().Rank < Rank.Unary;

        #endregion

        #region Private Fields

        private Fn _fn;
        private FnInfo _fnInfo;

        #endregion

        #region Private Methods

        private Expression GetExpression() => FnInfo.GetExpression(Operands);

        private void SetFn(Fn fn)
        {
            _fn = fn;
            FnInfo = Fn.FnInfo();
            var paramTypes = ParameterTypes.ToList();
            var operandsCount = Operands.Count;
            for (var index = 0; index < operandsCount; index++)
            {
                var operand = Operands[index];
                var operandType = operand.ResultType;
                var paramType = paramTypes[Math.Min(index, operandsCount - 1)];
                if (operandType != paramType)
                    Operands[index] = new Cast(paramType, operand);
            }
        }

        #endregion
    }

    #region Derived Function Classes

    public class Conditional : Function
    {
        public Conditional(Term condition, Term consequent, Term alternative)
            : base(Fn.If, condition, consequent, alternative) { }
    }

    #endregion
}
