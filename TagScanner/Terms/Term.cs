namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;
    using Utils;

    public abstract class Term
    {
        #region Public Fields

        public static Term Nothing = new EmptyTerm();

        public static readonly Variable List = new Variable("List", typeof(Selection));
        public static readonly Variable Track = new Variable("Track", typeof(Track));

        #endregion

        #region Public Properties

        public static IEnumerable<string> Booleans => new[] { "false", "true" };

        public object[] Defaults
        {
            get
            {
                var parameters = Parameters.ToList();
                var count = Parameters.Count();
                var defaults = new object[count];
                for (var index = 0; index < count; index++)
                    defaults[index] = parameters[index].Type.GetDefaultValue();
                return defaults;
            }
        }

        public Delegate Delegate
        {
            get
            {
                var expression = Expression;
                var parameters = Parameters;
                var lambda = Expression.Lambda(expression, parameters);
                return lambda.Compile();
            }
        }

        public abstract Expression Expression { get; }

        public int Length => ToString().Length;

        public virtual IEnumerable<ParameterExpression> Parameters => new[]
        {
            (ParameterExpression)List.Expression,
            (ParameterExpression)Track.Expression
        };

        public Func<Selection, Track, bool> ListPredicate => (list, track) => Filter(list, track);
        public Func<Track, bool> TrackPredicate => (track) => Filter(null, track);

        public virtual Rank Rank => Rank.Unary;

        public object Result
        {
            get
            {
                try
                {
                    var func = Delegate;
                    return func.DynamicInvoke(Defaults);
                }
                catch (Exception exception)
                {
                    exception.LogException();
                    return null;
                }
            }
        }

        public virtual Type ResultType
        {
            get => null;
            set { }
        }

        #endregion

        #region Public Methods

        public bool Filter(Selection list, Track track)
        {
            var func = Delegate;
            var args = Defaults;
            args[0] = list;
            args[1] = track;
            return (bool)func.DynamicInvoke(args);
        }

        public IEnumerable<Track> Filter(IEnumerable<Track> tracks) => Filter(list: null, tracks);

        public IEnumerable<Track> Filter(Selection list, IEnumerable<Track> tracks)
        {
            var func = Delegate;
            var args = Defaults;
            args[0] = list;
            bool error = false, pass = false;
            foreach (var track in tracks)
            {
                if (!error)
                    try
                    {
                        args[1] = track;
                        pass = (bool)func.DynamicInvoke(args);
                    }
                    catch (Exception exception)
                    {
                        exception.LogException();
                        error = true;
                    }
                if (pass || error)
                    yield return track;
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

        #region Character Ranges

        public List<CharacterRange> CharacterRanges => GetCharacterRanges();
        public List<CharacterRange> CharacterRangesAll => GetCharacterRangesAll();

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

        /// <summary>
        /// An integer indicating the first character position, in the full string representation of a given term, of its index'th subTerm.
        /// </summary>
        /// <param name="index">The index of the subTerm. The first subTerm has index 0.</param>
        /// <returns>The first character position, in the full string representation of the given term, of its "index"-th subTerm
        /// (or -1 if the indexed subTerm does not exist, e.g., if the given "parent" Term is a Constant or a Field.).</returns>
        public virtual int Start(int index) => -1;

        public virtual void ValidateCharacterRanges()
        {
            if (!_characterRangesValid)
            {
                InitCharacterRanges();
                _characterRangesValid = true;
            }
        }

        #endregion

        #region Public Operators

        public static implicit operator Term(bool value) => new Constant<bool>(value);
        public static implicit operator Term(char value) => new Constant<char>(value);
        public static implicit operator Term(DateTime value) => new Constant<DateTime>(value);
        public static implicit operator Term(decimal value) => new Constant<decimal>(value);
        public static implicit operator Term(double value) => new Constant<double>(value);
        public static implicit operator Term(float value) => new Constant<float>(value);
        public static implicit operator Term(int value) => new Constant<int>(value);
        public static implicit operator Term(long value) => new Constant<long>(value);
        public static implicit operator Term(string value) => new Constant<string>(value);
        public static implicit operator Term(uint value) => new Constant<uint>(value);
        public static implicit operator Term(ulong value) => new Constant<ulong>(value);
        public static implicit operator Term(Tag tag) => new TrackField(tag);
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

        protected List<CharacterRange> _characterRanges = new List<CharacterRange>();
        private bool _characterRangesValid;

        #endregion

        #region Private Classes

        private class EmptyTerm : Term
        {
            public override Expression Expression => Expression.Empty();
            public override string ToString() => string.Empty;
        }

        #endregion
    }
}
