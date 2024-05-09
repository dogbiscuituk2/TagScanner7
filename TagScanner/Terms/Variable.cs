namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class Variable : Term
    {
        #region Constructor

        public Variable(string name) : base() { Name = name; }

        public Variable(string name, Type type) : this(name)
        {
            ResultType = type;
        }

        #endregion

        #region Private Fields

        private Expression _expression = null;

        #endregion

        #region Public Properties

        public override Expression Expression =>
            ResultType == null
            ? throw new TypeAccessException()
            : _expression ?? (_expression = Expression.Parameter(ResultType, Name));

        public string Name { get; }

        public override IEnumerable<ParameterExpression> Parameters =>
            base.Parameters.Union(new[] { (ParameterExpression)Expression });

        public override Type ResultType { get; set; } = null;

        #endregion

        #region Public Methods

        public override string ToString() => Name;

        #endregion
    }
}
