namespace TagScanner.Terms
{
    public class TermList : Compound
    {
        public TermList(params Term[] operands) : base(operands) { }
        public TermList(Term firstOperand, params Term[] moreOperands) : base(firstOperand, moreOperands) { }
    }
}
