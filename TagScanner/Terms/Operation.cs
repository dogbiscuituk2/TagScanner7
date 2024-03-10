namespace TagScanner.Terms
{
    using Microsoft.CodeAnalysis;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class Operation : Umptad
    {
        #region Constructors

        public Operation(Operator op, params Term[] operands) : base(operands) => SetOperator(op);
        public Operation(Term first, Operator op, params Term[] more) : base(first, more) => SetOperator(op);

        public Operation(string s, params Term[] operands) : base(operands) => SetOperator(s, operands.Length == 1);
        public Operation(Term first, string s, params Term[] more) : base(first, more) => SetOperator(s, more.Length == 0);

        public Operation(char c, params Term[] operands) : base(operands) => SetOperator(c, operands.Length == 1);
        public Operation(Term first, char c, params Term[] more) : base(first, more) => SetOperator(c, more.Length == 0);

        #endregion

        #region Public Properties

        public Operator Operator => _operator;

        public override int Arity => Operator.Arity();
        public override Expression Expression => GetExpression();
        public override Type ResultType => Operator.ResultType() ?? GetCommonResultType(Operands.ToArray());

        #endregion

        #region Public Methods

        public override string ToString(bool friendlyText)
        {
            var format = Operator.Format(friendlyText);
            var count = Operands.Count;
            if (count < 1)
                return format;
            var operands = new string[count];
            for (var index = 0; index < Operands.Count; index++)
                operands[index] = WrapTerm(index, friendlyText);
            if (count == Operator.Arity())
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
            if (Operator == Operator.Conditional)
            {
                yield return typeof(bool);
                yield return type;
                yield return type;
            }
            for (var index = 0; index < Operands.Count(); index++)
                yield return type;
        }

        #endregion

        #region Private Fields

        private Operator _operator;

        #endregion

        #region Private Methods

        private Term Concatenate(params Term[] operands)
        {
            switch (operands.Count())
            {
                case 0: return null;
                case 1: return operands[0];
                case 2: return new Function("String.Concat(String, String)", operands[0], operands[1]);
                case 3: return new Function("String.Concat(String, String, String)", operands[0], operands[1], operands[2]);
                case 4: return new Function("String.Concat(String, String, String, String)", operands[0], operands[1], operands[2], operands[3]);
                default: return Concatenate(new[] { Concatenate(operands.Take(4).ToArray()), Concatenate(operands.Skip(4).ToArray()) });
            }
        }

        private object Default()
        {
            switch (Operator)
            {
                case Operator.And: return true;
                case Operator.Or:
                case Operator.Xor: return false;
                case Operator.Add:
                case Operator.Subtract: return 0;
                case Operator.Multiply:
                case Operator.Divide: return 1;
                default: return null;
            }
        }

        private Type GetCommonResultType(params Term[] operands)
        {
            if (Operator == Operator.Conditional)
                return GetCommonType(Operands[1]?.ResultType, Operands[2]?.ResultType);
            Type resultType = null;
            for (var index = 0; index < operands.Length; index++)
                resultType = GetCommonType(resultType, operands[index]?.ResultType);
            return resultType;
        }

        private Expression GetExpression()
        {
            if (Operator == Operator.Add && ResultType == typeof(string))
                return Concatenate(Operands.ToArray()).Expression;
            if (Operator.Associates())
                return MakeAssociation(Operands);
            switch (Operator.Arity())
            {
                case 1: return Expression.MakeUnary(Operator.ExpType(), FirstOperand, null);
                default: return Expression.MakeBinary(Operator.ExpType(), FirstOperand, SecondOperand);
            }
        }

        private Expression MakeAssociation(IEnumerable<Term> operands)
        {
            var count = operands.Count();
            if (count == 0) return Expression.Constant(Default());
            var lastExpression = operands.Last().Expression;
            return count == 1 ? lastExpression : MakeBinaryExpression(MakeAssociation(operands.Take(count - 1)), lastExpression);
        }

        private BinaryExpression MakeBinaryExpression(Expression leftExpression, Expression rightExpression) => Expression.MakeBinary(Operator.ExpType(), leftExpression, rightExpression);

        private void SetOperator(char c, bool monadic) => SetOperator(c.ToString(), monadic);
        private void SetOperator(string symbol, bool monadic) => SetOperator(ToOperator(symbol, monadic));

        private bool SetOperator(Operator op)
        {
            _operator = op;
            switch (Operator)
            {
                case Operator.Conditional:
                    return AddParameters(typeof(bool), null, null);
                case Operator.And:
                case Operator.Or:
                case Operator.Xor:
                    return AddParameters(typeof(bool), typeof(bool));
                case Operator.EqualTo:
                case Operator.NotEqualTo:
                    return AddParameters(typeof(string), typeof(string));
                case Operator.Add:
                    return AddParameters(null, null);
                case Operator.Positive:
                case Operator.Negative:
                    return AddParameters(typeof(int));
                case Operator.Not:
                    return AddParameters(typeof(bool));
                default:
                    return AddParameters(typeof(int), typeof(int));
            }
        }

        private string WrapTerm(int index, bool friendlyText)
        {
            var operand = Operands[index];
            return friendlyText ? operand.ToFriendlyText() : operand.ToCode();
        }

        #endregion

        #region Private Static Methods

        private static void AdjustTypes(ref Expression left, ref Expression right)
        {
            var type = GetCommonType(left.Type, right.Type);
            left = Cast(left, type);
            right = Cast(right, type);
        }

        private static Operator ToOperator(string symbol, bool monadic)
        {
            switch (symbol.ToLower())
            {
                case "?:":
                    return Operator.Conditional;
                case "&":
                case "&&":
                case "and":
                    return Operator.And;
                case "|":
                case "||":
                case "or":
                    return Operator.Or;
                case "^":
                case "xor":
                    return Operator.Xor;
                case "=":
                case "==":
                    return Operator.EqualTo;
                case "!=":
                case "<>":
                case "≠":
                    return Operator.NotEqualTo;
                case "<":
                    return Operator.LessThan;
                case ">=":
                case "≥":
                case "≮":
                    return Operator.NotLessThan;
                case ">":
                    return Operator.GreaterThan;
                case "<=":
                case "≤":
                case "≯":
                    return Operator.NotGreaterThan;
                case "+":
                case "＋":
                    return monadic ? Operator.Positive : Operator.Add;
                case "-":
                case "－":
                    return monadic ? Operator.Negative : Operator.Subtract;
                case "*":
                case "×":
                case "✕":
                    return Operator.Multiply;
                case "/":
                case "÷":
                case "／":
                    return Operator.Divide;
                case "!":
                case "not":
                    return Operator.Not;
            }
            throw new ArgumentException($"The symbol \"{symbol}\" does not represent a known operator.");
        }

        #endregion
    }

    #region Derived Classes

    public class Negation : Operation { public Negation(Term term) : base(Operator.Not, term) { } }
    public class Negative : Operation { public Negative(Term term) : base(Operator.Negative, term) { } }
    public class Positive : Operation { public Positive(Term term) : base(Operator.Positive, term) { } }

    public class Concatenation : Operation { public Concatenation(params Term[] operands) : base(Operator.Add, operands) { } }
    public class Conditional : Operation { public Conditional(params Term[] operands) : base(Operator.Conditional, operands) { } }
    public class Conjunction : Operation { public Conjunction(params Term[] operands) : base(Operator.And, operands) { } }
    public class Disjunction : Operation { public Disjunction(params Term[] operands) : base(Operator.Or, operands) { } }
    public class Difference : Operation { public Difference(params Term[] operands) : base(Operator.Subtract, operands) { } }
    public class ParityOdd : Operation { public ParityOdd(params Term[] operands) : base(Operator.Xor, operands) { } }
    public class Product : Operation { public Product(params Term[] operands) : base(Operator.Multiply, operands) { } }
    public class Quotient : Operation { public Quotient(params Term[] operands) : base(Operator.Divide, operands) { } }
    public class Sum : Operation { public Sum(params Term[] operands) : base(Operator.Add, operands) { } }

    #endregion
}
