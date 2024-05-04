namespace TagScanner.Terms
{
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System;
    using System.Linq.Expressions;

    public class Variable : Term
    {
        #region Constructor

        public Variable(string name) : base() { Name = name; }

        #endregion

        #region Private Fields

        private Expression _expression = null;

        #endregion

        #region Public Properties

        public override Expression Expression
        {
            get
            {
                if (ResultType == null)
                    throw new TypeAccessException();
                if (_expression == null)
                {
                    _expression = Expression.Parameter(ResultType, Name);
                    if (ResultType.IsAssignableFrom(typeof(int)))
                        Expression.Assign(_expression, Expression.Constant(0));
                    else if (ResultType.IsAssignableFrom(typeof(string)))
                        Expression.Assign(_expression, Expression.Constant(string.Empty));
                }
                return _expression;
            }
        }

        public string Name { get; }
        public override Type ResultType { get; set; } = null;

        #endregion

        #region Public Methods

        public override string ToString() => Name;

        #endregion
    }
}
