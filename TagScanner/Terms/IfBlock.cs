namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    public class IfBlock : Compound
    {
        public IfBlock(params Term[] operands) : base(operands) { }

        public override Expression Expression
        {
            get
            {
                switch (Operands.Count)
                {
                    case 2:
                        return Expression.IfThen(FirstSubExpression, SecondSubExpression);
                    case 3:
                        return Expression.IfThenElse(FirstSubExpression, SecondSubExpression, ThirdSubExpression);
                    default:
                        throw new ArgumentException($"Incorrect number of arguments: expected: 2 or 3, actual: {Operands.Count}");
                }
            }
        }

        public override string ToString()
        {
            switch (Operands.Count)
            {
                case 2:
                    return $"{Keywords.If} {Operands[0]} {Keywords.Then} {Operands[1]} {Keywords.End}";
                case 3:
                    return $"{Keywords.If} {Operands[0]} {Keywords.Then} {Operands[1]} {Keywords.Else} {Operands[2]} {Keywords.End}";
                default:
                    return string.Empty;
            }
        }
    }
}
