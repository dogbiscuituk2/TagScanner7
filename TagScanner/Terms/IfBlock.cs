namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;

    public class IfBlock : ControlStructure
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
                    return $"if {Operands[0]} then {Operands[1]} endif";
                case 3:
                    return $"if {Operands[0]} then {Operands[1]} else {Operands[2]} endif";
                default:
                    return string.Empty;
            }
        }
    }
}
