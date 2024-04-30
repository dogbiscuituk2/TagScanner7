namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Utils;

    public class Operation : TermList
    {
        #region Constructors

        public Operation(Op op, params Term[] operands) : base(operands) => SetOperator(op);
        public Operation(Term first, Op op, params Term[] more) : base(first, more) => SetOperator(op);

        public Operation(string s, params Term[] operands) : base(operands) => SetOperator(s, operands.Length == 1);
        public Operation(Term first, string s, params Term[] more) : base(first, more) => SetOperator(s, more.Length == 0);

        public Operation(char c, params Term[] operands) : base(operands) => SetOperator(c, operands.Length == 1);
        public Operation(Term first, char c, params Term[] more) : base(first, more) => SetOperator(c, more.Length == 0);

        #endregion

        #region Public Properties

        private Op _op;
        public override Op Op => _op;

        public Associativity Associativity => Op.GetAssociativity();
        public Type CommonType => GetCommonType(Operands.ToArray());
        public override Expression Expression => GetExpression();
        public override bool ParamArray => Op.ParamArray();
        public override Rank Rank => Op.GetRank();
        public override Type ResultType => Op.ResultType() ?? CommonType;

        #endregion

        #region Protected Methods

        protected override IEnumerable<Type> GetParameterTypes()
        {
            var type = Op.ParamType();
            return Op.IsUnary() ? (new[] { type }) : (IEnumerable<Type>)(new[] { type, type });
        }

        protected override bool UseParens(int index) => Operands[index].Rank < Rank;

        #endregion

        #region Private Methods

        private static Term Concatenate(params Term[] operands)
        {
            while (true)
            {
                switch (operands.Count())
                {
                    case 0: return null;
                    case 1: return operands[0];
                    case 2: return new Function(Fn.Concat_2, operands[0], operands[1]);
                    case 3: return new Function(Fn.Concat_3, operands[0], operands[1], operands[2]);
                    case 4: return new Function(Fn.Concat_4, operands[0], operands[1], operands[2], operands[3]);
                    default: operands = new[] { Concatenate(operands.Take(4).ToArray()), Concatenate(operands.Skip(4).ToArray()) };
                        continue;
                }
            }
        }

        private static object Default(Op op)
        {
            switch (op)
            {
                case Op.Concatenate: return string.Empty;
                case Op.And: return true;
                case Op.Or:
                case Op.Xor: return false;
                case Op.Add:
                case Op.Subtract: return 0;
                case Op.Multiply:
                case Op.Divide: return 1;
                default: return null;
            }
        }

        private static Type GetCommonType(params Term[] operands) =>
            operands.Aggregate<Term, Type>(null, (current, t) => current.GetCommonType(t?.ResultType));

        private Expression GetExpression()
        {
            if (Op == Op.Add && ResultType == typeof(string))
                return Concatenate(Operands.ToArray()).Expression;
            if ((Associativity & Associativity.Left) != 0)
                return MakeAssociation(Operands);
            if (Op.CanChain())
                return MakeChain();
            if (Op.IsUnary())
                return Expression.MakeUnary(Op.ExpType(), FirstSubExpression, null);
            return MakeBinaryExpression(Op, FirstSubExpression, SecondSubExpression);
        }

        private Expression MakeAssociation(IEnumerable<Term> operands) => MakeAssociation(Op, operands);

        private static Expression MakeAssociation(Op op, IEnumerable<Term> operands)
        {
            if (op == Op.Concatenate)
                return Concatenate(operands.ToArray()).Expression;
            var operandsArray = operands.ToArray();
            var count = operandsArray.Length;
            if (count == 0)
                return Expression.Constant(Default(op));
            var last = operandsArray.Last().Expression;
            switch (count)
            {
                case 1:
                    return last;
                case 2:
                    return MakeBinaryExpression(op, operandsArray[0].Expression, last);
                default:
                    return MakeBinaryExpression(op, MakeAssociation(op, operandsArray.Take(count - 1)), last);
            }
        }

        private BinaryExpression MakeBinaryExpression(Expression left, Expression right) => MakeBinaryExpression(Op, left, right);

        private static BinaryExpression MakeBinaryExpression(Op op, Expression left, Expression right) => Expression.MakeBinary(op.ExpType(), left, right);

        private Expression MakeChain()
        {
            var count = Operands.Count();
            switch (count)
            {
                case 0:
                case 1:
                    return null;
                case 2:
                    return MakeBinaryExpression(FirstSubExpression, SecondSubExpression);
                default:
                    var terms = new List<Term>();
                    for (var index = 0; index < count - 1; index++)
                        terms.Add(new Operation(Operands[index], Op,Operands[index + 1]));
                    return MakeAssociation(Op.And, terms);
            }
        }

        private void SetOperator(Op op) => _op = op;
        private void SetOperator(char c, bool unary) => SetOperator(c.ToString(), unary);
        private void SetOperator(string symbol, bool unary) => SetOperator(symbol.ToOperator(unary));

        #endregion
    }

    #region Derived Monadic Operation Classes

    [Serializable] public class Negation : Operation
    {
        public Negation() : base(Op.Not) { }
        public Negation(Term term) : base(Op.Not, term) { }
    }

    [Serializable] public class Negative : Operation
    {
        public Negative() : base(Op.Negative) { }
        public Negative(Term term) : base(Op.Negative, term) { }
    }

    [Serializable] public class Positive : Operation 
    {
        public Positive() : base(Op.Positive) { }
        public Positive(Term term) : base(Op.Positive, term) { }
    }

    #endregion

    #region Derived Dyadic Operation Classes

    public class Concatenation : Operation
    {
        public Concatenation() : base(Op.Concatenate) { }
        public Concatenation(params Term[] operands) : base(Op.Concatenate, operands) { }
    }

    public class Conjunction : Operation
    {
        public Conjunction() : base(Op.And) { }
        public Conjunction(params Term[] operands) : base(Op.And, operands) { }
    }

    public class Disjunction : Operation
    {
        public Disjunction() : base(Op.Or) { }
        public Disjunction(params Term[] operands) : base(Op.Or, operands) { }
    }

    public class Difference : Operation
    {
        public Difference() : base(Op.Subtract) { }
        public Difference(params Term[] operands) : base(Op.Subtract, operands) { }
    }

    public class ParityOdd : Operation
    {
        public ParityOdd() : base(Op.Xor) { }
        public ParityOdd(params Term[] operands) : base(Op.Xor, operands) { }
    }

    public class Product : Operation
    {
        public Product() : base(Op.Multiply) { }
        public Product(params Term[] operands) : base(Op.Multiply, operands) { }
    }

    public class Quotient : Operation
    {
        public Quotient() : base(Op.Divide) { }
        public Quotient(params Term[] operands) : base(Op.Divide, operands) { }
    }

    public class Sum : Operation
    {
        public Sum() : base(Op.Add) { }
        public Sum(params Term[] operands) : base(Op.Add, operands) { }
    }

    #endregion
}
