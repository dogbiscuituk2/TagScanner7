namespace TagScanner.Terms
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class Cast : Compound
    {
        public Cast(Type newType) => SetNewType(newType);
        public Cast(Type newType, Term operand) : base(operand) => SetNewType(newType);

        public Type NewType { get; set; }

        public override Expression Expression
        {
            get
            {
                Type
                    sourceType = Operands[0].ResultType,
                    targetType = ResultType;
                if (sourceType == typeof(string))
                {
                    foreach (var type in new[] { typeof(int), typeof(double), typeof(long), typeof(uint), typeof(float), typeof(ulong), typeof(decimal) })
                        if (targetType == type)
                            return Expression.Call(type.GetMethod("Parse", new[] { sourceType }), FirstSubExpression);
                }
                return Expression.Convert(FirstSubExpression, targetType);
            }
        }

        public override bool IsInfinitary => false;
        public override Rank Rank => Rank.Unary;
        public override Type ResultType => NewType;

        public override int Start(int index) => ResultType.Say().Length + (UseParens(0) ? 3 : 2);
        public override string ToString() => $"({ResultType.Say()}){WrapTerm(0)}";
        protected override bool UseParens(int index) => Operands.First().Rank < Rank.Unary;

        private void SetNewType(Type newType) => NewType = newType;
    }
}
