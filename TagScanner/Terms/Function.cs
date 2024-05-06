﻿namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using TagScanner.Utils;

    public class Function : TermList
    {
        #region Constructors

        /// <summary>
        /// Constructor for static function instances (including user functions with no MethodInfo).
        /// </summary>
        /// <param name="fn">The functor specifier.</param>
        /// <param name="operands">The arguments to the function.</param>
        public Function(Fn fn, params Term[] operands) : base(operands) => SetFn(fn);

        /// <summary>
        /// Constructor for member function instances.
        /// </summary>
        /// <param name="self">The instance supplying the membver function implementation.</param>
        /// <param name="fn">The functor specifier.</param>
        /// <param name="operands">The remaining arguments to the function.</param>
        public Function(Term self, Fn fn, params Term[] operands) : this(fn, new[] { self }.Union(operands).ToArray()) { }

        #endregion

        #region Public Properties

        public FnInfo FnInfo
        {
            get => _fnInfo ?? (_fnInfo = Fn.FnInfo());
            set => _fnInfo = value;
        }

        public Fn Fn
        {
            get => _fn;
            set
            {
                _fn = value;
                FnInfo = Fn.FnInfo();
            }
        }

        public override Expression Expression => GetExpression();
        public override bool IsInfinitary => FnInfo.IsInfinitary;
        public string Name => $"{Fn}";
        public override Op Op => Op.None;

        public override Type ResultType
        {
            get
            {
                switch (Fn)
                {
                    case Fn.If:
                        return Utility.GetCommonType(Operands[1].ResultType, Operands[2].ResultType);
                    default:
                        return FnInfo.ReturnType;
                }
            }
        }

        #endregion

        #region Public Methods

        public override int Start(int index) =>
            index == 0 ? Name.Length + 1 : Start(index - 1) + Operands[index - 1].Length + 2;

        public override string ToString()
        {
            var result = Name;
            var skip = 0;
            var count = Operands.Count;
            if (count <= skip)
                return result;
            var operands = Operands.Skip(skip).Select(p => p.ToString()).Aggregate((p, q) => $"{p}, {q}");
            return $"{result}({operands})";
        }

        #endregion

        #region Protected Methods

        protected override IEnumerable<Type> GetOperandTypes()
        {
            foreach (var type in FnInfo.OperandTypes)
                yield return type;
        }

        protected override bool UseParens(int index) => false;

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
