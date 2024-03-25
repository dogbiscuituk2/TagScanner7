namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq.Expressions;
    using Models;

    [Serializable]
    public abstract class Term
    {
        public Term() { }

        #region Public Fields

        [NonSerialized]
        public static readonly ParameterExpression Work = Expression.Parameter(typeof(Work), "Work");

        #endregion

        #region Public Properties

        public List<CharacterRange> CharacterRanges => GetCharacterRanges();
        public List<CharacterRange> CharacterRangesAll => GetCharacterRangesAll();
        public abstract Expression Expression { get; }
        public int Length => ToString().Length;
        public Func<Work, bool> Predicate => Expression.Lambda<Func<Work, bool>>(Expression, Work).Compile();
        public virtual Rank Rank => Rank.Unary;
        public abstract Type ResultType { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// An integer indicating the first character position, in the full string representation of a given term, of its index'th subTerm.
        /// </summary>
        /// <param name="index">The index of the subTerm. The first subTerm has index 0.</param>
        /// <returns>The first character position, in the full string representation of the given term, of its "index"-th subTerm
        /// (or -1 if the indexed subTerm does not exist, e.g., if the given "parent" Term is a Constant or a Field.).</returns>
        public virtual int Start(int index) => -1;

        protected List<CharacterRange> GetCharacterRanges()
        {
            ValidateCharacterRanges();
            return _characterRanges;
        }

        protected virtual List<CharacterRange> GetCharacterRangesAll() => GetCharacterRanges();

        protected virtual void InitCharacterRanges()
        {
            _characterRanges.Clear();
            _characterRanges.Add(new CharacterRange(0, Length));
        }

        public virtual void InvalidateCharacterRanges() => _characterRangesValid = false;

        public virtual void ValidateCharacterRanges()
        {
            if (!_characterRangesValid)
            {
                InitCharacterRanges();
                _characterRangesValid = true;
            }
        }

        public Term Add(Term term) => Add(this, term);
        public Term And(Term term) => And(this, term);
        public Term DivideBy(Term term) => Divide(this, term);
        public Term MultiplyBy(Term term) => Multiply(this, term);
        public Term Or(Term term) => Or(this, term);
        public Term Subtract(Term term) => Subtract(this, term);
        public Term Xor(Term term) => Xor(this, term);

        public static Term Minus(Term term) => new Negative(term);
        public static Term Not(Term term) => new Negation(term);
        public static Term Plus(Term term) => new Positive(term);

        public static Term Add(params Term[] terms) => new Sum(terms);
        public static Term And(params Term[] terms) => new Conjunction(terms);
        public static Term Divide(params Term[] terms) => new Quotient(terms);
        public static Term Multiply(params Term[] terms) => new Product(terms);
        public static Term Or(params Term[] terms) => new Disjunction(terms);
        public static Term Subtract(params Term[] terms) => new Difference(terms);
        public static Term Xor(params Term[] terms) => new ParityOdd(terms);

        #endregion

        #region Public Operators

        public static implicit operator Term(bool value) => new Constant(value);
        public static implicit operator Term(char value) => new Constant(value);
        public static implicit operator Term(DateTime value) => new Constant(value);
        public static implicit operator Term(double value) => new Constant(value);
        public static implicit operator Term(int value) => new Constant(value);
        public static implicit operator Term(long value) => new Constant(value);
        public static implicit operator Term(string value) => new Constant(value);
        public static implicit operator Term(Tag tag) => new Field(tag);
        public static implicit operator Term(TimeSpan value) => new Constant(value);

        public static Term operator -(Term term) => Minus(term);
        public static Term operator !(Term term) => Not(term);
        public static Term operator +(Term term) => Plus(term);

        public static Term operator +(Term left, Term right) => left.Add(right);
        public static Term operator &(Term left, Term right) => left.And(right);
        public static Term operator /(Term left, Term right) => left.DivideBy(right);
        public static Term operator *(Term left, Term right) => left.MultiplyBy(right);
        public static Term operator |(Term left, Term right) => left.Or(right);
        public static Term operator -(Term left, Term right) => left.Subtract(right);
        public static Term operator ^(Term left, Term right) => left.Xor(right);

        #endregion

        #region Private Fields

        [NonSerialized]
        protected List<CharacterRange> _characterRanges = new List<CharacterRange>();

        [NonSerialized]
        private bool _characterRangesValid;

        #endregion
    }
}
