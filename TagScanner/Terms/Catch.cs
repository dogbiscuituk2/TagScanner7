namespace TagScanner.Terms
{
    using System;

    public class Catch
    {
        public Catch() : this(null, null, null) { }
        public Catch(Type exceptionType) : this(exceptionType, null, null) { }
        public Catch(Type exceptionType, Term bodyTerm) : this(exceptionType, null, bodyTerm) { }
        public Catch(Type exceptionType, Variable variable, Term bodyTerm)
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
