namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq.Expressions;
    using Models;
    using TagScanner.Utils;

    public abstract class Term
    {
        #region Public Fields

        public static readonly ParameterExpression Track = Expression.Parameter(typeof(Track), "Track");

        public static readonly Constant<string> Empty = new Constant<string>(string.Empty);
        public static readonly Constant<bool> False = new Constant<bool>(false);
        public static readonly Constant<bool> True = new Constant<bool>(true);
        public static readonly Constant<int> Zero = new Constant<int>(0);

        #endregion

        #region Public Properties

        public List<CharacterRange> CharacterRanges => GetCharacterRanges();
        public List<CharacterRange> CharacterRangesAll => GetCharacterRangesAll();
        public abstract Expression Expression { get; }
        public int Length => ToString().Length;

        public Func<Track, bool> Predicate
        {
            get
            {
                try
                {
                    return Expression.Lambda<Func<Track, bool>>(Expression, Track).Compile();
                }
                catch (Exception exception)
                {
                    exception.LogException();
                    return track => true;
                }
            }
        }

        public Term Parent { get; private set; }

        public object Result
        {
            get
            {
                try
                {
                    return Expression.Lambda(Expression).Compile().DynamicInvoke();
                }
                catch (Exception exception)
                {
                    exception.LogException();
                    return null;
                }
            }
        }

        public virtual Rank Rank => Rank.Unary;

        public virtual Type ResultType
        {
            get => null;
            set { }
        }

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

        public static implicit operator Term(bool value) => new Constant<bool>(value);
        public static implicit operator Term(char value) => new Constant<char>(value);
        public static implicit operator Term(DateTime value) => new Constant<DateTime>(value);
        public static implicit operator Term(double value) => new Constant<double>(value);
        public static implicit operator Term(int value) => new Constant<int>(value);
        public static implicit operator Term(long value) => new Constant<long>(value);
        public static implicit operator Term(string value) => new Constant<string>(value);
        public static implicit operator Term(Tag tag) => new Field(tag);
        public static implicit operator Term(TimeSpan value) => new Constant<TimeSpan>(value);

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

        [NonSerialized] protected List<CharacterRange> _characterRanges = new List<CharacterRange>();
        [NonSerialized] private bool _characterRangesValid;

        #endregion
    }
}
