namespace TagScanner.Terms
{
    using System.Linq.Expressions;
    using System.Text;

    public class DoLoop : ControlStructure
    {
        public DoLoop(params Term[] operands) : base(operands) { }

        public override Expression Expression
        {
            get
            {
                Expression
                    expression1 = Operands[0] is EmptyTerm ? Expression.Constant(true) : FirstSubExpression,
                    expression2 = SecondSubExpression,
                    expression3 = Operands[2] is EmptyTerm ? Expression.Constant(false) : ThirdSubExpression;
                LabelTarget
                    breakTarget = Expression.Label(),
                    continueTarget = Expression.Label();
                return Expression.Block(
                    Expression.Loop(
                        Expression.IfThenElse(
                            expression1,
                            Expression.Block(
                                expression2,
                                Expression.IfThen(expression3, Expression.Break(breakTarget))
                            ),
                            Expression.Break(breakTarget)
                        ),
                    breakTarget,
                    continueTarget));
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            AddText("while", 0);
            AddText("do", 1);
            AddText("until", 2);
            return result.Append(" loop").ToString();

            void AddText(string keyword, int index)
            {
                var operand = Operands[index];
                if (!(operand is EmptyTerm))
                    result.Append($"{keyword} {operand}");
            }
        }
    }
}
