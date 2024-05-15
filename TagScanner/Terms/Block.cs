﻿namespace TagScanner.Terms
{
    public class Block : Compound
    {
        public Block(params Term[] operands) : base(operands) { }
        public Block(Term firstOperand, params Term[] moreOperands) : base(firstOperand, moreOperands) { }

        public override string ToString() => ToString("{0}; {1}", unary: false);
    }
}
