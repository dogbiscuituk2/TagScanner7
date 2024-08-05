namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Core;

    public class Conditional : Operation
    {
        #region Constructor

        public Conditional(Term test, Term ifTrue, Term ifFalse) : base(Op.Else, test, ifTrue, ifFalse) { }

        #endregion

        #region Public Properties

        public override Expression Expression => Expression.Condition(FirstSubExpression, SecondSubExpression, ThirdSubExpression);
        public override Type ResultType => Operands.Skip(1).Select(p => p.ResultType).ToArray().GetCompatibleType();

        #endregion

        #region Public Methods

        public override string ToString() => $"{Operands[0]} ? {Operands[1]} : {Operands[2]}";

        #endregion

        #region Protected Methods

        protected override IEnumerable<Type> GetOperandTypes() => new[] { typeof(bool), typeof(object), typeof(object) };

        #endregion
    }
}
