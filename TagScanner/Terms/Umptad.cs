namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text.RegularExpressions;

    /// <summary>
    /// By analogy with monadic, dyadic, triadic, tetradic etc. operators, which accept respectively
    /// 1, 2, 3 or 4 operands, an "umptadic" operator accepts "umpteen" (i.e., any number of) operands.
    /// The "Umptad" class therefore represents an expression built from such an operator.
    /// It is used as the common functionality base for the Function and Operation term types.
    /// </summary>
    [Serializable]
    public abstract class Umptad : Term
    {
        #region Constructors

        protected Umptad(IEnumerable<Term> operands) : base() => AddOperands(operands);
        protected Umptad(Term firstOperand, IEnumerable<Term> moreOperands) : this(new[] { firstOperand }) => AddOperands(moreOperands);

        #endregion

        #region Public Properties

        public abstract int Arity { get; }
        public List<Term> Operands { get; } = new List<Term>();
        public IEnumerable<Type> ParameterTypes => GetParameterTypes();

        #endregion

        #region Public Methods

        public override IEnumerable<CharacterRange> GetRanges(bool all)
        {
            int first = 0, length;
            for (var index = 0; index < Operands.Count; index++)
            {
                length = Start(index) - first;
                yield return new CharacterRange(first, length);
                first += length;
                var operand = Operands[index];
                length = operand.Length;
                if (all)
                    foreach (var foo in operand.GetRanges(true).Select(p => new CharacterRange(first + p.First, p.Length)))
                        yield return foo;
                else
                    yield return new CharacterRange(first, length);
                first += length;
            }
            length = Length - first;
            yield return new CharacterRange(first, length);
        }

        #endregion

        #region Protected Properties

        protected Expression FirstSubExpression => Operands?.First()?.Expression;
        protected Expression SecondSubExpression => Operands?.Skip(1)?.First()?.Expression;
        protected Expression ThirdSubExpression => Operands?.Skip(2)?.First()?.Expression;

        #endregion

        #region Protected Methods

        protected bool AddParameters(params Type[] types)
        {
            for (int index = 0; index < types.Length; index++)
                if (Operands.Count <= index)
                    Operands.Add(new Parameter(types[index]));
            return true;
        }

        protected abstract IEnumerable<Type> GetParameterTypes();

        protected abstract bool UseParens(int index);

        protected string WrapTerm(int index)
        {
            var operand = Operands[index];
            var result = operand.ToString();
            return UseParens(index) ? $"({result})" : result;
        }

        #endregion

        #region Protected Static Methods

        protected static Expression Cast(Expression expression, Type type) =>
            expression.Type == type ? expression : Expression.Convert(expression, type);

        /// <summary>
        /// Find the "best" type to represent the result of a dyadic operation using the given operands.
        /// </summary>
        /// <param name="type1">The first term of the dyadic operation.</param>
        /// <param name="type2">The second term of the dyadic operation.</param>
        /// <returns>Type that can be used to hold the operation's result.</returns>
        protected static Type GetCommonType(Type type1, Type type2)
        {
            // If these two types are the same, then just use that common type.
            if (type1 == type2) return type1;
            // If either type is null, then use the other.
            if (type1 == null) return type2;
            if (type2 == null) return type1;
            // Otherwise, use the "wider" of the two different non-null types.
            return MatchType(typeof(double), type1, type2) // Type "double" absorbs any "int", "long" or "float".
                ?? MatchType(typeof(float), type1, type2) // Type "float" absorbs any "int" or "long".
                ?? MatchType(typeof(long), type1, type2) // Type "long" absorbs any "int".
                ?? MatchType(typeof(string), type1, type2); // Type "string" absorbs any "char".
        }

        protected static Type GetType(string typeName) => GetQualifiedType(typeName, ".", ".Globalization.", ".Text.", ".Text.RegularExpressions.");

        protected static Type MatchType(Type t, Type t1, Type t2) => t == t1 || t == t2 ? t : null;

        #endregion

        #region Private Methods

        private void AddOperands(IEnumerable<Term> operands)
        {
            if (operands != null && operands.Any())
                Operands.AddRange(operands);
        }

        private static Type GetQualifiedType(string typeName, params string[] spaces)
        {
            foreach (var space in spaces)
            {
                var result = Type.GetType($"System{space}{typeName}");
                if (result != null)
                    return result;
            }
            switch (typeName)
            {
                case "MatchEvaluator": return typeof(MatchEvaluator);
                case "RegexOptions": return typeof(RegexOptions);
                default: return null;
            }
        }

        #endregion
    }
}
