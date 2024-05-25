namespace TagScanner.Terms
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class TryBlock : Compound
    {
        public TryBlock(Term tryTerm, params Catch[] catches) : this(tryTerm, finallyTerm: null, catches) { }
        public TryBlock(Term tryTerm, Term finallyTerm) : this(tryTerm, finallyTerm, catches: null) { }
        public TryBlock(Term tryTerm, Term finallyTerm, params Catch[] catches) : base()
        {
            TryTerm = tryTerm;
            Catches = catches.ToList();
            FinallyTerm = finallyTerm;
        }

        public Term TryTerm { get; protected set; }
        public List<Catch> Catches { get; protected set; }
        public Term FinallyTerm { get; protected set; }

        public override Expression Expression
        {
            get => Catches != null && Catches.Any()
                    ? FinallyTerm != null && !(FinallyTerm is EmptyTerm)
                        ? Expression.TryCatchFinally(TryTerm.Expression, FinallyTerm.Expression, CatchBlocks)
                        : (Expression)Expression.TryCatch(TryTerm.Expression, CatchBlocks)
                    : Expression.TryFinally(TryTerm.Expression, FinallyTerm.Expression);
        }

        private CatchBlock[] CatchBlocks => Catches.Select(p => Expression.Catch(p.Variable.ParameterExpression, p.BodyTerm.Expression)).ToArray();
    }
}
