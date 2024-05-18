namespace TagScanner.Terms
{
    using System;

    public class CatchBlock
    {
        public CatchBlock(Type exceptionType, Variable variable, Term bodyTerm)
        {
            ExceptionType = exceptionType;
            Variable = variable;
            BodyTerm = bodyTerm;
        }

        public Type ExceptionType { get; private set; }
        public Variable Variable { get; private set; }
        public Term BodyTerm { get; private set; }
    }
}
