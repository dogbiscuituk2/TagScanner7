namespace TagScanner.Terms
{
    public class Program : TryBlock
    {
        public Program(Term bodyTerm) : base(bodyTerm, new[] { new Catch(typeof(StopException))}) { }
    }
}
