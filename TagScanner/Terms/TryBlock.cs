namespace TagScanner.Terms
{
    public class TryBlock : Compound
    {
        public TryBlock(Term tryTerm, Term finallyterm, params CatchBlock[] catchBlocks) : base()
        {
            TryTerm = tryTerm;
            CatchBlocks = catchBlocks;
            FinallyTerm = FinallyTerm;
        }

        public Term TryTerm { get; private set; }
        public CatchBlock[] CatchBlocks { get; private set; }
        public Term FinallyTerm { get; private set; }
    }
}
