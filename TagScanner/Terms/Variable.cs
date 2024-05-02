namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public class Variable : Term
    {
        public Variable(string name) : base()
        {
            Name = name;
            _expression = Expression.Parameter(typeof(object), name);
        }

        public string Name { get; }
        public object Value { get; set; }

        private Expression _expression;

        public override Expression Expression => _expression;

        public override string ToString() => Name;
    }
}
