namespace TagScanner.Terms
{
    using System.Text;

    public class Block : Compound
    {
        public Block(params Term[] operands) : base(operands) { }
        public Block(Term firstOperand, params Term[] moreOperands) : base(firstOperand, moreOperands) { }

        public override string ToString()
        {
            var result = new StringBuilder();
            var count = Operands.Count;
            for (var index = 0; index < count; index++)
            {
                var term = Operands[index];
                result.Append(term);
                if (index < count - 1)
                    result.Append(term is Label ? " " : "; ");
            }
            return result.ToString();
        }
    }
}
