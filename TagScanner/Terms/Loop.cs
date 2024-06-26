﻿namespace TagScanner.Terms
{
    using System.Linq.Expressions;
    using System.Text;

    public class Loop : Compound
    {
        public Loop(params Term[] operands) : base(operands) { }

        public override Expression Expression
        {
            get
            {
                Expression
                    expression1 = Operands[0] is EmptyTerm ? Expression.Constant(true) : FirstSubExpression,
                    expression2 = SecondSubExpression,
                    expression3 = Operands[2] is EmptyTerm ? Expression.Constant(false) : ThirdSubExpression;
                return Expression.Block(
                    Expression.Loop(
                        Expression.IfThenElse(
                            expression1,
                            Expression.Block(
                                expression2,
                                Expression.IfThen(expression3, Expression.Break(BreakTarget))
                            ),
                            Expression.Break(BreakTarget)
                        ),
                    BreakTarget,
                    ContinueTarget));
            }
        }

        public LabelTarget BreakTarget { get; } = Expression.Label();
        public LabelTarget ContinueTarget { get; } = Expression.Label();

        public override string ToString()
        {
            var result = new StringBuilder();
            AddText(Keywords.While, 0);
            AddText(Keywords.Do, 1);
            AddText(Keywords.Until, 2);
            return result.Append(Keywords.End).ToString();

            void AddText(string keyword, int index)
            {
                var operand = Operands[index];
                if (!(operand is EmptyTerm))
                    result.Append($"{keyword} {operand} ");
            }
        }
    }
}
