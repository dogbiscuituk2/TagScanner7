namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using TagScanner.Utils;

    public class Cast : Umptad
    {
        public Cast(Type newType) : base() => SetNewType(newType);
        public Cast(Type newType, Term operand) : base(operand) => SetNewType(newType);

        public override int Arity => 1;
        public override Expression Expression => Expression.Convert(FirstSubExpression, NewType);
        public Type NewType { get; set; }
        public override Rank Rank => Rank.Unary;
        public override Type ResultType => NewType;

        protected override IEnumerable<Type> GetParameterTypes() => new[] { typeof(object) };
        public override int Start(int index) => NewType.Say().Length + (UseParens(0) ? 3 : 2);
        public override string ToString() => $"({NewType.Say()}){WrapTerm(0)}";
        protected override bool UseParens(int index) => Operands.First().Rank < Rank.Unary;

        private void SetNewType(Type newType)
        {
            NewType = newType;
            AddParameters(typeof(object));
        }

        public static Type[] NewTypes =
        {
            typeof(bool),
            typeof(byte),
            typeof(char),
            typeof(DateTime),
            typeof(decimal),
            typeof(double),
            typeof(float),
            typeof(int),
            typeof(long),
            // typeof(object), // Never need to cast down to System.Object.
            typeof(sbyte),
            typeof(short),
            typeof(string),
            typeof(TimeSpan),
            typeof(uint),
            typeof(ulong),
            typeof(ushort),
        };
    }
}
