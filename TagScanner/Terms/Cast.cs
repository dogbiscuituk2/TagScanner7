namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Xml.Serialization;
    using Utils;

    [Serializable]
    public class Cast : Umptad
    {
        public Cast() : base() { }
        public Cast(Type newType) : base() => SetNewType(newType);
        public Cast(Type newType, Term operand) : base(operand) => SetNewType(newType);

        [XmlIgnore]
        public override int Arity => 1;

        [XmlIgnore]
        public override Expression Expression => Expression.Convert(FirstSubExpression, NewType);

        [XmlIgnore]
        public Type NewType
        {
            get => Type.GetType(NewTypeName);
            set => NewTypeName = value?.FullName;
        }

        public string NewTypeName { get; set; }

        [XmlIgnore]
        public override Rank Rank => Rank.Unary;

        [XmlIgnore]
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

        [XmlIgnore]
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
