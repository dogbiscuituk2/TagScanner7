namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using TagScanner.Utils;

    public class Conditional : Operation
    {
        public Conditional(Term test, Term ifTrue, Term ifFalse) : base(Op.Else, test, ifTrue, ifFalse) { }

        public override Expression Expression => Expression.Condition(FirstSubExpression, SecondSubExpression, ThirdSubExpression);

        public override Type ResultType => Utility.GetCompatibleType(Operands.Skip(1).Select(p => p.ResultType).ToArray());

        public override string ToString() => $"{Operands[0]} ? {Operands[1]} : {Operands[2]}";

        protected override IEnumerable<Type> GetOperandTypes() => new[] { typeof(bool), typeof(object), typeof(object) };
    }
}
