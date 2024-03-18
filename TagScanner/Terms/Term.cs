﻿namespace TagScanner.Terms
{
    using System;
    using System.Linq.Expressions;
    using Models;

    [Serializable]
    public abstract class Term
    {
        #region Public Fields

        public static readonly ParameterExpression Work = Expression.Parameter(typeof(Work), "Work");

        #endregion

        #region Public Properties

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
        /// <returns>The first character position, in the full string representation of the given term, of its index'th subTerm
        /// (or -1 if the indexed subTerm does not exist, e.g., if the given "parent" Term is a Constant.).</returns>
        public virtual int Pos(int index) => -1;

        public Term Add(Term term) => Add(this, term);
        public Term And(Term term) => And(this, term);
        public Term Divide(Term term) => Divide(this, term);
        public Term Multiply(Term term) => Multiply(this, term);
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
        public static implicit operator Term(double value) => new Constant(value);
        public static implicit operator Term(int value) => new Constant(value);
        public static implicit operator Term(long value) => new Constant(value);
        public static implicit operator Term(string value) => new Constant(value);
        public static implicit operator Term(Tag tag) => new Field(tag);

        public static Term operator -(Term term) => Minus(term);
        public static Term operator !(Term term) => Not(term);
        public static Term operator +(Term term) => Plus(term);

        public static Term operator +(Term left, Term right) => left.Add(right);
        public static Term operator &(Term left, Term right) => left.And(right);
        public static Term operator /(Term left, Term right) => left.Divide(right);
        public static Term operator *(Term left, Term right) => left.Multiply(right);
        public static Term operator |(Term left, Term right) => left.Or(right);
        public static Term operator -(Term left, Term right) => left.Subtract(right);
        public static Term operator ^(Term left, Term right) => left.Xor(right);

        #endregion
    }
}
