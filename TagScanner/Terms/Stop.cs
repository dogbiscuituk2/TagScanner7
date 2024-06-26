﻿namespace TagScanner.Terms
{
    using System.Linq.Expressions;

    public class Stop : Term
    {
        public override Expression Expression => Expression.Throw(Expression.Constant(new StopException("Stop Command executed.")));

        public override string ToString() => Keywords.Stop;
    }
}
