namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public class Variable : Term
    {
        public Variable(string name) : base() { Name = name; }

        public string Name { get; }
        public object Value { get; set; }

        public override Expression Expression => Expression.Variable(typeof(object), Name);

        public override string ToString() => Name;
    }
}
