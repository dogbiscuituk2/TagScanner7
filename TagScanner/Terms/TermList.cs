﻿namespace TagScanner.Terms
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

        public override Expression Expression => null;
        public virtual Op Op => Op.Comma;
        public virtual bool ParamArray => true;
        public IEnumerable<Type> ParameterTypes => GetParameterTypes();
        public override Type ResultType => null;

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

        public override int Start(int index)
        {
            int result;
            var format = Op.Format();
            var delta = format.IndexOf("{0}");
            var up = UseParens(0);
            if (index == 0)
                result = delta + (up ? 1 : 0);
            else
            {
                delta = format.IndexOf("{1}") - delta - 3;
                result =
                    Start(index - 1)
                    + Operands[index - 1].Length
                    + (UseParens(index - 1) ? 1 : 0)
                    + delta
                    + (UseParens(index) ? 1 : 0);
            }
            return result;
        }

        #endregion

        #region Protected Properties

        protected Expression FirstSubExpression => Operands?.First()?.Expression;
        protected Expression SecondSubExpression => Operands?.Skip(1)?.First()?.Expression;
        protected Expression ThirdSubExpression => Operands?.Skip(2)?.First()?.Expression;

        #endregion

        #region Protected Methods

        protected virtual IEnumerable<Type> GetParameterTypes() => new[] { typeof(object) };

        public override string ToString()
        {
            var format = Op.Format();
            var count = Operands.Count;
            if (count < 1)
                return string.Empty;
            var operands = new string[count];
            for (var index = 0; index < Operands.Count; index++)
                operands[index] = WrapTerm(index);
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

        protected static Type GetQualifiedType(string typeName) => GetQualifiedType(typeName, ".", ".Globalization.", ".Text.", ".Text.RegularExpressions.");

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
