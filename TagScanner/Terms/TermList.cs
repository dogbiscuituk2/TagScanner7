using TagScanner.Utils;

namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text.RegularExpressions;

    public class TermList : Term
    {
        #region Constructors

        public TermList(params Term[] operands) => AddOperands(operands);
        public TermList(Term firstOperand, params Term[] moreOperands) : this(new[] { firstOperand }) => AddOperands(moreOperands);

        #endregion

        #region Public Properties

        public virtual int Arity => -1;
        public override Expression Expression => null;
        public IEnumerable<Type> ParameterTypes => GetParameterTypes();
        public override Type ResultType => null;

        public virtual Op Op
        {
            get => Op.Comma;
            set => _ = value;
        }

        public List<Term> Operands { get; set; } = new List<Term>();

        #endregion

        #region Public Methods

        protected override List<CharacterRange> GetCharacterRangesAll()
        {
            ValidateCharacterRanges();
            return _characterRangesAll;
        }

        protected override void InitCharacterRanges()
        {
            _characterRanges.Clear();
            _characterRangesAll.Clear();
            CharacterRange range;
            int first = 0, length;
            for (var index = 0; index < Operands.Count; index++)
            {
                length = Start(index) - first;
                AddRangeAll();
                first += length;
                var operand = Operands[index];
                length = operand.Length;
                AddRange();
                foreach (var subRange in operand.CharacterRangesAll)
                    _characterRangesAll.Add(new CharacterRange(first + subRange.First, subRange.Length));
                first += length;
            }
            length = Length - first;
            AddRangeAll();
            return;

            void AddRange()
            {
                range = new CharacterRange(first, length);
                _characterRanges.Add(range);
            }

            void AddRangeAll()
            {
                AddRange();
                _characterRangesAll.Add(range);
            }
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
            for (var index = 0; index < types.Length; index++)
                if (Operands.Count <= index)
                    Operands.Add(new Parameter(types[index]));
            return true;
        }

        /*
        private Term NewArrayParameter(Type elementType) =>
            elementType == null ? new Parameter<object[]>() :
            elementType == typeof(bool) ? new Parameter<bool[]>() :
            elementType == typeof(byte) ? new Parameter<byte[]>() :
            elementType == typeof(char) ? new Parameter<char[]>() :
            elementType == typeof(DateTime) ? new Parameter<DateTime[]>() :
            elementType == typeof(decimal) ? new Parameter<decimal[]>() :
            elementType == typeof(double) ? new Parameter<double[]>() :
            elementType == typeof(float) ? new Parameter<float[]>() :
            elementType == typeof(int) ? new Parameter<int[]>() :
            elementType == typeof(long) ? new Parameter<long[]>() :
            elementType == typeof(object) ? new Parameter<object[]>() :
            elementType == typeof(sbyte) ? new Parameter<sbyte[]>() :
            elementType == typeof(short) ? new Parameter<short[]>() :
            elementType == typeof(string) ? new Parameter<string[]>() :
            elementType == typeof(TimeSpan) ? new Parameter<TimeSpan[]>() :
            elementType == typeof(uint) ? new Parameter<uint[]>() :
            elementType == typeof(ulong) ? new Parameter<ulong[]>() :
            elementType == typeof(ushort) ? new Parameter<ushort[]>() :
            (Term)new Parameter<object[]>();

        private Term NewParameter(Type type) =>
            type == null ? new Parameter<object>() :
            type.IsArray ? NewArrayParameter(type.GetElementType()) :
            type == typeof(bool) ? new Parameter<bool>() :
            type == typeof(byte) ? new Parameter<byte>() :
            type == typeof(char) ? new Parameter<char>() :
            type == typeof(DateTime) ? new Parameter<DateTime>() :
            type == typeof(decimal) ? new Parameter<decimal>() :
            type == typeof(double) ? new Parameter<double>() :
            type == typeof(float) ? new Parameter<float>() :
            type == typeof(int) ? new Parameter<int>() :
            type == typeof(long) ? new Parameter<long>() :
            type == typeof(object) ? new Parameter<object>() :
            type == typeof(sbyte) ? new Parameter<sbyte>() :
            type == typeof(short) ? new Parameter<short>() :
            type == typeof(string) ? new Parameter<string>() :
            type == typeof(TimeSpan) ? new Parameter<TimeSpan>() :
            type == typeof(uint) ? new Parameter<uint>() :
            type == typeof(ulong) ? new Parameter<ulong>() :
            type == typeof(ushort) ? new Parameter<ushort>() :
            (Term)new Parameter<object>();
        */

        protected virtual IEnumerable<Type> GetParameterTypes() => new[] { typeof(object) };

        public override string ToString()
        {
            var format = Op.GetFormat();
            var count = Operands.Count;
            if (count < 1)
                return string.Empty;
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

        protected virtual bool UseParens(int index) => false;

        protected string WrapTerm(int index)
        {
            var operand = Operands[index];
            var result = operand.ToString();
            return UseParens(index) ? $"({result})" : result;
        }

        #endregion

        #region Protected Static Methods

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

        protected static Type GetQualifiedType(string typeName) => GetQualifiedType(typeName, ".", ".Globalization.", ".Text.", ".Text.RegularExpressions.");

        protected static Type MatchType(Type t, Type t1, Type t2) => t == t1 || t == t2 ? t : null;

        #endregion

        #region Private Fields

        private List<CharacterRange> _characterRangesAll = new List<CharacterRange>();

        #endregion

        #region Private Methods

        private void AddOperands(IEnumerable<Term> operands)
        {
            if (operands != null)
                Operands.AddRange(operands);
        }

        private static Type GetQualifiedType(string typeName, params string[] nameSpaces)
        {
            foreach (var nameSpace in nameSpaces)
            {
                var result = Type.GetType($"System{nameSpace}{typeName}");
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
