namespace TagScanner.Terms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Utils;

    public class Cast : TermList
    {
        public Cast(Type newType) => SetNewType(newType);
        public Cast(Type newType, Term operand) : base(operand) => SetNewType(newType);

        public string NewTypeName { get; set; }

        public override int Arity => 1;
        public override Expression Expression => Expression.Convert(FirstSubExpression, ResultType);
        public override Rank Rank => Rank.Unary;
        public override Type ResultType => Type.GetType(NewTypeName);

        protected override IEnumerable<Type> GetParameterTypes() => new[] { typeof(object) };
        public override int Start(int index) => ResultType.Say().Length + (UseParens(0) ? 3 : 2);
        public override string ToString() => $"({ResultType.Say()}){WrapTerm(0)}";
        protected override bool UseParens(int index) => Operands.First().Rank < Rank.Unary;

        private void SetNewType(Type newType)
        {
            NewTypeName = newType.FullName; ;
            AddParameters(typeof(object));
        }

        [NonSerialized]
        private static Dictionary<string, Type> TypeDictionary = new Dictionary<string, Type>
        {
            { "bool",  typeof(bool) },
            { "byte",  typeof(byte) },
            { "char",  typeof(char) },
            { "DateTime",  typeof(DateTime) },
            { "decimal",  typeof(decimal) },
            { "double",  typeof(double) },
            { "float",  typeof(float) },
            { "int",  typeof(int) },
            { "long",  typeof(long) },
            { "object",  typeof(object) },
            { "sbyte",  typeof(sbyte) },
            { "short",  typeof(short) },
            { "string",  typeof(string) },
            { "TimeSpan",  typeof(TimeSpan) },
            { "uint",  typeof(uint) },
            { "ulong",  typeof(ulong) },
            { "ushort",  typeof(ushort) },
        };

        public static string[] TypeNames => TypeDictionary.Keys.ToArray();
        public static Type[] Types => TypeDictionary.Values.ToArray();

        public static Type GetType(string typeName) => TypeDictionary[typeName];
    }
}
