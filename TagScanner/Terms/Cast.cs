namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class Cast : TermList
    {
        public Cast(Type newType) => SetNewType(newType);
        public Cast(Type newType, Term operand) : base(operand) => SetNewType(newType);

        public Type NewType { get; set; }

        public override Expression Expression => Expression.Convert(FirstSubExpression, ResultType);
        public override bool IsInfinitary => false;
        public override Rank Rank => Rank.Unary;
        public override Type ResultType => NewType;

        public override int Start(int index) => ResultType.Say().Length + (UseParens(0) ? 3 : 2);
        public override string ToString() => $"({ResultType.Say()}){WrapTerm(0)}";
        protected override bool UseParens(int index) => Operands.First().Rank < Rank.Unary;

        private void SetNewType(Type newType) => NewType = newType;
    }
}
