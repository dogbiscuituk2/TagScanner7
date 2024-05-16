namespace TagScanner.Terms
{
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text;

    public class DoLoop : ControlStructure
    {
        public DoLoop(params Term[] operands) : base(operands) { }

        public override Expression Expression
        {
            get
            {
                var expressions = new List<Expression>();
                expressions.Add(SecondSubExpression);
                return Expression.Block(expressions);
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
