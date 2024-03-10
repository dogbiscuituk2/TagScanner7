namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;
    using TagScanner.Models;

    public abstract class Term
    {
        public static ParameterExpression Work = Expression.Parameter(typeof(Work), "T");

        public abstract Expression Expression { get; }
        public abstract Type ResultType { get; }

        public Func<Work, bool> Predicate => Expression.Lambda<Func<Work, bool>>(Expression, Work).Compile();
            
        public virtual string ToCode() => ToString();
        public virtual string ToFriendlyText() => ToString();
        public virtual string ToString(bool friendlyText) => friendlyText ? ToFriendlyText() : ToCode();

        public Term Add(Term term) => Add(this, term);
        public Term And(Term term) => And(this, term);
        public Term Multiply(Term term) => Multiply(this, term);
        public Term Or(Term term) => Or(this, term);
        public Term Xor(Term term) => Xor(this, term);

        public static Term Add(params Term[] terms) => new Sum(terms);
        public static Term And(params Term[] terms) => new Conjunction(terms);
        public static Term Multiply(params Term[] terms) => new Product(terms);
        public static Term Or(params Term[] terms) => new Disjunction(terms);
        public static Term Xor(params Term[] terms) => new ParityOdd(terms);

        public static implicit operator Term(char value) => new Constant(value);
        public static implicit operator Term(double value) => new Constant(value);
        public static implicit operator Term(int value) => new Constant(value);
        public static implicit operator Term(long value) => new Constant(value);
        public static implicit operator Term(string value) => new Constant(value);

        public static Term operator !(Term term) => new Negation(term);
        public static Term operator &(Term left, Term right) => left.And(right);
        public static Term operator |(Term left, Term right) => left.Or(right);
    }
}
