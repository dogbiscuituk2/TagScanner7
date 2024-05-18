namespace TagScanner.Terms
{
    public class TryBlock : ControlStructure
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
