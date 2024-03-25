namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    [Serializable]
    public class Operation : Umptad
    {
        #region Constructors

        public Operation() : base() { }

        public Operation(Op op, params Term[] operands) : base(operands) => SetOperator(op);
        public Operation(Term first, Op op, params Term[] more) : base(first, more) => SetOperator(op);

        public Operation(string s, params Term[] operands) : base(operands) => SetOperator(s, operands.Length == 1);
        public Operation(Term first, string s, params Term[] more) : base(first, more) => SetOperator(s, more.Length == 0);

        public Operation(char c, params Term[] operands) : base(operands) => SetOperator(c, operands.Length == 1);
        public Operation(Term first, char c, params Term[] more) : base(first, more) => SetOperator(c, more.Length == 0);

        #endregion

        #region Public Properties

        public override int Arity => Op.Arity();
        public override Expression Expression => GetExpression();
        public Op Op { get; set; }
        public override Rank Rank => Op.Rank();
        public override Type ResultType => Op.ResultType() ?? GetCommonResultType(Operands.ToArray());

        #endregion

        #region Public Methods

        public override int Start(int index)
        {
            var format = Op.Format();
            var delta = format.IndexOf("{0}");
            var up = UseParens(0);
            if (index == 0)
                return delta + (up ? 1 : 0);
            delta = format.IndexOf("{1}") - delta - 3;
            return Start(index - 1)
                   + Operands[index - 1].Length
                   + (UseParens(index - 1) ? 1 : 0)
                   + delta
                   + (UseParens(index) ? 1 : 0);
        }

        public override string ToString()
        {
            var format = Op.Format();
            var count = Operands.Count;
            if (count < 1)
                return format;
            var operands = new string[count];
            for (var index = 0; index < Operands.Count; index++)
                operands[index] = WrapTerm(index);
            if (count == Op.Arity())
                return string.Format(format, operands);
            var result = operands[0];
            for (var index = 1; index < count; index++)
                result = string.Format(format, result, operands[index]);
            return result;
        }

        #endregion

        #region Protected Methods

        protected override IEnumerable<Type> GetParameterTypes()
        {
            var type = GetCommonResultType();
            if (Op == Op.Conditional)
            {
                yield return typeof(bool);
                yield return type;
                yield return type;
            }
            for (var index = 0; index < Operands.Count(); index++)
                yield return type;
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
                    case 2: return new Function("Concat_2", operands[0], operands[1]);
                    case 3: return new Function("Concat_3", operands[0], operands[1], operands[2]);
                    case 4: return new Function("Concat_4", operands[0], operands[1], operands[2], operands[3]);
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

        private Type GetCommonResultType(params Term[] operands)
        {
            return Op == Op.Conditional
                ? GetCommonType(Operands[1]?.ResultType, Operands[2]?.ResultType)
                : operands.Aggregate<Term, Type>(null, (current, t) => GetCommonType(current, t?.ResultType));
        }

        private Expression GetExpression()
        {
            if (Op == Op.Add && ResultType == typeof(string))
                return Concatenate(Operands.ToArray()).Expression;
            if (Op.Associates())
                return MakeAssociation(Operands);
            if (Op.CanChain())
                return MakeChain();
            switch (Op.Arity())
            {
                case 1: return Expression.MakeUnary(Op.ExpType(), FirstSubExpression, null);
                case 3: return Expression.Condition(FirstSubExpression, SecondSubExpression, ThirdSubExpression);
                default: return Expression.MakeBinary(Op.ExpType(), FirstSubExpression, SecondSubExpression);
            }
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

        private void SetOperator(char c, bool unary) => SetOperator(c.ToString(), unary);
        private void SetOperator(string symbol, bool unary) => SetOperator(ToOperator(symbol, unary));

        private bool SetOperator(Op op)
        {
            Op = op;
            switch (Op)
            {
                case Op.Conditional:
                    return AddParameters(typeof(bool), typeof(object), typeof(object));
                case Op.And:
                case Op.Or:
                case Op.Xor:
                    return AddParameters(typeof(bool), typeof(bool));
                case Op.EqualTo:
                case Op.NotEqualTo:
                    return AddParameters(typeof(object), typeof(object));
                case Op.Concatenate:
                    return AddParameters(typeof(string), typeof(string));
                case Op.Positive:
                case Op.Negative:
                    return AddParameters(typeof(double));
                case Op.Not:
                    return AddParameters(typeof(bool));
                default:
                    return AddParameters(typeof(double), typeof(double));
            }
        }

        #endregion

        #region Private Static Methods

        private static Op ToOperator(string symbol, bool unary)
        {
            switch (symbol.ToLower())
            {
                case "?:":
                    return Op.Conditional;
                case "&":
                case "&&":
                case "and":
                    return Op.And;
                case "|":
                case "||":
                case "or":
                    return Op.Or;
                case "^":
                case "xor":
                    return Op.Xor;
                case "=":
                case "==":
                    return Op.EqualTo;
                case "!=":
                case "<>":
                case "≠":
                    return Op.NotEqualTo;
                case "<":
                    return Op.LessThan;
                case ">=":
                case "≥":
                case "≮":
                    return Op.NotLessThan;
                case ">":
                    return Op.GreaterThan;
                case "<=":
                case "≤":
                case "≯":
                    return Op.NotGreaterThan;
                case "+":
                case "＋":
                    return unary ? Op.Positive : Op.Add;
                case "-":
                case "－":
                    return unary ? Op.Negative : Op.Subtract;
                case "*":
                case "×":
                case "✕":
                    return Op.Multiply;
                case "/":
                case "÷":
                case "／":
                    return Op.Divide;
                case "!":
                case "not":
                    return Op.Not;
            }
            throw new ArgumentException($"The symbol \"{symbol}\" does not represent a known operator.");
        }

        #endregion
    }

    #region Derived Classes

    [Serializable]
    public class Negation : Operation
    {
        public Negation() : base() { }
        public Negation(Term term) : base(Op.Not, term) { }
    }

    [Serializable]
    public class Negative : Operation
    {
        public Negative() : base() { }
        public Negative(Term term) : base(Op.Negative, term) { }
    }

    [Serializable]
    public class Positive : Operation
    {
        public Positive() : base() { }
        public Positive(Term term) : base(Op.Positive, term) { }
    }

    [Serializable]
    public class Concatenation : Operation
    {
        public Concatenation() : base() { }
        public Concatenation(params Term[] operands) : base(Op.Add, operands) { }
    }

    [Serializable]
    public class Conditional : Operation
    {
        public Conditional() : base() { }
        public Conditional(params Term[] operands) : base(Op.Conditional, operands) { }
    }

    [Serializable]
    public class Conjunction : Operation
    {
        public Conjunction() : base() { }
        public Conjunction(params Term[] operands) : base(Op.And, operands) { }
    }

    [Serializable]
    public class Disjunction : Operation 
    {
        public Disjunction() : base() { }
        public Disjunction(params Term[] operands) : base(Op.Or, operands) { }
    }

    [Serializable]
    public class Difference : Operation
    {
        public Difference() : base() { }
        public Difference(params Term[] operands) : base(Op.Subtract, operands) { }
    }

    [Serializable]
    public class ParityOdd : Operation
    {
        public ParityOdd() : base() { }
        public ParityOdd(params Term[] operands) : base(Op.Xor, operands) { }
    }

    [Serializable]
    public class Product : Operation
    {
        public Product() : base() { }
        public Product(params Term[] operands) : base(Op.Multiply, operands) { }
    }

    [Serializable]
    public class Quotient : Operation
    {
        public Quotient() : base() { }
        public Quotient(params Term[] operands) : base(Op.Divide, operands) { }
    }

    [Serializable]
    public class Sum : Operation
    {
        public Sum() : base() { }
        public Sum(params Term[] operands) : base(Op.Add, operands) { }
    }

    #endregion
}
