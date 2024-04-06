﻿namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class Function : TermList
    {
        #region Constructors

        public Function(string name, params Term[] operands) : base(operands) => SetName(name);
        public Function(Term self, string name, params Term[] operands) : base(self, operands) => SetName(name);

        #endregion

        #region Public Properties

        public FuncInfo FuncInfo
        {
            get => _funcInfo ?? (_funcInfo = Name.FuncInfo());
            set
            {
                _funcInfo = value;
                AddParameters(ParameterTypes.ToArray());
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                FuncInfo = Name.FuncInfo();
                AddParameters(GetParameterTypes().ToArray());
            }
        }

        public override int Arity => FuncInfo.ParamCount + (IsStatic ? 0 : 1);
        public override Expression Expression => GetExpression();
        public bool IsStatic => FuncInfo.IsStatic;
        public override Type ResultType => FuncInfo.ReturnType;

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
                yield return FuncInfo.DeclaringType;
            foreach (var paramType in FuncInfo.ParamTypes)
                yield return paramType;
        }

        protected override bool UseParens(int index) => !IsStatic && index == 0 && Operands.First().Rank < Rank.Unary;

        #endregion

        #region Private Fields

        private FuncInfo _funcInfo;
        private string _name;

        #endregion

        #region Private Methods

        private Expression GetExpression() => FuncInfo.GetExpression(Operands);

        private void SetName(string name)
        {
            _name = name;
            FuncInfo = Name.FuncInfo();
        }

        #endregion
    }

    #region Derived Function Classes

    public class Conditional : Function
    {
        public Conditional(Term condition, Term consequent, Term alternative)
            : base("If", condition, consequent, alternative) { }
    }

    #endregion
}
